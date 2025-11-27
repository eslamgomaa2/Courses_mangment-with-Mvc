using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using TasksProject._03_Services.Interfaces;
using TasksProject.Helper;

namespace TasksProject._03_Services.Implementions
{
    public class EmailService : IEmailServices
    {
        private readonly MailSettings _mailsettings;

        public EmailService(IOptions<MailSettings> mailsettings)
        {
            _mailsettings = mailsettings.Value;
        }

        public async Task SendEmailAsync(string mailTo, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add( new MailboxAddress(_mailsettings.DisplayName, _mailsettings.Email));
            email.To.Add(MailboxAddress.Parse(mailTo));
            email.Subject = subject;

            var builder = new BodyBuilder { HtmlBody = body };
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();


            smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
            await smtp.ConnectAsync(_mailsettings.Host, 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_mailsettings.Email, _mailsettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
