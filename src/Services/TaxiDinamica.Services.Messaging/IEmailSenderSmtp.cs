namespace TaxiDinamica.Services.Messaging
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEmailSenderSmtp
    {
        Task SendEmailAsync(
            string to,
            string subject,
            string htmlContent);
    }
}
