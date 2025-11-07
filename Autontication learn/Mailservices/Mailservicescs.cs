using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
namespace Autontication_learn.Mailservices
{
    public class Mailservicescs
    {

        public  Task SendEmail(string to, string subject, string body)
        {
            Console.WriteLine($"[SIMULATED EMAIL] To: {to}, Subject: {subject}, Body: {body}");
            return Task.CompletedTask;
        }
    }
}
