using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioBackend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class IssController : ControllerBase
    {

        private readonly HttpClient _httpClient;

        public IssController()
        {
            _httpClient = new HttpClient();
        }




        [HttpGet]
        public async Task<ActionResult<string>> GetIssLocation()
        {


            string url = "http://api.open-notify.org/iss-now.json";


            try
            {
                // Proveďte GET žádost na externí API  
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // Získejte data jako string  
                var data = await response.Content.ReadAsStringAsync();


                return Ok(data);

            }
            catch (HttpRequestException e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
