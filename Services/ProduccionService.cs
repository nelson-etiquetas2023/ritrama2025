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
        public SqlDataAdapter DaCortes = new();
        public DataTable DtCortes = new();
        public SqlDataAdapter DaRollos = new();
        public DataTable DtRollos = new();

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
                //2.- cargar la tabla de cortes.    
                SqlCommand ComandoCortes = new()
                {
                    Connection = conn,
                    CommandText = "select num,width,lenght,msi,orden,code_person from cortes",
                    CommandType = CommandType.Text
                };
                SqlDataReader readerCortes = await ComandoCortes.ExecuteReaderAsync();
                await readerCortes.CloseAsync();
                DaCortes.SelectCommand = ComandoCortes;
                DaCortes.Fill(Ds, "DtCortes");
                //3.- Cargar la Tabla de Rollos Cortados.
                SqlCommand ComandoRollos = new()
                {
                    Connection = conn,
                    CommandText = "SELECT numero,product_id,product_name,roll_number,unique_code,splice,width,large,msi,roll_id,code_person,status,disponible,width_c,lenght_c,ubic,ratio,fecha,rollid_oculto FROM rolls_details", 
                    CommandType = CommandType.Text
                };
                SqlDataReader readerRollos = await ComandoRollos.ExecuteReaderAsync();
                await readerRollos.CloseAsync();
                DaRollos.SelectCommand = ComandoRollos;
                DaRollos.Fill(Ds, "DtRollos");
            }
            catch (SqlException ex)
            {
                ErrorMsg = ex.Message;
                throw;
            }
            SetRelaionsTables();
            return Ds;
        }

        public Boolean SetRelaionsTables() 
        {
            try
            {
                //Relacion entre master y Cortes.
                DataColumn ParentCol0 = Ds.Tables["DtMaster"]!.Columns["numero"]!;
                DataColumn ChildCol0 = Ds.Tables["DtCortes"]!.Columns["orden"]!;
                DataRelation Despacho_Cortes = new("FK_ENCABEZADO_CORTES", ParentCol0, ChildCol0,false);
                Ds.Relations.Add(Despacho_Cortes);
                //Relacion entre master y Rollos.
                DataColumn ParentCol1 = Ds.Tables["DtMaster"]!.Columns["numero"]!;
                DataColumn ChildCol1 = Ds.Tables["DtRollos"]!.Columns["numero"]!;
                DataRelation Master_Rollos = new("FK_MASTER_ROLLOS", ParentCol1, ChildCol1);
                Ds.Relations.Add(Master_Rollos);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
                return false;
            }
        }
    }
}
