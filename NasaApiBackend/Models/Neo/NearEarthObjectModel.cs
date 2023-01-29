using System.Text.Json;
using System.Text.Json.Serialization;

namespace NasaApiBackend.Models.Neo
{
    public class NearEarthObjectModel
    {
        [JsonPropertyName("links")]
        public NearEarthObjectLinksModel Links { get; set; }

        [JsonPropertyName("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonPropertyName("neo_reference_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long NeoReferenceId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nasa_jpl_url")]
        public Uri NasaJplUrl { get; set; }

        [JsonPropertyName("absolute_magnitude_h")]
        public double AbsoluteMagnitudeH { get; set; }

        [JsonPropertyName("estimated_diameter")]
        public EstimatedDiameterModel EstimatedDiameter { get; set; }

        [JsonPropertyName("is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardousAsteroid { get; set; }

        [JsonPropertyName("close_approach_data")]
        public CloseApproachDatumModel[] CloseApproachData { get; set; }

        [JsonPropertyName("is_sentry_object")]
        public bool IsSentryObject { get; set; }
    }
}
