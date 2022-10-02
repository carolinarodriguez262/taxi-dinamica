using System;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using SendGrid;
using Microsoft.Extensions.Configuration;

namespace TaxiDinamica.Services.Messaging
{
    public class EmailSenderSmtp : IEmailSenderSmtp
    {
        private readonly SendGridClient client;
        private readonly IConfiguration configuration;

        public EmailSenderSmtp(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task SendEmailAsync(string to, string subject, string htmlContent)
        {
            try
            {
                using (MailMessage mm = new MailMessage(configuration["NetMail:sender"], to))
                {
                    mm.Subject = subject;
                    string body = htmlContent;
                    mm.Body = body;
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = configuration["NetMail:smtpHost"];
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(configuration["NetMail:sender"], configuration["NetMail:senderpassword"]);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
