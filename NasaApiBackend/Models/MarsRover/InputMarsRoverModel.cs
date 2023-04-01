using System.Text.Json.Serialization;

namespace NasaApiBackend.Models.MarsRover
{
    public class InputMarsRoverModel
    {
        [JsonPropertyName("photos")]
        public Photo[] Photos { get; set; }
    }
}
