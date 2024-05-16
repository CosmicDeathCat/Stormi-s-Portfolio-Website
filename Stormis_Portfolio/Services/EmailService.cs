using Azure.Communication.Email;

namespace Stormis_Portfolio.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string from, string to, string subject, string message);
    }

    public class EmailService : IEmailService
    {
        private readonly EmailClient emailClient;

        public EmailService(EmailClient emailClient)
        {
            this.emailClient = emailClient;
        }

        public async Task SendEmailAsync(string from, string to, string subject, string message)
        {
            var fromEmailAddress = new EmailAddress(from);
            var toEmailAddress = new EmailAddress(to);

            await emailClient.SendAsync(Azure.WaitUntil.Started, fromEmailAddress.Address, toEmailAddress.Address, subject, message);
        }
    }
}