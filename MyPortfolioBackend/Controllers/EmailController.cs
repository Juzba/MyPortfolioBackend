using Microsoft.AspNetCore.Mvc;
using MyPortfolioBackend.Models;
using MyPortfolioBackend.Services;
using System.Threading.Tasks;

namespace MyPortfolioBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] EmailMessage emailMessage)
        {
            if (emailMessage == null)
            {
                return BadRequest();
            }

            await _emailService.SendEmailAsync(emailMessage);
            return Ok(new { message = "Email sent successfully!" });
        }
    }
}