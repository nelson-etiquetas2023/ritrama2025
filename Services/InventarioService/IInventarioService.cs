using Ritrama2025.Models;

namespace Ritrama2025.Services.InventarioService
{
    public interface IInventarioService
    {
        bool SaveMasterInitialDB(List<ProductMAP> lista);
        bool ValidProductid(string id);
        bool InsertProduct(Product producto);
    }
}
