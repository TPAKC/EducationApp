using EducationApp.BusinessLogicalLayer.Helpers.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;
using static EducationApp.BusinessLogicalLayer.Constants.UserData;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
    public class EmailHelper : IEmailHelper
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(NameMailboxAddress, AdressMailboxAddress));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(HostConnectAsync, Port, false);
                await client.AuthenticateAsync(UserNameAuthenticateAsync, PasswordAuthenticateAsync);
                await client.SendAsync(emailMessage);
            }
        }
    }
}
