using Ritrama2025.Models;
using System.Data;

namespace Ritrama2025.Services
{
    public interface IProduccionService
    {
        Task<DataSet> LoadDataOC();
        void GuardarEncabezadoOrdenCorte(Orden OrdenCorte);
    }
}
