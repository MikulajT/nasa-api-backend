using System.Text.Json.Serialization;

namespace NasaApiBackend.Models.Neo
{
    public class MissDistanceModel
    {
        [JsonPropertyName("astronomical")]
        [JsonConverter(typeof(ParseDoubleConverter))]
        public double Astronomical { get; set; }

        [JsonPropertyName("lunar")]
        [JsonConverter(typeof(ParseDoubleConverter))]
        public double Lunar { get; set; }

        [JsonPropertyName("kilometers")]
        [JsonConverter(typeof(ParseDoubleConverter))]
        public double Kilometers { get; set; }

        [JsonPropertyName("miles")]
        [JsonConverter(typeof(ParseDoubleConverter))]
        public double Miles { get; set; }
    }
}
