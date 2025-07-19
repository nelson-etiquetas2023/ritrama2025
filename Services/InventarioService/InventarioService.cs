
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Ritrama2025.Models;

using System.Data;

namespace Ritrama2025.Services.InventarioService
{
    public class InventarioService : IInventarioService
    {
        public IConfiguration Config { get; }
        public string StringConnex { get; set; } = null!;
        public InventarioService(IConfiguration Config)
        {
            this.Config = Config;
            //Carga el string de Connexion de la aplicacion.
            if (Config != null)
            {
                var ambiente = Config["Ambiente"] ?? R.ENVIRONMET.DESARROLLO;
                StringConnex = Config.GetSection("ConnectionStringsEnvironment")[ambiente]!;
            }
        }
        public bool SaveMasterInitialDB(List<ProductMAP> lista)
        {
			try
			{
                using SqlConnection conn = new(StringConnex);
                conn.Open();

                foreach (var item in lista) 
                {
                    using var transaction = conn.BeginTransaction();
                    using SqlCommand comando = new()
                    {
                        Connection = conn,
                        Transaction = transaction,
                        CommandType = CommandType.Text,
                        CommandText = "INSERT INTO MasterInic (part_number,disponible,OrderPurchase,width,lenght,roll_id,splice,ubicacion,core,anulado,master,resma,graphics,embarque,fecha_pro,fecha_reg,width_c,lenght_c,palet_num) VALUES (@product_id,@dispo,@order,@wid,@len,@rollid,@splice,@ubic,@core,@anulado,@master,@resma,@graphics,@embarque,@fecha_pro,@fecha_reg,@wid_c,@len_c,@palet)"
                    };
                    comando.Parameters.AddWithValue("@product_id", item.Product_Id);
                    comando.Parameters.AddWithValue("@dispo", true);
                    comando.Parameters.AddWithValue("@order", 1);
                    comando.Parameters.AddWithValue("@wid", item.Width);
                    comando.Parameters.AddWithValue("@len", item.Length);
                    comando.Parameters.AddWithValue("@rollid", item.Rollid);
                    comando.Parameters.AddWithValue("@splice", item.Splice);
                    comando.Parameters.AddWithValue("@ubic", item.Ubic);
                    comando.Parameters.AddWithValue("@core", 0);
                    comando.Parameters.AddWithValue("@anulado", false);
                    comando.Parameters.AddWithValue("@master", true);
                    comando.Parameters.AddWithValue("@resma", false);
                    comando.Parameters.AddWithValue("@graphics", false);
                    comando.Parameters.AddWithValue("@embarque", item.Recepcion);
                    comando.Parameters.AddWithValue("@fecha_pro", DateTime.Today);
                    comando.Parameters.AddWithValue("@fecha_reg", DateTime.Today);
                    comando.Parameters.AddWithValue("@wid_c", 0);
                    comando.Parameters.AddWithValue("@len_c", 0);
                    comando.Parameters.AddWithValue("@palet", item.Paleta);





                    comando.ExecuteNonQuery();
                    transaction.Commit();

                }
                MessageBox.Show("Se ha guardaron los datos correctamente");
                return true;
            }
			catch (Exception ex)
			{
                MessageBox.Show("Error al guardar los datos en la base de datos. Error code: " + ex.Message);
                return false;
			}
        }
    }
}
