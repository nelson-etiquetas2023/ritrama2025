using Microsoft.Data.SqlClient;
using System.Data;

namespace Ritrama2025.Services
{
    public class ProduccionService : IProduccionService
    {
        public string StringConnex { get; set; } = null!;
        public string ErrorMsg { get; set; } = null!;
        public DataSet Ds = new();
        public SqlDataAdapter DaMaster = new();
        public DataTable DtMaster = new();


        public ProduccionService()
        {
            if (Program.Configuration != null) 
            {
                StringConnex = Convert.ToString(Program.Configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value)!;
            }
        }


        public async Task<DataSet> LoadDataOC()
        {
            try
            {
                //1.- cargar la tabla de encabezado de las Ordenes de Corte.
                using SqlConnection conn = new(StringConnex);
                SqlCommand ComandoMaster = new()
                {
                    Connection = conn,
                    CommandText = "SELECT numero,fecha,fecha_produccion,a.product_id,b.product_Name,rollid_1,width_1,lenght_1,rollid_2,width_2,lenght_2,util1_real_width,util1_real_lenght,util2_real_width,util2_real_lenght,rest1_width,rest1_lenght,rest2_width,rest2_lenght,a.id_operador,c.nombre,a.customer_id,d.customer_name,tot_inch_ancho,lenght_entrada,resta_entrada,total_salida,plus1_pies,plus2_pies,longitud_cortar,cortes_ancho,cortes_largo,cant_rollos FROM orden_corte a LEFT JOIN producto b ON a.product_id = b.product_id LEFT JOIN operadores c ON a.id_operador = c.id_operador LEFT JOIN customer d ON a.customer_id = d.customer_id ORDER BY numero DESC",
                    CommandType = CommandType.Text
                };
                await conn.OpenAsync();
                SqlDataReader readerMaster = await ComandoMaster.ExecuteReaderAsync();
                await readerMaster.CloseAsync();
                DaMaster.SelectCommand = ComandoMaster;
                DaMaster.Fill(Ds, "DtMaster");
            }
            catch (SqlException ex)
            {
                ErrorMsg = ex.Message;
                throw;
            }
            return Ds;
        }
    }
}
