using NasaApiBackend.Models.MarsRover;
using NasaApiBackend.Models.Neo;

namespace NasaApiBackend.Services
{
    public interface IMarsRoverService
    {
        string GetRoverNameFromId(int roverId);
        IEnumerable<OutputMarsRoverModel> GetOutputMarsModel(InputMarsRoverModel inputMarsRoverModel);
    }
}
