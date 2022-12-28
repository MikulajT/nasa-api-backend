using Microsoft.AspNetCore.Mvc;

namespace NasaApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApodController : Controller
    {
        private readonly IConfiguration _config;

        public ApodController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<string> Apod()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync($"https://api.nasa.gov/planetary/apod?api_key={_config["NasaApiKey"]}");
                if (result != null)
                {
                    string jsonResult = await result.Content.ReadAsStringAsync();
                    return jsonResult;
                }
                return "";
            }
        }
    }
}
