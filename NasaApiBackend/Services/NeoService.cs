using NasaApiBackend.Models.Neo;

namespace NasaApiBackend.Services
{
    public class NeoService : INeoService
    {
        public IEnumerable<OutputNeoModel> GetOutputNeosModel(InputNeoModel inputNeoModel)
        {
            foreach (var neoByDays in inputNeoModel.NearEarthObjects.Values)
            {
                foreach (var neo in neoByDays)
                {
                    OutputNeoModel outputNeoModel = new OutputNeoModel()
                    {
                        Id = neo.Id,
                        Name = neo.Name,
                        EstimatedDiameter = (decimal)(neo.EstimatedDiameter.Kilometers.EstimatedDiameterMin + neo.EstimatedDiameter.Kilometers.EstimatedDiameterMax) / 2,
                        IsPotentiallyHazardousAsteroid = neo.IsPotentiallyHazardousAsteroid,
                        CloseApproachDateFull = neo.CloseApproachData.First().CloseApproachDateFull,
                        MissDistance = (decimal)neo.CloseApproachData.First().MissDistance.Kilometers

                    };

                    //Round to 3 decimal places
                    outputNeoModel.EstimatedDiameter = Math.Truncate(outputNeoModel.EstimatedDiameter * 1000m) / 1000m;
                    outputNeoModel.MissDistance = Math.Truncate(outputNeoModel.MissDistance * 1000m) / 1000m;
                    yield return outputNeoModel;
                }
            }
        }
    }
}
