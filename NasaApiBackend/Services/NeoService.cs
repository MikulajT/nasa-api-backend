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
                        EstimatedDiameter = (neo.EstimatedDiameter.Kilometers.EstimatedDiameterMin + neo.EstimatedDiameter.Kilometers.EstimatedDiameterMax) / 2,
                        IsPotentiallyHazardousAsteroid = neo.IsPotentiallyHazardousAsteroid,
                        CloseApproachDateFull = neo.CloseApproachData.First().CloseApproachDateFull,
                        MissDistance = neo.CloseApproachData.First().MissDistance.Kilometers

                    };
                    yield return outputNeoModel;
                }
            }
        }
    }
}
