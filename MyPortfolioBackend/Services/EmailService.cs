using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Identity.Client;
using MimeKit;
using MyPortfolioBackend.Models;

namespace MyPortfolioBackend.Services
{
    public class EmailService
    {
        private readonly string _clientId = "427312232351-2aa2sulpcgapm9kufp4kdm2fmhbhtfds.apps.googleusercontent.com";
        private readonly string _clientSecret = "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";
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;

        public async Task SendEmailAsync(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(emailMessage.Name, emailMessage.Email));
            message.To.Add(new MailboxAddress("Jiří Strnadel", "Juzba88@gmail.com"));
            message.Subject = "New Message from Contact Form";
            message.Body = new TextPart("plain")
            {
                Text = emailMessage.Message
            };

            var app = ConfidentialClientApplicationBuilder.Create(_clientId)
                .WithClientSecret(_clientSecret)
                .Build(); // Bez aktuálního WithAuthority volání 

            //string[] scopes = new string[] { "https://mail.google.com/" }; // Pro Gmail  
            string[] scopes = new string[] { "https://mail.google.com/" }; // Pro Gmail  
            var result = await app.AcquireTokenForClient(scopes).ExecuteAsync();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpServer, _smtpPort, SecureSocketOptions.StartTls);
                client.Authenticate("Juzba88@gmail.com", result.AccessToken);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}