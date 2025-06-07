
using Ritrama2025.Models;

namespace Ritrama2025.Services.MateriaPrima
{
    public interface IServiceMateriaPrima
    {
        Task LoadTableHeaderMateriaPrima();
        bool LoadTableDetailsMateriaPrima();
        bool SetRelationsMateria();
        bool AddOrdenMateriaPrima(OrdenRecepcion orden);
        bool UpdateOrdenMateriaPrima(string orden);
        bool CloseOrdenMateriaPrima(string orden);
        bool LoadConsecOrdenMateria();
        bool UpdateConsecOrdenMateria();
    }
}
