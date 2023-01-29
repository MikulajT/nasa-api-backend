using System.Text.Json.Serialization;

namespace NasaApiBackend.Models.Neo
{
    public class CloseApproachDatumModel
    {
        [JsonPropertyName("close_approach_date")]
        public DateTimeOffset CloseApproachDate { get; set; }

        [JsonPropertyName("close_approach_date_full")]
        [JsonConverter(typeof(ParseDateTimeConverter))]
        public DateTime CloseApproachDateFull { get; set; }

        [JsonPropertyName("epoch_date_close_approach")]
        public long EpochDateCloseApproach { get; set; }

        [JsonPropertyName("relative_velocity")]
        public RelativeVelocityModel RelativeVelocity { get; set; }

        [JsonPropertyName("miss_distance")]
        public MissDistanceModel MissDistance { get; set; }
    }
}
