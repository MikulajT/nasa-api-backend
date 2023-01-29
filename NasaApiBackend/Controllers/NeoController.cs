﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using NasaApiBackend.Models.Neo;
using NasaApiBackend.Services;
using System.Text.Json;

namespace NasaApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeoController : Controller
    {
        private readonly IConfiguration _config;
        private readonly INeoService _neoService;

        public NeoController(IConfiguration config, INeoService neoService)
        {
            _config = config;
            _neoService = neoService;
        }

        public async Task<IActionResult> Neo(DateTime startDate, DateTime? endDate)
        {
            try
            {
                Dictionary<string, string?> urlQueryParams = new Dictionary<string, string?>
                {
                    { "api_key", _config["NasaApiKey"] },
                    { "startDate", startDate.ToString("yyyy-MM-dd") }
                };
                if (endDate != null)
                {
                    urlQueryParams.Add("endDate", endDate.Value.ToString("yyyy-MM-dd"));
                }
                string baseUrl = "https://api.nasa.gov/neo/rest/v1/feed";
                string url = QueryHelpers.AddQueryString(baseUrl, urlQueryParams);
                using (HttpClient httpClient = new HttpClient())
                {
                    var result = await httpClient.GetAsync(url);
                    result.EnsureSuccessStatusCode();
                    string jsonResult = await result.Content.ReadAsStringAsync();
                    var inputNeoModel = JsonSerializer.Deserialize<InputNeoModel>(jsonResult);
                    var neoOutputModel = _neoService.GetOutputNeosModel(inputNeoModel).ToList();
                    return Ok(neoOutputModel);
                }
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}