using System.Text.Json.Serialization;

namespace NasaApiBackend.Models.Neo
{
    //TODO: Make parser for DateTime
    public class MissDistanceModel
    {
        [JsonPropertyName("astronomical")]
        public string Astronomical { get; set; }

        [JsonPropertyName("lunar")]
        public string Lunar { get; set; }

        [JsonPropertyName("kilometers")]
        public string Kilometers { get; set; }

        [JsonPropertyName("miles")]
        public string Miles { get; set; }
    }
}
