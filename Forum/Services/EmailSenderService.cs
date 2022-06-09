using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Forum.Services
{
    public class EmailSenderService : IEmailSender
    {
        public EmailOptions Options { get; set; }

        public EmailSenderService(IOptions<EmailOptions> options)
        {
            Options = options.Value;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SendGridClient client = new SendGridClient(Options.SendGridKey);
            SendGridMessage message = new SendGridMessage()
            {
                From = new EmailAddress("tony_philipsen_@hotmail.com", "Welcome to GameForum"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };
            message.AddTo(email);

            try
            {
                var response = client.SendEmailAsync(message);
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
    }
}
