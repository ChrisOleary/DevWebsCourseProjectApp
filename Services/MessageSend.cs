using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using SendGrid;
using System.Net.Http;
using System;
using System.Text;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace DevWebsCourseProjectApp.Services
{
    public class MessageSend : IEmailSend, ISmsSend
    {

        public MessageSend(IOptions<MessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public MessageSenderOptions Options { get; set; } // all the api keys class

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

        public async Task SendSmsAsync(string number, string message)
        {
            //using (var client = new HttpClient { BaseAddress = new System.Uri("https://api.twillio.com") })
            //{
                //client.DefaultRequestHeaders.Authorization
                //    = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic"
                //    , Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Options.Sid}:" +
                //    $"{Options.AuthoToken}")));

                //var contentSms = new FormUrlEncodedContent(new []
                //{
                //    new KeyValuePair<string, string>("To", $"+{number}"),
                //    new KeyValuePair<string, string>("From", $"+15005550006"),
                //    new KeyValuePair<string, string>("Body", message)
                //});

                //var results = await client.PostAsync($"/2010-04-01/Accounts/{Options.Sid}/Message.json", contentSms).ConfigureAwait(false);

                TwilioClient.Init(Options.Sid, Options.AuthoToken);

            var smsMessage = MessageResource.Create(
                            body: number,
                            from: new Twilio.Types.PhoneNumber("+15005550006"),
                            to: new Twilio.Types.PhoneNumber("+15005550009"));

        
        }
    }
}
