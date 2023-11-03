using Gym_Management_System.Entities;
using Gym_Management_System.Entities.Auth;
using Gym_Management_System.Repositories;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using System.Data;

namespace Gym_Management_System.Controllers
{
    [Authorize(Roles = UserRoles.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmail email;
        public EmailController(IEmail email)
        {
            this.email = email;
        }
        [HttpPost]
        public IActionResult SandEmail(Email body)
        {
            #region Old Email Code
            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse("catalina.mayert@ethereal.email"));
            //email.To.Add(MailboxAddress.Parse("Aa7671951@gmail.com"));
            //email.Subject = "Test Email Subject";
            //email.Body = new TextPart(TextFormat.Html) { Text = body };

            //using var smtp = new SmtpClient();

            //smtp.Connect("smtp.ethereal.email",587,SecureSocketOptions.StartTls);
            //smtp.Authenticate("catalina.mayert@ethereal.email","R6r3FxxqeScd9Ca3JC");
            //smtp.Send(email);
            //smtp.Disconnect(true);
            //return Ok();
            #endregion
            email.EmailSander(body);
            return Ok();
        }
    }

}
