
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
        Task SetRelationsTables();
        bool AddOrdenMateriaPrima(OrdenRecepcion orden);
        bool UpdateOrdenMateriaPrima(string orden);
        bool CloseOrdenMateriaPrima(string orden);
        int LoadConsecOrdenMateria(string filtro);
        bool UpdateConsecOrdenMateria();
        bool GuardarOrden(OrdenMP orden);
        int LoadConsecOrden(string filtro);
        bool UpdateConsecOrden(string NumConsec);
        bool CloseOrder(string orden);
        bool UpDateLogsNotes(string orden, string logText);
    }
}
