

using Ritrama2025.Models;
using System.Data;

namespace Ritrama2025.Services.ProductsService
{
    public interface IProductsService
    {
        public Task<DataSet> Load();
        public Task<bool> Add(Product producto);
        public bool Update(Product producto);
        public bool Anular(string IdProduct);
        public bool ValidProductid(string id);
    }
}
