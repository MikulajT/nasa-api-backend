using System.Text.Json.Serialization;

namespace NasaApiBackend.Models.MarsRover
{
    public class Camera
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("rover_id")]
        public long RoverId { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }
    }
}
