namespace NasaApiBackend.Models.Neo
{
    public class OutputNeoModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double EstimatedDiameter { get; set; }
        public bool IsPotentiallyHazardousAsteroid { get; set; }
        public string CloseApproachDateFull { get; set; }
        public string MissDistance { get; set; }
    }
}
