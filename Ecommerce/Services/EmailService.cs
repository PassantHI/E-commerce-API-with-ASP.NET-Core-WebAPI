using System.Net.Mail;
using System.Net;

namespace Ecommerce.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string email, string subject, string body)
        {

            var smtpclient = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("PassantHatemIsmael@outlook.com", "@######@"),
                EnableSsl = true
            };


            var mailmassege = new MailMessage
            {
                From = new MailAddress("PassantHatemIsmael@outlook.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };


            mailmassege.To.Add(email);

            await smtpclient.SendMailAsync(mailmassege);
        }
    }
}

