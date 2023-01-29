using System.Text.Json.Serialization;

namespace NasaApiBackend.Models.Neo
{
    public class NearEarthObjectLinksModel
    {
        [JsonPropertyName("self")]
        public Uri Self { get; set; }
    }
}
