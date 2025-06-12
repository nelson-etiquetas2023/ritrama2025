using Microsoft.Data.SqlClient;
using Ritrama2025.Models;
using System.Data;

namespace Ritrama2025.Services.MateriaPrima
{
    public class ServiceMateriaPrima : IServiceMateriaPrima
    {
        public string StringConnex { get; set; } = null!;
        public DataSet Ds = new();
        public SqlDataAdapter DaMateria = new();
        public DataTable DtMateria = new();
        public SqlDataAdapter DaDetalle = new();
        public DataTable DtDetalle = new();
        public SqlDataAdapter DaProvider = new();
        public DataTable DtProvider = new();
        public SqlDataAdapter DaTransport = new();
        public DataTable DtTransport = new();
        public SqlDataAdapter DaProducts = new();
        public DataTable DtProducts = new();

        public ServiceMateriaPrima()
        {
            if (Program.Configuration != null)
            {
                StringConnex = Convert.ToString(Program.Configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value)!;
            }
        }
        public async Task<DataSet> LoadData() 
        {
            await LoadTableHeaderMateriaPrima();
            await LoadTableDetailsMateriaPrima();
            await LoadTableProveedores();
            await LoadTableTransportista();
            await LoadProductsAsync();
            return Ds;
        }
        private class ObjectQuery()
        {
            public string Query { get; set; } = null!;
            public string message { get; set; } = null!;
            public SqlDataAdapter Adapter { get; set; } = new();
            public string DataTableName { get; set; } = null!;
        }
        private ObjectQuery CreateObjectProduct()
        {
            return new ObjectQuery()
            {
                Query = R.SQL_STRING_QUERY.SELECT_QUERY_PRODUCTS,
                message = R.ERROR_MESSAGE_SYSTEM.ERROR_LOAD_PRODUCTS,
                Adapter = DaProducts,
                DataTableName = "DtProducts"
            };
        }
        private ObjectQuery CreateObjectQuery(ObjectQuery objectquery)
        {
            return new ObjectQuery()
            {
                Query = objectquery.Query,
                message = objectquery.message,
                Adapter = objectquery.Adapter,
                DataTableName = objectquery.DataTableName
            };
        }
        private async Task LoadTable(ObjectQuery objectQuery) 
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
                objectQuery.Adapter.Fill(Ds, objectQuery.DataTableName);
                await connection.CloseAsync();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(objectQuery.message + ex.Message);
            }
        }
        public async Task LoadProductsAsync()
        {
            await LoadTable(CreateObjectQuery(CreateObjectProduct()));
        }
        public async Task LoadTableDetailsMateriaPrima() 
        {
            try
            {
                using SqlConnection connection = new(StringConnex);
                await connection.OpenAsync();
                SqlCommand comando = new()
                {
                    Connection = connection,
                    CommandText = "select product_id,cant_pedido,cant_real,width,length,msi,rollid,splice,ubicacion,core from ItemsMateria",
                    CommandType = CommandType.Text
                };
                await comando.ExecuteNonQueryAsync();
                DaDetalle.SelectCommand = comando;
                DaDetalle.Fill(Ds, "DtDetalle");
                await connection.CloseAsync();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al cargar la tabla de detalle de recepciones de materia prima. error code: " + ex.Message);

            }
        }
        public async Task LoadTableHeaderMateriaPrima()
        {
            try
            {
                using SqlConnection connection = new(StringConnex);
                await connection.OpenAsync();
                SqlCommand comando = new()
                {
                    Connection = connection,
                    CommandText = "select numero,fecha_recepcion,fecha_pro,prov_id,orden_compra,persona_respons,notas,status,transport_id,guia_import,lote,doc_embarque,estado,total_cantidad,fecha_hora_close,anulado from OrdenMateria",
                    CommandType = CommandType.Text
                };
                await comando.ExecuteNonQueryAsync();
                DaMateria.SelectCommand = comando;
                DaMateria.Fill(Ds, "DtMateria");
                await connection.CloseAsync(); 
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al cargar la tabla de encabezado de recepciones de materia prima. error code: " + ex.Message);
                
            }
        }
        public bool LoadConsecOrdenMateria()
        {
            return true;
        }
        public bool AddOrdenMateriaPrima(OrdenRecepcion orden)
        {
            throw new NotImplementedException();
        }
        public bool CloseOrdenMateriaPrima(string orden)
        {
            throw new NotImplementedException();
        }
        public bool SetRelationsMateria()
        {
            throw new NotImplementedException();
        }
        public bool UpdateConsecOrdenMateria()
        {
            throw new NotImplementedException();
        }
        public bool UpdateOrdenMateriaPrima(string orden)
        {
            throw new NotImplementedException();
        }
        public async Task LoadTableProveedores()
        {
            try
            {
                using SqlConnection connection = new(StringConnex);
                await connection.OpenAsync();
                SqlCommand comando = new()
                {
                    Connection = connection,
                    CommandText = R.SQL_STRING_QUERY.SELECT_QUERY_PROVEEDORES,
                    CommandType = CommandType.Text
                };
                await comando.ExecuteNonQueryAsync();
                DaProvider.SelectCommand = comando;
                DaProvider.Fill(Ds, "DtProvider");
                await connection.CloseAsync();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al cargar la tabla de proveedores. error code: " + ex.Message);

            }
        }
        public async Task LoadTableTransportista()
        {
            try
            {
                using SqlConnection connection = new(StringConnex);
                await connection.OpenAsync();
                SqlCommand comando = new()
                {
                    Connection = connection,
                    CommandText = R.SQL_STRING_QUERY.SELECT_QUERY_TRANSPORTISTA,
                    CommandType = CommandType.Text
                };
                await comando.ExecuteNonQueryAsync();
                DaTransport.SelectCommand = comando;
                DaTransport.Fill(Ds, "DtTransport");
                await connection.CloseAsync();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al cargar la tabla de proveedores. error code: " + ex.Message);

            }
        }

        
    }
}
