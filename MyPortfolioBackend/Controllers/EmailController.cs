using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        //private readonly EmailService _emailService;

        //public EmailController()
        //{
        //    _emailService = new EmailService();
        //}

        [HttpPost]
        //[Route("send")]
        public ActionResult<string> SendEmail([FromBody] EmailRequest emailRequest)
        {
            //zkouska
            //_emailService.SendEmail(emailRequest.To, emailRequest.Subject, emailRequest.Message);
            return Ok(new { message = "Email sent successfully!" });
        }
    }

    public class EmailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}

