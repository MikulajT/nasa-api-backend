using System.Text.Json.Serialization;

namespace NasaApiBackend.Models.Neo
{
    public class CloseApproachDatumModel
    {
        [JsonPropertyName("close_approach_date")]
        public DateTimeOffset CloseApproachDate { get; set; }

        //TODO: Make parser for DateTime
        [JsonPropertyName("close_approach_date_full")]
        public string CloseApproachDateFull { get; set; }

        [JsonPropertyName("epoch_date_close_approach")]
        public long EpochDateCloseApproach { get; set; }

        [JsonPropertyName("relative_velocity")]
        public RelativeVelocityModel RelativeVelocity { get; set; }

        [JsonPropertyName("miss_distance")]
        public MissDistanceModel MissDistance { get; set; }
    }
}
