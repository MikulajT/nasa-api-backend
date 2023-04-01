using Microsoft.AspNetCore.Mvc;

namespace NasaApiBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApodController : Controller
    {
        private readonly IConfiguration _config;

        public ApodController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> Apod()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync($"https://api.nasa.gov/planetary/apod?api_key={_config["NasaApiKey"]}");
                if (result != null)
                {
                    string jsonResult = await result.Content.ReadAsStringAsync();
                    return Ok(jsonResult);
                }
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
