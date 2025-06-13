using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Ritrama2025.Models;
using System.Data;


namespace Ritrama2025.Services.CommonData
{
    public class ServiceDataCommon : IServiceCommonData
    {
        public string StringConnex { get; set; } = null!;
        private readonly IConfiguration _config;

        public ServiceDataCommon(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            StringConnex = Convert.ToString(_config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value)!;
        }

        public ObjectQuery CreateObjectQuery(ObjectQuery objectquery,DataSet dataset)
        {
            return new ObjectQuery()
            {
                Query = objectquery.Query,
                Message = objectquery.Message,
                Adapter = objectquery.Adapter,
                DataTableName = objectquery.DataTableName,
                DataSet =  dataset
            };
        }

        public ObjectQuery CreateObjectProduct(SqlDataAdapter da)
        {
            return new ObjectQuery()
            {
                Query = R.SQL_STRING_QUERY.SELECT_QUERY_PRODUCTS,
                Message = R.ERROR_MESSAGE_SYSTEM.ERROR_LOAD_PRODUCTS,
                Adapter = da,
                DataTableName = "DtProducts"
            };
        }

        public async Task LoadTable(ObjectQuery objectQuery)
        {
            try
            {
                using SqlConnection connection = new(StringConnex);
                await connection.OpenAsync();
                using SqlCommand comando = new()
                {
                    Connection = connection,
                    CommandText = objectQuery.Query,
                    CommandType = CommandType.Text
                };
                await comando.ExecuteNonQueryAsync();
                objectQuery.Adapter.SelectCommand = comando;
                objectQuery.Adapter.Fill(objectQuery.DataSet, objectQuery.DataTableName);
                await connection.CloseAsync();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(objectQuery.Message + ex.Message);
            }
        }
    }
}
