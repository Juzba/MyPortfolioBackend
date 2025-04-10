using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioBackend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OnlineController : Controller
    {


        [HttpGet]


        public IActionResult Get()
        {
            return Ok("Server je online!");
        }
    }
}
