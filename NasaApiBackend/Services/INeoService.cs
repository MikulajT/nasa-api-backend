using NasaApiBackend.Models.Neo;

namespace NasaApiBackend.Services
{
    public interface INeoService
    {
        IEnumerable<OutputNeoModel> GetOutputNeosModel(InputNeoModel inputNeoModel);
    }
}
