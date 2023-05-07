using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using NasaApiBackend.Models.MarsRover;
using NasaApiBackend.Models.Neo;
using NasaApiBackend.Services;
using System.Text.Json;

namespace NasaApiBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MarsRoverController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IMarsRoverService _marsRoverService;

        public MarsRoverController(IConfiguration config, IMarsRoverService marsRoverService)
        {
            _config = config;
            _marsRoverService = marsRoverService;
        }

        public async Task<IActionResult> RoverPhotos(int roverId, DateTime date, string camera)
        {
            try
            {
                string roverName = _marsRoverService.GetRoverNameFromId(roverId);
                Dictionary<string, string?> urlQueryParams = new Dictionary<string, string?>
                {
                    { "earth_date", date.ToString("yyyy-MM-dd") },
                    { "camera", camera },
                    { "api_key", _config["NasaApiKey"] }
                };
                string baseUrl = $"https://api.nasa.gov/mars-photos/api/v1/rovers/{roverName}/photos";
                string url = QueryHelpers.AddQueryString(baseUrl, urlQueryParams);
                using (HttpClient httpClient = new HttpClient())
                {
                    var result = await httpClient.GetAsync(url);
                    result.EnsureSuccessStatusCode();
                    string jsonResult = await result.Content.ReadAsStringAsync();
                    var inputMarsRoverModel = JsonSerializer.Deserialize<InputMarsRoverModel>(jsonResult);
                    var outputMarsRoverModel = _marsRoverService.GetOutputMarsModel(inputMarsRoverModel).ToList();
                    return Ok(outputMarsRoverModel);
                }
            }
            catch (Exception ex)
            {
                if (ex is HttpRequestException)
                {
                    HttpRequestException httpRequestException = (HttpRequestException)ex;
                    return new StatusCodeResult((int)httpRequestException.StatusCode);
                }
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IActionResult> RoverManifest(int roverId)
        {
            try
            {
                string roverName = _marsRoverService.GetRoverNameFromId(roverId);
                Dictionary<string, string?> urlQueryParams = new Dictionary<string, string?>
                {
                    { "api_key", _config["NasaApiKey"] }
                };
                string baseUrl = $"https://api.nasa.gov/mars-photos/api/v1/manifests/{roverName}";
                string url = QueryHelpers.AddQueryString(baseUrl, urlQueryParams);
                using (HttpClient httpClient = new HttpClient())
                {
                    var result = await httpClient.GetAsync(url);
                    result.EnsureSuccessStatusCode();
                    string jsonResult = await result.Content.ReadAsStringAsync();
                    var roverManifestModel = JsonSerializer.Deserialize<RovertManifestModel>(jsonResult);
                    return Ok(roverManifestModel?.PhotoManifest);
                }
            }
            catch (Exception ex) 
            {
                if (ex is HttpRequestException)
                {
                    HttpRequestException httpRequestException = (HttpRequestException)ex;
                    return new StatusCodeResult((int)httpRequestException.StatusCode);
                }
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
