using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Ritrama2025.Models;
using Ritrama2025.Services.CommonData;
using System.Data;


namespace Ritrama2025.Services.ProductsService
{
    
    public class ProductsService : IProductsService
    {
        public IConfiguration Configuration { get; set; } = null!;
        IServiceCommonData CommondData;
        DataSet Ds = new();
        DataTable DtProducts = new();
        SqlDataAdapter DaProducts = new();

        public string StringConnex { get; set; } = null!;
        public ProductsService(IServiceCommonData commonData, IConfiguration configuration)
        {
            CommondData = commonData;
            Configuration = configuration;
            if(Configuration != null)
            {
                var ambiente = Configuration["Ambiente"] ?? R.ENVIRONMET.DESARROLLO;
                StringConnex = Configuration.GetSection(R.ENVIRONMET.NAME_KEY_CONNECTION)[ambiente]!;
            }
        }
        public bool Add(Product producto)
        {
          
           return false;
        }

        public bool Anular(string IdProduct)
        {
            return false;
        }

        public async Task<DataSet> Load()
        {
            var sqlQuery = "SELECT [Product_ID],[Product_Name],[Product_Descrip],[Product_Ref],[Codebar],[Category_ID],[MasterRolls],[rollo_cortado],[Resmas],[Graphics],[anulado],[precio],[code_RC],[ratio] FROM [dbo].[producto]";

            DtProducts =  await DataAccess.ExecuteQuery<Product>(StringConnex, sqlQuery, null, false);
            Ds.Tables.Add(DtProducts);
            return Ds;
           
        }

        public bool Update(Product producto)
        {
            return false;
        }
    }
}
