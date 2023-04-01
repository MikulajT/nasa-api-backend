using System.Text.Json.Serialization;

namespace NasaApiBackend.Models.MarsRover
{
    public class Photo
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("sol")]
        public long Sol { get; set; }

        [JsonPropertyName("camera")]
        public Camera Camera { get; set; }

        [JsonPropertyName("img_src")]
        public string ImgSrc { get; set; }

        [JsonPropertyName("earth_date")]
        public DateTime EarthDate { get; set; }
    }
}
