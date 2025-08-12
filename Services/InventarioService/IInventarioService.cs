using Ritrama2025.Models;
using System.Data;

namespace Ritrama2025.Services.InventarioService
{
    public interface IInventarioService
    {
        bool SaveMasterInitialDB(List<ProductMAP> lista);
        bool ValidProductid(string id);
        bool InsertProduct(Product producto);
        Task<DataTable?> LoadMasterInventario();
    }
}
