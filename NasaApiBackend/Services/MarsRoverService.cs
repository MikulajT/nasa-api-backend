using NasaApiBackend.Models.MarsRover;
using NasaApiBackend.Models.Neo;

namespace NasaApiBackend.Services
{
    public class MarsRoverService : IMarsRoverService
    {
        public string GetRoverNameFromId(int roverId)
        {
            string roverName = "";
            switch (roverId) 
            {
                case 5:
                    roverName = "curiosity";
                    break;
                case 6:
                    roverName = "opportunity";
                    break;
                case 7:
                    roverName = "spirit";
                    break;
                case 8:
                    roverName = "perseverance";
                    break;
            }
            return roverName;
        }

        public IEnumerable<OutputMarsRoverModel> GetOutputMarsModel(InputMarsRoverModel inputMarsRoverModel)
        {
            List<OutputMarsRoverModel> outputModel = new List<OutputMarsRoverModel>();
            foreach (var photo in inputMarsRoverModel.Photos)
            {
                outputModel.Add(new OutputMarsRoverModel()
                {
                    Id = photo.Id,
                    CameraName = photo.Camera.Name,
                    CameraFullName = photo.Camera.FullName,
                    ImgSrc = photo.ImgSrc
                });
            }
            return outputModel;
        }
    }
}
