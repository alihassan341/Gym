using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using MimeKit;
using Gym_Management_System.Entities;
using MailKit.Net.Smtp;

namespace Gym_Management_System.Repositories
{
    public class EmailRepository : IEmail
    {
        public readonly IConfiguration _configuration;
        public EmailRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public void EmailSander(Email Request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(Request.To));
            email.Subject = Request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = Request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
