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
        public DataSet Ds = new();

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

        public bool BorrarMasterDB(string rollid)
        {
            try
            {
                using SqlConnection conn = new(StringConnex);
                conn.Open();

                using var transaction = conn.BeginTransaction();
                //en los iniciales
                using SqlCommand comando1 = new()
                {
                    Connection = conn,
                    Transaction = transaction,
                    CommandType = CommandType.Text,
                    CommandText = "delete from masterInic where roll_id=@rollid"
                };
                comando1.Parameters.AddWithValue("@rollid", rollid);
                comando1.ExecuteNonQuery();

                //en importacion
                using SqlCommand comando2 = new()
                {
                    Connection = conn,
                    Transaction = transaction,
                    CommandType = CommandType.Text,
                    CommandText = "delete from ItemsMateria where rollid=@rollid"
                };
                comando2.Parameters.AddWithValue("@rollid", rollid);
                comando2.ExecuteNonQuery();

                transaction.Commit();


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar master del inventario. Error code: " + ex.Message);
                return false;
            }
        }

        public async Task<DataTable?> LoadRolloCortadoInventaerio()
        {
            try
            {
                var parameters = new { NombreTabla = "rolls_details", Sql = R.QUERY.PRODUCTION.SQL_QUERY_LOAD_INVENTARIO_ROLLO_CORTADO };
                DataTable? dt = await CargarTablaAsync(parameters.Sql, false, null, parameters.NombreTabla, true);
                if (dt == null)
                {
                    throw new InvalidOperationException("La tabla de rollo cortado no se pudo cargar correctamente.");
                }
                else
                {
                    return dt;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al cargar los rollos cortados [error code: ] " + ex.Message);
                return null;
            }
        }

        public async Task<DataTable?> LoadMasterInventario()
        {
            try
            {
                var parameters = new { NombreTable = "MasterInics", Sql = R.QUERY.PRODUCTION.SQL_QUERY_SELECT_LOAD_ROLL_ID };

                DataTable? dt = await CargarTablaAsync(parameters.Sql, false, null, parameters.NombreTable, true);

                if (dt == null)
                {
                    throw new InvalidOperationException("La tabla de master no se pudo cargar correctamente.");
                }
                else
                {
                    return dt;
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al cargar los master [error code: ] " + ex.Message);
                return null;
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
                    comando.Parameters.AddWithValue("@embarque", item.Factura);
                    comando.Parameters.AddWithValue("@fecha_pro", item.Fecha_Produccion);
                    comando.Parameters.AddWithValue("@fecha_reg", item.Fecha_Llegada);
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

        public bool ValidProductid(string id)
        {
            try
            {
                using SqlConnection Conn = new(StringConnex);
                Conn.Open();

                using SqlCommand comando = new()
                {
                    Connection = Conn,
                    CommandType = CommandType.Text,
                    CommandText = "select COUNT(*) from producto where product_id = @id"
                };

                SqlParameter p1 = new("@id", id);
                comando.Parameters.Add(p1);

                var result = (int)comando.ExecuteScalar();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertProduct(Product producto)
        {
            try
            {
                using SqlConnection conn = new(StringConnex);
                conn.Open();
                using var transaction = conn.BeginTransaction();
                using SqlCommand comando = new()
                {
                    Connection = conn,
                    Transaction = transaction,
                    CommandType = CommandType.Text,
                    CommandText = "INSERT INTO producto (product_id,product_name,product_descrip,anulado,masterRolls,graphics,resmas,rollo_cortado) VALUES (@product_id,@name,@descrip,@anulado,@master,@graphics,@hojas,@rollo)"
                };
                comando.Parameters.AddWithValue("@product_id", producto.Product_id);
                comando.Parameters.AddWithValue("@name", producto.Product_Name);
                comando.Parameters.AddWithValue("@descrip", producto.Product_Description);
                comando.Parameters.AddWithValue("@anulado", producto.Anulado);
                comando.Parameters.AddWithValue("@master", producto.Master);
                comando.Parameters.AddWithValue("@graphics", producto.Graphics);
                comando.Parameters.AddWithValue("@hojas", producto.Hoja);
                comando.Parameters.AddWithValue("@rollo", producto.RolloCortado);
                comando.ExecuteNonQuery();
                transaction.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al tratar de registrar los productos, en el modulo de inventario...[error code: ] " + ex);
                return false;

            }
        }

        private async Task<DataTable?> CargarTablaAsync(
            string sqlQuery,
            bool loadDataset = false,
            SqlParameter[]? parametros = null,
            string? nombreTabla = null,
            bool returnDataTable = false)
        {

            using SqlConnection conn = new(StringConnex);
            await conn.OpenAsync();

            using SqlCommand comando = new()
            {
                Connection = conn,
                CommandText = sqlQuery,
                CommandType = CommandType.Text
            };

            if (parametros != null)
            {
                comando.Parameters.AddRange(parametros);
            }

            if (loadDataset)
            {
                using SqlDataAdapter adapter = new() { SelectCommand = comando };
                adapter.Fill(Ds, nombreTabla!);
                return null;
            }

            if (returnDataTable)
            {
                using SqlDataAdapter adapter = new() { SelectCommand = comando };
                DataTable dt = new();
                adapter.Fill(dt);
                return dt;
            }

            await comando.ExecuteNonQueryAsync();
            return null;

        }


    }
}
