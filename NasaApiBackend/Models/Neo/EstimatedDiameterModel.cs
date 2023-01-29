using System.Text.Json.Serialization;

namespace NasaApiBackend.Models.Neo
{
    public class EstimatedDiameterModel
    {
        [JsonPropertyName("kilometers")]
        public FeetModel Kilometers { get; set; }

        [JsonPropertyName("meters")]
        public FeetModel Meters { get; set; }

        [JsonPropertyName("miles")]
        public FeetModel Miles { get; set; }

        [JsonPropertyName("feet")]
        public FeetModel Feet { get; set; }
    }
}
