
using Microsoft.AspNetCore.Connections;
using System.Net;
using System.Net.Mail;
//using System.Threading.Tasks;

namespace VVCDotNetMail.API.Infra.Services
{
    public class MailService : IMailService 
    {
        private string smtpAdress => "smtp.gmail.com";
        private int porNumber => 587;
        private string emailFromAddress => "desigvvc@gmial.com";
        private string password => "********";
        public void SendMail(string[] emails, string subject, string body, bool isHtml = false)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(emailFromAddress);
                
                AddEmailsToMailMessage(mailMessage, emails);
                mailMessage.From = new MailAddress("teste123@gmail.com", "VVC Estudio");
                mailMessage.Subject = "Titulo emial test";
                mailMessage.Body = "Teste de envio de e-mail";
                mailMessage.IsBodyHtml = isHtml;

                using (SmtpClient smtp= new SmtpClient(smtpAdress, porNumber))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.Send(mailMessage);
                }

            }

        }
    }
}
