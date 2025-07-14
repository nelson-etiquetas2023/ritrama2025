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
            var ambiente = _config["Ambiente"] ?? R.ENVIRONMET.DESARROLLO;
            StringConnex = _config.GetSection("ConnectionStringsEnvironment")[ambiente]!;
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

        public int GetConsecutive(string filtro)
        {
            int Consec = 0;
            try
            {
                using SqlConnection conn = new(StringConnex);
                conn.Open();
                using SqlCommand comando = new()
                {
                    Connection = conn,
                    CommandText = "select par1 from control where filter=@p1",
                    CommandType = CommandType.Text
                };
                comando.Parameters.AddWithValue("@p1", filtro);
                Consec = Convert.ToInt32(comando.ExecuteScalar());
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular el consecutivo..." + ex.Message);
            }
            return Consec;
        }
    }
    public static class DataAccess 
    {
        public static async Task<bool> ExecuteQueryWrite(string connectionString, string sqlQuery, List<SqlParameter>? parameters, bool useTransaction) 
        {
            using var conn = new SqlConnection(connectionString);
            await conn.OpenAsync();

            SqlTransaction? transaction = null;
            if (useTransaction) transaction = conn.BeginTransaction();


            try
            {
                using var comando = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText = sqlQuery,
                    Transaction = transaction
                };

                if (parameters != null) comando.Parameters.AddRange(parameters.ToArray());

                await comando.ExecuteNonQueryAsync();

                transaction?.Commit();
                return true;

            }
            catch
            {
                transaction?.Rollback();
                return false;
            }
        }

        public static async Task<DataTable> ExecuteQuery<T>(string connectionString,string sqlQuery,List<SqlParameter>? parameters, bool useTransaction)
        {
            //var result = new List<T>();

            using var conn = new SqlConnection(connectionString);
            await conn.OpenAsync();

            SqlTransaction? transaction = null;
            if (useTransaction) transaction = conn.BeginTransaction();

            try
            {
                using var comando = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText = sqlQuery,
                };

                if (parameters != null) comando.Parameters.AddRange(parameters.ToArray());

                using var reader = await comando.ExecuteReaderAsync();
                
                var table = new DataTable();
                table.Load(reader);
                table.TableName = "Dtproducts";
                             
                transaction?.Commit();
                return table ?? new DataTable();

            }
            catch
            {
                transaction?.Rollback();
                throw;
            }
        }
    }
}
