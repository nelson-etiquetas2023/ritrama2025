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
            return Ds;
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

        public bool LoadTableDetailsMateriaPrima()
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
    }
}
