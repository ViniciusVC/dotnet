using System;
using System.Net;
using System.Net.Mail;

namespace VVCDotNetEmailConsole
{
    public static class SendEmail
    {       
        public static void Send(string email)
        {
            if (email=="")
            {
                Console.WriteLine("E-mail NAO FOI enviado. Faltoru um e-mail de destino.");
            }
            else{
                MailMessage emailMessage = new MailMessage();
                try
                {
                    var smtpClient = new SmtpClient("smtp.gmai.com,587");
                    smtpClient.EnableSsl = true;
                    smtpClient.Timeout = 60 * 60;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("teste123@gmail.com","*********"); // Usuario e senha
                    
                    emailMessage.From = new MailAddress("teste123@gmail.com","VVC Estudio");
                    emailMessage.Body = "Teste de envio de e-mail";
                    emailMessage.Subject = "Titulo emial test";
                    emailMessage.IsBodyHtml = true;
                    emailMessage.Priority = MailPriority.Normal;
                    emailMessage.To.Add(email);

                    smtpClient.Send(emailMessage);

                    Console.WriteLine("E-mail enviado.");
                } 
                catch(Exception ex)
                {
                    Console.WriteLine("E-mail NAO FOI enviado.");
                    Console.WriteLine(ex);
                    return;
                }
            }
        }
    }
}