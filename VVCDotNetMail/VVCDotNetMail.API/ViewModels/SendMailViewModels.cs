namespace VVCDotNetMail.API.ViewModels
{
    public class SendMailViewModels
    {
        public string[] Emails { get; set; }
        
        public string Subject { get; set; } 

        public string Body { get; set; }

        public bool IsHtml { get; set; }

    }
}
