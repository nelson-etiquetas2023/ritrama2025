using System.Data;

namespace Ritrama2025.Services
{
    public interface IProduccionService
    {
        Task<DataSet> LoadDataOC();
    }
}
