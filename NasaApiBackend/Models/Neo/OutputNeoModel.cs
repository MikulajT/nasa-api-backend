namespace NasaApiBackend.Models.Neo
{
    public class OutputNeoModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double EstimatedDiameter { get; set; }
        public bool IsPotentiallyHazardousAsteroid { get; set; }
        public DateTime CloseApproachDateFull { get; set; }
        public double MissDistance { get; set; }
    }
}
