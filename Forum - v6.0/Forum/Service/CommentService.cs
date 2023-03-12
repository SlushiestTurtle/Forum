using Forum.Interface;
using System.Net;
using System.Net.Mail;
using System.Xml.Linq;

namespace Forum.Service
{
    public class CommentService : ICommentService
    {
        public async Task Send(string from, string subject, string comments)
        {
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "tony_philipsen_@hotmail.com",
                    Password = "V!nterVatt3n"
                };

                smtp.Credentials = credential;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                var message = new MailMessage
                {
                    Body = $"From: {from} comment: <p>{comments}</p>",
                    Subject = subject,
                    IsBodyHtml = true
                };
                message.To.Add("tony_philipsen_@live.se");
                await smtp.SendMailAsync(message);
            }
        }
    }
}
