using Ritrama2025.Models;
using System.Data;

namespace Ritrama2025.Services
{
    public interface IProduccionService
    {
        Task<DataSet> LoadDataOC();
        void GuardarEncabezadoOrdenCorte(Orden OrdenCorte);
        void GuardarCortes(List<Corte> cortes);
        void GuardarRollos(List<RolloCortado> rollos);
        bool UpdateStatusDocumentOC(int stepchange,string oc);
    }
}
