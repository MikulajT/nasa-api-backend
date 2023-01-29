using System.Text.Json.Serialization;

namespace NasaApiBackend.Models.Neo
{
    public class NeoLinksModel
    {
        [JsonPropertyName("links")]
        public NeoLinksModel Links { get; set; }

        [JsonPropertyName("element_count")]
        public long ElementCount { get; set; }

        [JsonPropertyName("near_earth_objects")]
        public Dictionary<string, NearEarthObjectModel[]> NearEarthObjects { get; set; }
    }
}
