namespace NasaApiBackend.Models.Neo
{
    public class OutputNeoModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal EstimatedDiameter { get; set; }
        public bool IsPotentiallyHazardousAsteroid { get; set; }
        public DateTime CloseApproachDateFull { get; set; }
        public decimal MissDistance { get; set; }
    }
}
