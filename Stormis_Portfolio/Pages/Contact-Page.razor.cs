using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Stormis_Portfolio.Models;
using Stormis_Portfolio.Services;

namespace Stormis_Portfolio.Pages;

public partial class Contact_Page : ComponentBase
{
    [Inject] IEmailService emailService { get; set; }
    ContactForm contactForm = new();
    private string toAddress = "StormiDragon090@gmail.com";
    private string fromAddress = "donotreply@b6d1fa2c-effa-4597-b2ed-23ed3f6a56bd.azurecomm.net";

    private async Task HandleValidSubmit(EditContext arg)
    {
        try
        {
            string emailBody = $"Name: {contactForm.Name}\nEmail: {contactForm.Email}\nPhone Number: {contactForm.PhoneNumber}\nSubject: {contactForm.Subject}\nContact Reason: {contactForm.ContactReason}\nMessage: {contactForm.Message}";
            await emailService.SendEmailAsync(fromAddress, toAddress, contactForm.Subject, emailBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
