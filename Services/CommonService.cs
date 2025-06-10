using Microsoft.Data.SqlClient;
using Ritrama2025.Models;
using System.Data;
using System.Drawing.Imaging.Effects;

namespace Ritrama2025.Services
{
    public class CommonService
    {
        public string StringConnex { get; set; } = null!;
        public string ErrorMsg { get; set; } = null!;

        public CommonService()
        {
            if (Program.Configuration != null)
            {
                StringConnex = Convert.ToString(Program.Configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value)!;
            }
        }
        public async Task<List<RolloCortado>> GetDataRolloCortado(List<RolloCortado> lista)
        {
            // recorrer la lista para llenarla.
            foreach (var item in lista)
            {
                try
                {
                    using SqlConnection conn = new(StringConnex);
                    SqlCommand comando = new()
                    {
                        Connection = conn,
                        CommandType = CommandType.Text,
                        CommandText = "SELECT numero, product_id, product_name, roll_number, width, large, msi, splice, roll_id, code_person, status, unique_code, 'M' AS tipo_mov FROM rolls_details WHERE unique_code = @p1 AND disponible = 1 UNION SELECT numero, product_id, product_name, roll_number, width, large, msi, splice, roll_id, code_person, status, unique_code, 'M' AS tipo_mov  FROM RollsInic WHERE unique_code = @p1 AND disponible = 1"
                    };
                    SqlParameter p1 = new("@p1", item.UniqueCode);
                    comando.Parameters.Add(p1);
                    await conn.OpenAsync();
                    SqlDataReader reader = await comando.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        item.Product_Id = reader.GetString("product_id");
                        item.Product_Name = reader.GetString("product_name");
                        item.RollNumber = reader.GetInt32("roll_number");
                        item.Width = reader.GetDecimal("width");
                        item.Length = reader.GetDecimal("large");
                        item.Msi = reader.GetDecimal("msi");
                        item.Splice = reader.GetInt32("splice");
                        item.Roll_Id = reader.GetString("roll_id");
                        item.Cantidad_despacho = 0;
                        item.Cantidad = 0;
                        item.Tipo = reader.GetString("tipo_mov");
                        item.Code_Person = reader.GetString("code_person");
                        
                    }
                }
                catch (SqlException ex)
                {
                    ErrorMsg = ex.Message;
                    MessageBox.Show("error al cargar los datos del rc en el picking: "+ErrorMsg); 
                }
            }
            return lista;
        }
        public void SaveTransportEntity(string Id, string Name)
        {
            using SqlConnection conn = new(StringConnex);
            SqlCommand comando = new()
            {
                Connection = conn,
                CommandType = CommandType.Text,
                CommandText = "INSERT INTO transporte (transport_id, transport_name) VALUES (@p1, @p2)"
            };
            comando.Parameters.Add(new SqlParameter("@p1", SqlDbType.NVarChar) { Value = Id });
            comando.Parameters.Add(new SqlParameter("@p2", SqlDbType.NVarChar) { Value = Name });

            try
            {
                conn.Open();
                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ErrorMsg = ex.Message;
                MessageBox.Show("Error al guardar la entidad de transporte: " + ErrorMsg);
            }
        }

        public void DeleteTransportEntity(string Id)
        {
            using SqlConnection conn = new(StringConnex);
            SqlCommand comando = new()
            {
                Connection = conn,
                CommandType = CommandType.Text,
                CommandText = "DELETE FROM transporte WHERE transport_id=@p1"
            };
            comando.Parameters.Add(new SqlParameter("@p1", SqlDbType.NVarChar) { Value = Id });
            try
            {
                conn.Open();
                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ErrorMsg = ex.Message;
                MessageBox.Show("Error al eliminar la entidad de transporte: " + ErrorMsg);
            }
        }

        public void DeleteChoferEntity(string Id)
        {
            using SqlConnection conn = new(StringConnex);
            SqlCommand comando = new()
            {
                Connection = conn,
                CommandType = CommandType.Text,
                CommandText = "DELETE FROM chofer WHERE chofer_id=@p1"
            };
            comando.Parameters.Add(new SqlParameter("@p1", SqlDbType.NVarChar) { Value = Id });
            try
            {
                conn.Open();
                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ErrorMsg = ex.Message;
                MessageBox.Show("Error al eliminar la entidad de chofer: " + ErrorMsg);
            }
        }

        public void DeleteCamionEntity(string Id)
        {
            using SqlConnection conn = new(StringConnex);
            SqlCommand comando = new()
            {
                Connection = conn,
                CommandType = CommandType.Text,
                CommandText = "DELETE FROM camion WHERE placas_id=@p1"
            };
            comando.Parameters.Add(new SqlParameter("@p1", SqlDbType.NVarChar) { Value = Id });
            try
            {
                conn.Open();
                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ErrorMsg = ex.Message;
                MessageBox.Show("Error al eliminar la entidad de camion: " + ErrorMsg);
            }
        }

        public void SaveChoferEntity(string Id, string Name)
        {
            using SqlConnection conn = new(StringConnex);
            SqlCommand comando = new()
            {
                Connection = conn,
                CommandType = CommandType.Text,
                CommandText = "INSERT INTO chofer (chofer_id, chofer_name) VALUES (@p1, @p2)"
            };
            comando.Parameters.Add(new SqlParameter("@p1", SqlDbType.NVarChar) { Value = Id });
            comando.Parameters.Add(new SqlParameter("@p2", SqlDbType.NVarChar) { Value = Name });
            try
            {
                conn.Open();
                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ErrorMsg = ex.Message;
                MessageBox.Show("Error al guardar la entidad de chofer: " + ErrorMsg);
            }
        }
        public void SaveCamionEntity(string Id, string Name)
        {
            using SqlConnection conn = new(StringConnex);
            SqlCommand comando = new()
            {
                Connection = conn,
                CommandType = CommandType.Text,
                CommandText = "INSERT INTO camion (placas_id, camion_name) VALUES (@p1, @p2)"
            };
            comando.Parameters.Add(new SqlParameter("@p1", SqlDbType.NVarChar) { Value = Id });
            comando.Parameters.Add(new SqlParameter("@p2", SqlDbType.NVarChar) { Value = Name });
            try
            {
                conn.Open();
                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ErrorMsg = ex.Message;
                MessageBox.Show("Error al guardar la entidad de camion: " + ErrorMsg);
            }
        }
        public bool DocumentCheckWriteOC(DocumentCheckOC doc)
        {
            try
            {
                SqlConnection conn = new(StringConnex);
                conn.Open();
                SqlCommand comando = new()
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText = "update orden_corte set PersonCheck=@p2,Orden_Servicio=@p3,Orden_Trabajo=@p4,notes=@p5,Fecha_Autorize=@p6 where numero=@p1"
                };
                comando.Parameters.AddWithValue("@p1", doc.OrdenCorte);
                comando.Parameters.AddWithValue("@p2", doc.PersonCheck);
                comando.Parameters.AddWithValue("@p3", doc.Orden_Servicio);
                comando.Parameters.AddWithValue("@p4", doc.Orden_Trabajo);
                comando.Parameters.AddWithValue("@p5", doc.Observaciones);
                comando.Parameters.AddWithValue("@p6", doc.FechaCheck);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al tratar de aprobar el documento de orden de corte...: codigo error :" + ex.Message);
                return false;
            }
        }
        public DocumentCheckOC DocumentCheckReadOC(string oc) 
        {
            DocumentCheckOC document = new();
            
            try
            {
                using SqlConnection conn = new(StringConnex);
                conn.Open();
                SqlCommand comando = new()
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText = "select PersonCheck,Orden_Servicio,Orden_Trabajo,notes,Fecha_Autorize from orden_corte where numero=@p1"
                };
                comando.Parameters.AddWithValue("@p1", oc);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read()) 
                {
                    document = new() 
                    {
                        PersonCheck = dr.GetString(dr.GetOrdinal("PersonCheck")),
                        Orden_Servicio = dr.GetString(dr.GetOrdinal("Orden_Servicio")),
                        Orden_Trabajo = dr.GetString(dr.GetOrdinal("Orden_Trabajo")),
                        Observaciones = dr.GetString(dr.GetOrdinal("notes")),
                        FechaCheck = dr.GetDateTime(dr.GetOrdinal("Fecha_Autorize"))
                    };
                }
                return document;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al tratar de leer el documento aprobado de orden de corte...: codigo error :" + ex.Message);
                return document;   
            }

        }
    }
}
