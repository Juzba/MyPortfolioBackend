using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioBackend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OnlineController : ControllerBase
    {


        [HttpGet]


        public IActionResult Get()
        {
            return Ok("Server je online!");
        }
    }
}
