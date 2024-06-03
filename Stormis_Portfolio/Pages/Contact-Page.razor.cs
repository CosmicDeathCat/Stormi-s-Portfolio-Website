using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Stormis_Portfolio.Models;
using Stormis_Portfolio.Services;
using Stormis_Portfolio.Templates.Email;
using System.Collections.Concurrent;

namespace Stormis_Portfolio.Pages;

public partial class Contact_Page : ComponentBase
{
    [Inject] IEmailService emailService { get; set; }
    ContactForm contactForm = new();
    private string toAddress = "StormiDragon090@gmail.com";
    private string fromAddress = "donotreply@b6d1fa2c-effa-4597-b2ed-23ed3f6a56bd.azurecomm.net";
    private bool isSubmitted = false;
    private string message = "Thank you for contacting me! I'll be in touch soon!";

    // Dictionary to store the last submission time for each email address
    private static ConcurrentDictionary<string, DateTime> lastSubmissionTimes = new();
    // private TimeSpan submissionInterval = TimeSpan.FromHours(1); // Configurable interval
    private TimeSpan submissionInterval = TimeSpan.FromHours(1); // Configurable interval

    private async Task HandleValidSubmit(EditContext arg)
    {
        try
        {
            string userKey = contactForm.Email; // Using email as the key
            DateTime now = DateTime.UtcNow;

            if (lastSubmissionTimes.TryGetValue(userKey, out DateTime lastSubmissionTime))
            {
                if (now - lastSubmissionTime < submissionInterval)
                {
                    message = "You have already submitted a contact form. Please wait at least 1 hour before submitting another.";
                    return;
                }
            }

            message = "Thank you for contacting me! I'll be in touch soon!";

            // Update the last submission time
            lastSubmissionTimes[userKey] = now;

            // Send the email
            await emailService.SendEmailAsync(fromAddress, toAddress, contactForm.Subject, ContactFormEmailTemplate.ContactFormEmail(contactForm));
            isSubmitted = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
