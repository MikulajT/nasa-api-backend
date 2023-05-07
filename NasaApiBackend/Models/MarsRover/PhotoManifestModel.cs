using System.Text.Json.Serialization;

namespace NasaApiBackend.Models.MarsRover
{
    public class PhotoManifestModel
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("max_date")]
        public DateTime InputMaxDate { private get; set; }

        [JsonPropertyName("total_photos")]
        public int InputTotalPhotos { private get; set; }

        [JsonPropertyName("maxDate")]
        public DateTime OutputMaxDate => InputMaxDate;

        [JsonPropertyName("totalPhotos")]
        public int OutputTotalPhotos => InputTotalPhotos;
    }
}
