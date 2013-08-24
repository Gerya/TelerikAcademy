using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web.Http;
using Mailer.Data;
using Mailer.ServiceHook.Models;

namespace Mailer.ServiceHook.Controllers
{
    /// <summary>
    /// It is a working class (I believe), you just need to substitute
    /// all dummy values (email addresses, host/port) with real ones.
    /// 
    /// The list of seeded dummy emails is located in Mailer.Data.Migrations.
    /// Don't forget to change it!
    /// </summary>
    [RoutePrefix("api")]
    public class MailerHookController : ApiController
    {
        private readonly MailerContext db = new MailerContext();
        private const string FromAddress = "systemMailer@b.com";
        private const string SmtpHost = "your smtp host/ip address goes here";
        private const int SmtpPort = 25; // That's the RFC port. You may want to use another.

        [HttpPost("mailerhook")]
        public HttpResponseMessage MailerHook(AppHarborStatus status)
        {
            if (ModelState.IsValid)
            {
                StartBroadcasting(status);

                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        private void StartBroadcasting(AppHarborStatus status)
        {
            var emailsCollection = db.Emails.ToList();

            if (emailsCollection.Count == 0)
            {
                return;
            }

            // You can use the SmtpHost and SmtpPort constants as parameters to the SmtpClient constructor
            var client = new SmtpClient();
            foreach (var email in emailsCollection)
            {
                var msg = new MailMessage(new MailAddress(FromAddress), new MailAddress(email.EmailAddress));

                msg.Subject = status.Application.Name;
                msg.Body = status.Build.Branch.Commit.Message;

                msg.SubjectEncoding = Encoding.UTF8;
                msg.BodyEncoding = Encoding.UTF8;

                client.SendCompleted += new SendCompletedEventHandler(SendCompleted);

                // Uncomment the following line to actually send emails
                //client.SendAsync(msg, new { SendFor = email });

                msg.Dispose();                
            }

            client.Dispose();
        }

        private static void SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // This is the token which says to whom was send this email.
            // ((dynamic)e.UserState).SendFor

            // Some other code...
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
