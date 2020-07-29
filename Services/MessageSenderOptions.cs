namespace DevWebsCourseProjectApp.Services
{
    // this class maps to the user secrets for api keys 
    public class MessageSenderOptions
    {
        public string SendGridApiKey { get; set; } // SendGrid

        public string Sid { get; set; } // twillio

        public string AuthoToken { get; set; } // twillio
    }
}
