using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;


namespace EmailApi.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {


        [HttpPost("send")]

        public IActionResult SendEmail([FromBody] EmailRequest emailRequest)
        {


            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(emailRequest.Name, "Juzba88@seznam.cz"));
                message.To.Add(new MailboxAddress("Juzba@88gmail.com", "Juzba88@gmail.com"));
                message.Subject = "!!! Portfolio Kontaktní formulář !!!";
                message.Body = new TextPart("plain") { Text = emailRequest.Message };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.seznam.cz", 587, SecureSocketOptions.StartTls); // Použij své SMTP nastavení  
                    client.Authenticate("Juzba88@seznam.cz", "nebermiheslo.cz");
                    client.Send(message);
                    client.Disconnect(true);
                }

                return Ok("E-mail byl úspěšně odeslán.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Chyba při odesílání e-mailu: {ex.Message}");
            }
        }
    }
}

public class EmailRequest
{
    public required string Name { get; set; }
    public required string Message { get; set; }
}
