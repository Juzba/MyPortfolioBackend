using MailKit.Net.Smtp;
using MimeKit;


namespace MyPortfolioBackend;

public class EmailService
{
    private readonly string _smtpServer = "smtp.gmail.com"; // Změňte na váš SMTP server  
    private readonly int _port = 587; // Typický port pro SMTP  
    private readonly string _username = "Juzba88@gmail.com"; // Váš e-mail  
    private readonly string _password = "your-email-password"; // Vaše heslo  

    public void SendEmail(string toEmail, string subject, string message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("Your Name", _username));
        emailMessage.To.Add(new MailboxAddress("Blabla",toEmail));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart("html") { Text = message };

        using (var client = new SmtpClient())
        {
            client.Connect(_smtpServer, _port, true);
            client.Authenticate(_username, _password);
            client.Send(emailMessage);
            client.Disconnect(true);
        }
    }
}


