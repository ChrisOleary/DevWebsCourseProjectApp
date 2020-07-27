using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using SendGrid;

namespace DevWebsCourseProjectApp.Services
{
    public class EmailSend : IEmailSend
    {

        public EmailSend(IOptions<MessageSenderOptions> optionsAccessor) 
        {
            Options = optionsAccessor.Value;
        }

        public MessageSenderOptions Options { get; set; }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var myMessage = new SendGridMessage();
            myMessage.AddTo(email);
            myMessage.From = new EmailAddress("chris_oleary@test.com", "Dave");
            myMessage.Subject = subject;
            myMessage.PlainTextContent = message;

            var apiKey = Options.SendGridApiKey;

            var tansportWeb = new SendGridClient(apiKey);

            return tansportWeb.SendEmailAsync(myMessage);
        }
    }
}
