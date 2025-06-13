
using Ritrama2025.Models;
using System.Data;

namespace Ritrama2025.Services.MateriaPrima
{
    public interface IServiceMateriaPrima
    {
        Task<DataSet> LoadData();
        Task LoadProducts();
        Task LoadTableHeaderMateriaPrima();
        Task LoadTableDetailsMateriaPrima();
        Task LoadTableProveedores();
        Task LoadTableTransportista();
        bool SetRelationsMateria();
        bool AddOrdenMateriaPrima(OrdenRecepcion orden);
        bool UpdateOrdenMateriaPrima(string orden);
        bool CloseOrdenMateriaPrima(string orden);
        bool LoadConsecOrdenMateria();
        bool UpdateConsecOrdenMateria();
    }
}
