using NasaApiBackend.Models.MarsRover;

namespace NasaApiBackend.Services
{
    public interface IMarsRoverService
    {
        string GetRoverNameFromId(int roverId);
        IEnumerable<OutputMarsRoverModel> GetOutputMarsModel(InputMarsRoverModel inputMarsRoverModel);
    }
}
