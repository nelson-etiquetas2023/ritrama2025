using Microsoft.Data.SqlClient;
using Ritrama2025.Models;
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
        public SqlDataAdapter DaRollid = new();
        public DataTable DtRollid = new();
        public SqlDataAdapter DaOperator = new();
        public DataTable DtOperator = new();
        public SqlDataAdapter DaCustomer = new();
        public DataTable DtCustomer = new();

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
                    CommandText = "SELECT numero,fecha,fecha_produccion,a.product_id,b.product_Name,rollid_1,width_1,lenght_1,rollid_2,width_2,lenght_2,util1_real_width,util1_real_lenght,util2_real_width,util2_real_lenght,rest1_width,rest1_lenght,rest2_width,rest2_lenght,a.id_operador,c.nombre,a.customer_id,d.customer_name,tot_inch_ancho,lenght_entrada,resta_entrada,total_salida,plus1_pies,plus2_pies,longitud_cortar,cortes_ancho,cortes_largo,cant_rollos,cant_rollos2,step FROM orden_corte a LEFT JOIN producto b ON a.product_id = b.product_id LEFT JOIN operadores c ON a.id_operador = c.id_operador LEFT JOIN customer d ON a.customer_id = d.customer_id ORDER BY numero DESC",
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
                    CommandText = "SELECT numero,product_id,product_name,roll_number,unique_code,splice,width,large,msi,roll_id,code_person,status,disponible,width_c,lenght_c,ubic,ratio,fecha,rollid_oculto FROM rolls_details ORDER BY roll_number ASC",
                    CommandType = CommandType.Text
                };
                SqlDataReader readerRollos = await ComandoRollos.ExecuteReaderAsync();
                await readerRollos.CloseAsync();
                DaRollos.SelectCommand = ComandoRollos;
                DaRollos.Fill(Ds, "DtRollos");
                // 4.- Carga de los Master en el Inventario.
                SqlCommand ComandoRollid = new()
                {
                    Connection = conn,
                    CommandText = "SELECT a.roll_id,a.part_number,b.product_name,a.master,a.graphics,a.resma,a.Width,lenght=a.lenght - a.lenght_c, disponible, fecha_pro, fecha_recep, splice, Ubicacion,'M' AS tipo_mov from MasterInic a LEFT JOIN producto b ON a.part_number = b.product_id where b.MasterRolls = 1 and a.disponible = 1",
                    CommandType = CommandType.Text
                };
                SqlDataReader readerRollid = await ComandoRollid.ExecuteReaderAsync();
                await readerRollid.CloseAsync();
                DaRollid.SelectCommand = ComandoRollid;
                DaRollid.Fill(Ds, "DtRollid");
                //5.- Carga de los Rollos en el Operadores.
                SqlCommand ComandoOperator = new()
                {
                    Connection = conn,
                    CommandText = "SELECT id_operador,nombre,status FROM operadores",
                    CommandType = CommandType.Text
                };
                SqlDataReader readerOperator = await ComandoOperator.ExecuteReaderAsync();
                await readerOperator.CloseAsync();
                DaOperator.SelectCommand = ComandoOperator;
                DaOperator.Fill(Ds, "DtOperator");
                //6.- Carga de los Customer.
                SqlCommand ComandoCust = new()
                {
                    Connection = conn,
                    CommandText = "SELECT customer_id,customer_name FROM customer",
                    CommandType = CommandType.Text
                };
                SqlDataReader readerCust = await ComandoCust.ExecuteReaderAsync();
                await readerCust.CloseAsync();
                DaCustomer.SelectCommand = ComandoCust;
                DaCustomer.Fill(Ds, "DtCustomer");
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
                DataRelation Despacho_Cortes = new("FK_ENCABEZADO_CORTES", ParentCol0, ChildCol0, false);
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
        public void GuardarEncabezadoOrdenCorte(Orden OrdenCorte)
        {
            try
            {
                SqlConnection conn = new(StringConnex);
                SqlCommand comando = new()
                {
                    Connection = conn,
                    CommandText = "INSERT INTO orden_corte (numero,fecha,fecha_produccion,product_id,rollid_1,width_1,lenght_1,rollid_2,width_2,lenght_2,anulada,procesado,status,tot_inch_ancho,longitud_cortar,cortes_ancho,cortes_largo,cant_rollos,decartable1_pies,lenght_master_real,util1_real_width,util1_real_lenght,descartable2_pies" + ",util2_real_width,util2_real_lenght,lenght_master_real2,rest1_width,rest1_lenght,rest2_width,rest2_lenght,cant_rollos2,cortes_largo2,step,lastupdate,fecha_autorize,toautorize,notes,closedocument,tipo_mov1,tipo_mov2,plus1_pies,plus2_pies,id_operador,customer_id,rollo_unificado,length_entrada,real_usado_r1,real_usado_r2,restante_rollid1,restante_rollid2,resta_entrada,total_salida,lenght_entrada) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23,@p24,@p25,@p26,@p27,@p28,@p29,@p30,@p31,@p32,@p33,@p34,@p35,@p36,@p37,@p38,@p39,@p40,@p41,@p42,@p43,@p44,@p45,@p46,@p47,@p48,@p49,@p50,@p51,@p52,@p53)",
                    CommandType = CommandType.Text
                };
                conn.Open();
                comando.Parameters.AddWithValue("@p1", OrdenCorte.Numero);
                comando.Parameters.AddWithValue("@p2", OrdenCorte.Fecha);
                comando.Parameters.AddWithValue("@p3", OrdenCorte.Fecha_produccion);
                comando.Parameters.AddWithValue("@p4", OrdenCorte.Product_id);
                comando.Parameters.AddWithValue("@p5", OrdenCorte.Rollid_1);
                comando.Parameters.AddWithValue("@p6", OrdenCorte.Width_1);
                comando.Parameters.AddWithValue("@p7", OrdenCorte.Lenght_1);
                comando.Parameters.AddWithValue("@p8", OrdenCorte.Rollid_2);
                comando.Parameters.AddWithValue("@p9", OrdenCorte.Width_2);
                comando.Parameters.AddWithValue("@p10", OrdenCorte.Lenght_2);
                comando.Parameters.AddWithValue("@p11", OrdenCorte.Anulada);
                comando.Parameters.AddWithValue("@p12", OrdenCorte.Procesado);
                comando.Parameters.AddWithValue("@p13", OrdenCorte.Status);
                comando.Parameters.AddWithValue("@p14", OrdenCorte.Total_Inch_Ancho);
                comando.Parameters.AddWithValue("@p15", OrdenCorte.Longitud_Cortar);
                comando.Parameters.AddWithValue("@p16", OrdenCorte.Cortes_Ancho);
                comando.Parameters.AddWithValue("@p17", OrdenCorte.Cortes_Largo);
                comando.Parameters.AddWithValue("@p18", OrdenCorte.Cantidad_Rollos);
                comando.Parameters.AddWithValue("@p19", OrdenCorte.Descartable1_pies);
                comando.Parameters.AddWithValue("@p20", OrdenCorte.Lenght_Master_Real);
                comando.Parameters.AddWithValue("@p21", OrdenCorte.Util1_Real_Width);
                comando.Parameters.AddWithValue("@p22", OrdenCorte.Util1_real_Lenght);
                comando.Parameters.AddWithValue("@p23", OrdenCorte.Descartable2_pies);
                comando.Parameters.AddWithValue("@p24", OrdenCorte.Util2_Real_Width);
                comando.Parameters.AddWithValue("@p25", OrdenCorte.Util2_real_Lenght);
                comando.Parameters.AddWithValue("@p26", OrdenCorte.Master_lenght2_Real);
                comando.Parameters.AddWithValue("@p27", OrdenCorte.Rest1_width);
                comando.Parameters.AddWithValue("@p28", OrdenCorte.Rest1_lenght);
                comando.Parameters.AddWithValue("@p29", OrdenCorte.Rest2_width);
                comando.Parameters.AddWithValue("@p30", OrdenCorte.Rest2_lenght);
                comando.Parameters.AddWithValue("@p31", OrdenCorte.Cantidad_Rollos2);
                comando.Parameters.AddWithValue("@p32", OrdenCorte.Cortes_Largo2);
                comando.Parameters.AddWithValue("@p33", OrdenCorte.Step);
                comando.Parameters.AddWithValue("@p34", OrdenCorte.LastUpdate);
                comando.Parameters.AddWithValue("@p35", OrdenCorte.FechaAutorize);
                comando.Parameters.AddWithValue("@p36", OrdenCorte.ToAutorize);
                comando.Parameters.AddWithValue("@p37", OrdenCorte.Note);
                comando.Parameters.AddWithValue("@p38", OrdenCorte.CloseDocument);
                comando.Parameters.AddWithValue("@p39", OrdenCorte.Tipo_Mov1);
                comando.Parameters.AddWithValue("@p40", OrdenCorte.Tipo_Mov2);
                comando.Parameters.AddWithValue("@p41", OrdenCorte.Plus1_pies);
                comando.Parameters.AddWithValue("@p42", OrdenCorte.Plus2_pies);
                comando.Parameters.AddWithValue("@p43", OrdenCorte.Id_operador);
                comando.Parameters.AddWithValue("@p44", OrdenCorte.Customer_Id);
                comando.Parameters.AddWithValue("@p45", OrdenCorte.Rollo_unificado);
                comando.Parameters.AddWithValue("@p46", OrdenCorte.Lenght_entrada);
                comando.Parameters.AddWithValue("@p47", OrdenCorte.Real_usado_r1);
                comando.Parameters.AddWithValue("@p48", OrdenCorte.Real_usado_r2);
                comando.Parameters.AddWithValue("@p49", OrdenCorte.Restante_rollid1);
                comando.Parameters.AddWithValue("@p50", OrdenCorte.Restante_rollid2);
                comando.Parameters.AddWithValue("@p51", 0);
                comando.Parameters.AddWithValue("@p52", 0);
                comando.Parameters.AddWithValue("@p53", 0);
                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al guardar el encabezado de la orden " + ex.Message);
            }
        }
        public void GuardarCortes(List<Corte> cortes)
        {
            try
            {
                SqlConnection conn = new(StringConnex);
                conn.Open();
                foreach (var corte in cortes)
                {
                    SqlCommand comando = new()
                    {
                        Connection = conn,
                        CommandText = "INSERT INTO cortes (num,width,lenght,msi,orden,code_person) VALUES(@p1,@p2,@p3,@p4,@p5,@p6)",
                        CommandType = CommandType.Text
                    };
                    comando.Parameters.AddWithValue("@p1", corte.Numero);
                    comando.Parameters.AddWithValue("@p2", corte.Width);
                    comando.Parameters.AddWithValue("@p3", corte.Length);
                    comando.Parameters.AddWithValue("@p4", corte.Msi);
                    comando.Parameters.AddWithValue("@p5", corte.Orden);
                    comando.Parameters.AddWithValue("@p6", corte.CodePerson);
                    comando.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al guardar los cortes " + ex.Message);
            }


        }
        public void GuardarRollos(List<RolloCortado> rollos)
        {
            try
            {
                SqlConnection conn = new(StringConnex);
                conn.Open();
                foreach (var roll in rollos)
                {
                    SqlCommand comando = new()
                    {
                        Connection = conn,
                        CommandText = "INSERT INTO rolls_details (product_id,product_name,roll_number,unique_code,splice,width,large,msi,roll_id,code_person,status,disponible,ubic,numero) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)",
                        CommandType = CommandType.Text
                    };
                    comando.Parameters.AddWithValue("@p1", roll.Product_Id);
                    comando.Parameters.AddWithValue("@p2", roll.Product_Name);
                    comando.Parameters.AddWithValue("@p3", roll.RollNumber);
                    comando.Parameters.AddWithValue("@p4", roll.UniqueCode);
                    comando.Parameters.AddWithValue("@p5", roll.Splice);
                    comando.Parameters.AddWithValue("@p6", roll.Width);
                    comando.Parameters.AddWithValue("@p7", roll.Length);
                    comando.Parameters.AddWithValue("@p8", roll.Msi);
                    comando.Parameters.AddWithValue("@p9", roll.Roll_Id);
                    comando.Parameters.AddWithValue("@p10", roll.Code_Person);
                    comando.Parameters.AddWithValue("@p11", roll.Status);
                    comando.Parameters.AddWithValue("@p12", true);
                    comando.Parameters.AddWithValue("@p13", roll.Ubicacion);
                    comando.Parameters.AddWithValue("@p14", roll.Numero);
                    comando.ExecuteNonQuery();
                }
                MessageBox.Show("La Orden de Corte se guardo correctamente...");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al guardar los rollos " + ex.Message);
            }
        }
        public int BuscarUniqueCodeConsec()
        {
            int Consec;
            try
            {
                SqlConnection conn = new(StringConnex);
                conn.Open();
                SqlCommand comando = new()
                {
                    Connection = conn,
                    CommandText = "select par1 from control where filter='UC'",
                    CommandType = CommandType.Text
                };
                Consec = Convert.ToInt32(comando.ExecuteScalar());
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el Unique-Code de la Orden Corte" + ex.Message);
                throw;
            }
            return Consec;
        }
        public int BuscarConsecOC()
        {
            int Consec;
            try
            {
                SqlConnection conn = new(StringConnex);
                conn.Open();
                SqlCommand comando = new()
                {
                    Connection = conn,
                    CommandText = "select par1 from control where filter='COC'",
                    CommandType = CommandType.Text
                };
                Consec = Convert.ToInt32(comando.ExecuteScalar());
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el consecutivo de la Orden Corte" + ex.Message);
                throw;
            }
            return Consec;
        }
        public bool UpdateConsecOC(string consec)
        {
            try
            {
                SqlConnection conn = new(StringConnex);
                conn.Open();
                SqlCommand comando = new()
                {
                    Connection = conn,
                    CommandText = "update control set par1=@p1 where filter='COC'",
                    CommandType = CommandType.Text
                };
                SqlParameter p1 = new("@p1", consec);
                comando.Parameters.Add(p1);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al actualizar el consecutivo de la orden de corte. Codigo de Error : " + ex.Message);
                return false;
            }
        }
        public bool UpdateStatusDocumentOC(int stepchange, string oc)
        {
            try
            {
                SqlConnection conn = new(StringConnex);
                conn.Open();
                SqlCommand comando = new()
                {
                    Connection = conn,
                    CommandText = "update orden_corte set step=@p2 where numero=@p1",
                    CommandType = CommandType.Text
                };
                SqlParameter p1 = new("@p1", oc);
                SqlParameter p2 = new("@p2", stepchange);
                comando.Parameters.Add(p1);
                comando.Parameters.Add(p2);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al actualizar el estatus del documento. codigo error: " + ex.Message);
                return false;
            }

        }
        public bool UpdateUniqueCodeBD(string consec)
        {
            try
            {
                SqlConnection conn = new(StringConnex);
                conn.Open();
                SqlCommand comando = new()
                {
                    Connection = conn,
                    CommandText = "update control set par1=@p1 where filter='UC'",
                    CommandType = CommandType.Text
                };
                SqlParameter p1 = new("@p1", consec);
                comando.Parameters.Add(p1);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al actualizar el UNIQUE CODE de los rollos cortados. Codigo de Error : " + ex.Message);
                return false;
            }
        }
        public void UpdateUniqueCodeRollosCortados(List<RolloCortado> rollos) 
        {
            try
            {
                SqlConnection conn = new(StringConnex);
                conn.Open();
                foreach (var roll in rollos)
                {
                    SqlCommand comando = new()
                    {
                        Connection = conn,
                        CommandText = "update rolls_details set unique_code=@p2 where roll_number=@p1 and numero=@p3",
                        CommandType = CommandType.Text
                    };
                    comando.Parameters.AddWithValue("@p1", roll.RollNumber);
                    comando.Parameters.AddWithValue("@p2", roll.UniqueCode);
                    comando.Parameters.AddWithValue("@p3", roll.Numero);
                    comando.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al guardar los codigo unicos de los rollos" + ex.Message);
            }
        }

       
    }
}
