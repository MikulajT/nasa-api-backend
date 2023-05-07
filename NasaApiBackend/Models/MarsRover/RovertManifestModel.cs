using System.Text.Json.Serialization;

namespace NasaApiBackend.Models.MarsRover
{
    public class RovertManifestModel
    {
        [JsonPropertyName("photo_manifest")]
        public PhotoManifestModel PhotoManifest { get; set; }
    }
}
