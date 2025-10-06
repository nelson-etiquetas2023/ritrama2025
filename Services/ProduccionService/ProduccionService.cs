using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Ritrama2025.Models;
using System.Data;

namespace Ritrama2025.Services.ProduccionService;

public class ProduccionService : IProduccionService
{
    public IConfiguration Config { get; } = null!;
    public string StringConnex { get; set; } = null!;
    public string ErrorMsg { get; set; } = null!;
    public DataSet Ds = new();
    public DataTable DtMaster = new();
    public DataTable DtCortes = new();
    public DataTable DtRollos = new();
    public DataTable DtRollid = new();
    public DataTable DtOperator = new();
    public DataTable DtCustomer = new();

    public ProduccionService(IConfiguration config)
    {
        Config = config;
        if (Config != null)
        {
            var ambiente = Config["Ambiente"] ?? R.ENVIRONMET.DESARROLLO;
            StringConnex = Config.GetSection("ConnectionStringsEnvironment")[ambiente]!;
        }
    }

    private async Task<DataTable?> CargarTablaAsync(
        string sqlQuery,
        bool loadDataset = false,
        SqlParameter[]? parametros = null,
        string? nombreTabla = null,         
        bool returnDataTable = false
        )
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

    public async Task<DataSet> LoadDataOC()
    {
        try
        {
            Ds.RejectChanges();
            Ds.Relations.Clear();
            foreach (DataTable table in Ds.Tables)
            {
                table.Clear(); // Elimina todas las filas
            }
            Ds.Tables.Clear();
            Ds.AcceptChanges();
            var tablas = new[]
            {
                new { Nombre = "DtMaster", Sql = R.QUERY.PRODUCTION.SQL_QUERY_SELECT_LOAD_OC_HEADER },
                new { Nombre = "DtRollos", Sql = R.QUERY.PRODUCTION.SQL_QUERY_SELECT_LOAD_OC_ROLLO_CORTADO },
                new { Nombre = "DtOperator", Sql = R.QUERY.PRODUCTION.SQL_QUERY_SELECT_LOAD_OPERATOR },
                new { Nombre = "DtCustomer", Sql = R.QUERY.PRODUCTION.SQL_QUERY_SELECT_LOAD_CUSTOMER },
                new { Nombre = "DtCortes", Sql = R.QUERY.PRODUCTION.SQL_QUERY_SELECT_LOAD_OC_CORTES },
                new { Nombre = "DtRollid", Sql = R.QUERY.PRODUCTION.SQL_QUERY_SELECT_LOAD_ROLL_ID },

            };

            foreach (var tabla in tablas)
                await CargarTablaAsync(tabla.Sql,true,null,tabla.Nombre,false);

            SetRelaionsTables();

        }
        catch (SqlException ex)
        {
            ErrorMsg = ex.Message;
            throw;
        }
        
        return Ds;
    }
    public bool SetRelaionsTables()
    {
        try
        {

            // Relación entre master y Rollos.
            var relacion = new DataRelation(R.PARAMETERS.NAME_RELATION_OC_MASTER_DETAILS,
                            Ds.Tables["DtMaster"]!.Columns["numero"]!,
                            Ds.Tables["DtRollos"]!.Columns["numero"]!,false);

            if (!Ds.Relations.Contains(R.PARAMETERS.NAME_RELATION_OC_MASTER_DETAILS))
                Ds.Relations.Add(relacion);

            DataColumn? ParentCol0 = Ds.Tables["DtMaster"]?.Columns["numero"];
            DataColumn? ChildCol0 = Ds.Tables["DtCortes"]?.Columns["orden"];

            DataRelation Despacho_Cortes = new("FK_ENCABEZADO_CORTES", ParentCol0!, ChildCol0!, false);
            Ds.Relations.Add(Despacho_Cortes);
            return true;
        }
        catch (ConstraintException ex)
        {
            ErrorMsg = ex.Message;
            return false;
        }
        catch (InvalidOperationException ex)
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
                CommandText = "INSERT INTO orden_corte (numero,fecha,fecha_produccion,product_id,rollid_1,width_1,lenght_1,rollid_2,width_2,lenght_2,anulada,procesado,CloseDocument,tot_inch_ancho,longitud_cortar,cortes_ancho,cortes_largo,cant_rollos,decartable1_pies,lenght_master_real,util1_real_width,util1_real_lenght,descartable2_pies" + ",util2_real_width,util2_real_lenght,lenght_master_real2,rest1_width,rest1_lenght,rest2_width,rest2_lenght,cant_rollos2,cortes_largo2,step,lastupdate,fecha_autorize,toautorize,notes,tipo_mov1,tipo_mov2,plus1_pies,plus2_pies,rollo_unificado,length_entrada,real_usado_r1,real_usado_r2,restante_rollid1,restante_rollid2,resta_entrada,total_salida,lenght_entrada,customer_id,operador_id,SellOrder,desperdicio,master_tipo,ubicacion) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23,@p24,@p25,@p26,@p27,@p28,@p29,@p30,@p31,@p32,@p33,@p34,@p35,@p36,@p37,@p38,@p39,@p40,@p41,@p44,@p45,@p46,@p47,@p48,@p49,@p50,@p51,@p52,@customer_id,@operador_id,@SellOrder,@desper,@MasterTipo,@ubic)",
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
            comando.Parameters.AddWithValue("@p13", OrdenCorte.CloseDocument);
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
            comando.Parameters.AddWithValue("@p38", OrdenCorte.Tipo_Mov1);
            comando.Parameters.AddWithValue("@p39", OrdenCorte.Tipo_Mov2);
            comando.Parameters.AddWithValue("@p40", OrdenCorte.Plus1_pies);
            comando.Parameters.AddWithValue("@p41", OrdenCorte.Plus2_pies);
            comando.Parameters.AddWithValue("@p44", OrdenCorte.Rollo_unificado);
            comando.Parameters.AddWithValue("@p45", OrdenCorte.Lenght_entrada);
            comando.Parameters.AddWithValue("@p46", OrdenCorte.Real_usado_r1);
            comando.Parameters.AddWithValue("@p47", OrdenCorte.Real_usado_r2);
            comando.Parameters.AddWithValue("@p48", OrdenCorte.Restante_rollid1);
            comando.Parameters.AddWithValue("@p49", OrdenCorte.Restante_rollid2);
            comando.Parameters.AddWithValue("@p50", 0);
            comando.Parameters.AddWithValue("@p51", 0);
            comando.Parameters.AddWithValue("@p52", 0);
            comando.Parameters.AddWithValue("@sellOrder",OrdenCorte.SellOrder);
            comando.Parameters.AddWithValue("@desper", OrdenCorte.Desperdicio);
            comando.Parameters.AddWithValue("@MasterTipo", OrdenCorte.Master_Tipo);
            comando.Parameters.AddWithValue("@ubic", OrdenCorte.Ubicacion);
            comando.Parameters.Add(new SqlParameter("@customer_id", SqlDbType.UniqueIdentifier)
            {
                Value = OrdenCorte.Customer_Id
            });
            comando.Parameters.Add(new SqlParameter("@operador_id", SqlDbType.UniqueIdentifier)
            {
                Value = OrdenCorte.Operador_id
            });

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
                    CommandText = "INSERT INTO cortes (num,width,lenght,msi,orden) VALUES(@p1,@p2,@p3,@p4,@p5)",
                    CommandType = CommandType.Text
                };
                comando.Parameters.AddWithValue("@p1", corte.Numero);
                comando.Parameters.AddWithValue("@p2", corte.Width);
                comando.Parameters.AddWithValue("@p3", corte.Length);
                comando.Parameters.AddWithValue("@p4", corte.Msi);
                comando.Parameters.AddWithValue("@p5", corte.Orden);
                //comando.Parameters.AddWithValue("@p6", corte.CodePerson);
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
                    CommandText = "INSERT INTO rolls_details (product_id,product_name,roll_number,unique_code,splice,width,large,msi,roll_id,code_person,status,disponible,ubic,numero) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,0,@p13,@p14)",
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
                //comando.Parameters.AddWithValue("@p12", true);
                comando.Parameters.AddWithValue("@p13", roll.Ubicacion);
                comando.Parameters.AddWithValue("@p14", roll.Numero);
                

                comando.ExecuteNonQuery();
            }
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
            MessageBox.Show("se guardaron los datos correctanmentes.");
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
    public bool CheckOperatorDefault(string id, string name)
    {
        //verificar si el registro no-asignado existe?
        try
        {
            using SqlConnection Conn = new(StringConnex);
            Conn.Open();

            using SqlCommand comando = new()
            {
                Connection = Conn,
                CommandType = CommandType.Text,
                CommandText = "select COUNT(*) from operadores where operador_id = @id"
            };

            SqlParameter p1 = new("@id", id);
            comando.Parameters.Add(p1);

            var result = (int)comando.ExecuteScalar();
            if (result > 0)
            {
                //existe
                return true;
            }
            else
            {
                //no existe, insertar el registro.
                AddOperatorDefault(id, name);
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }





    }
    public void AddOperatorDefault(string id, string name)
    {
        try
        {
            using SqlConnection Conn = new(StringConnex);
            Conn.Open();
            using SqlCommand comando = new()
            {
                Connection = Conn,
                CommandType = CommandType.Text,
                CommandText = "INSERT INTO operadores (operador_id,nombre,status) VALUES (@id,@name,1)"
            };
            SqlParameter p1 = new("@id", id);
            SqlParameter p2 = new("@name", name);
            comando.Parameters.Add(p1);
            comando.Parameters.Add(p2);
            comando.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al agregar el operador por defecto: " + ex.Message);
        }

    }
    public bool OrdenUpdateCodePerson(string orden, string code_person)
    {
        try
        {
            SqlConnection conn = new(StringConnex);
            conn.Open();
            SqlCommand comando = new()
            {
                Connection = conn,
                CommandText = "update rolls_details set code_person=@code_per where numero=@orden",
                CommandType = CommandType.Text
            };
            SqlParameter p1 = new("@code_per", code_person);
            SqlParameter p2 = new("@orden", orden);

            comando.Parameters.Add(p1);
            comando.Parameters.Add(p2);

            comando.ExecuteNonQuery();
            
            return true;
        }
        catch (SqlException ex)
        {
            MessageBox.Show("Error al actualizar el codigo personalizado. Codigo de Error : " + ex.Message);
            return false;
        }

    }
    public bool UpdateOrdenCorte(Orden orden)
    {
        try
        {
            SqlConnection conn = new(StringConnex);
            conn.Open();
            SqlCommand comando = new()
            {
                Connection = conn,
                CommandText = "update orden_corte set fecha=@fecha,fecha_produccion=@fecha_pro,operador_id=@oper,sellOrder=@sellOrder,desperdicio=@desper,customer_id=@CustId where numero=@orden",
                CommandType = CommandType.Text
            };
            SqlParameter p1 = new("@orden", orden.Numero);
            SqlParameter p2 = new("@fecha", orden.Fecha);
            SqlParameter p3 = new("@fecha_pro", orden.Fecha_produccion);
            SqlParameter p4 = new("@oper", orden.Operador_id);
            SqlParameter p5 = new("@sellOrder", orden.SellOrder);
            SqlParameter p6 = new("@desper", orden.Desperdicio);
            SqlParameter p7 = new("@CustId", orden.Customer_Id);
            comando.Parameters.Add(p1);
            comando.Parameters.Add(p2);
            comando.Parameters.Add(p3);
            comando.Parameters.Add(p4);
            comando.Parameters.Add(p5);
            comando.Parameters.Add(p6);
            comando.Parameters.Add(p7);
            comando.ExecuteNonQuery();
            MessageBox.Show("Se actualizo la orden de corte correctamente.");   
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al actualizar la orden de corte: error[code] :" + ex.Message);
            return false;
        }
    }
    public async Task<bool> UpdateInventaryMasterInitial(object objeto)
    {
        try
        {
            var tipo = objeto.GetType();
            var rollIdProperty = tipo.GetProperty("roll_id")!.GetValue(objeto);
            var consumoParcialProperty = tipo.GetProperty("consumo")!.GetValue(objeto);
            var nameTableProperty = tipo.GetProperty("nametable")!.GetValue(objeto);
            var sqlProperty = tipo.GetProperty("sql")!.GetValue(objeto)!.ToString();  

            SqlParameter[] parametros =
            [
                new SqlParameter("@consumo", consumoParcialProperty),
                new SqlParameter("@rollid", rollIdProperty)
            ];

            await CargarTablaAsync(sqlProperty!,false,parametros, nameTableProperty!.ToString(), false);

            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("error al actualizar los inventarios de master Inic [error code: ] " + ex.Message);
            return false;
        }
    }
    public async Task<DataTable?> LoadTableMasterInic()
    {
        try
        {
            var tabla = new { nameTabla = "MasterInic", sql = R.QUERY.PRODUCTION.SQL_QUERY_SELECT_LOAD_ROLL_ID };

            DataTable? dt = await CargarTablaAsync(tabla.sql, false, null, tabla.nameTabla, true);

            if (dt == null)
            {
                throw new InvalidOperationException("La tabla MasterInic no se pudo cargar correctamente.");
            }
            else
            {
                return dt;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("error al cargar la tabla de los iniciales [error code: ] " + ex.Message);
            return null;
        }
    }
    public async Task<bool> UpdateDetailsConsumosMasterIniciales(string rollid, string orden, double length_consumo, DateTime fecha_reg,bool desperdicio)
    {
        try
        {
            var tabla = new { nameTabla = "MasterDetailsInic", sql = R.QUERY.PRODUCTION.UPDATE_QUERY_ACTUALIZAR_INVENTARIO_DETAILS_INICIALES};

            SqlParameter[] parameros =
            [ 
                new SqlParameter("@rollid", rollid),
                new SqlParameter("@orden", orden),
                new SqlParameter("@consumo", length_consumo),
                new SqlParameter("@fecha", fecha_reg),
                new SqlParameter("@desperdicio", desperdicio)
            ];

            await CargarTablaAsync(tabla.sql,false,parameros,tabla.nameTabla,false);
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("error al actualizar el detalle de los master [error code: ] " + ex.Message);
            return false;
        }
    }
    public async Task<DataTable?> LoadDataDetailsConsumosMasterInic(string rollid)
    {
        try
        {
            var tabla = new { nameTabla = "MasterDetailsInic", sql = R.QUERY.PRODUCTION.SQL_SELECT_QUERY_LOAD_DETAILS_MASTER_INICIALES };

            SqlParameter[] parametros =
            [
                new SqlParameter("@rollid", rollid)
            ];

            DataTable? dt = await CargarTablaAsync(tabla.sql, false, parametros, tabla.nameTabla, true);

            if (dt == null)
            {
                throw new InvalidOperationException("La tabla de detalle de consumos de master no se pudo cargar correctamente.");
            }
            else
            {
                return dt;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("error al cargar los detalles de los master iniciales [error code: ] " + ex.Message);
            return null;
        }
    }

    public void Update_Items_Orden_Corte(List<RolloCortado> rollos)
    {
        try
        {
            using SqlConnection conn = new(StringConnex);
           
            conn.Open();
            foreach (var item in rollos) 
            {
                using SqlCommand comando = new()
                {
                    Connection = conn,
                    CommandText = "UPDATE rolls_details SET splice = @p3,status = @p4,code_person = @p5 WHERE numero = @p1 and unique_code = @p2",
                    CommandType = CommandType.Text
                };
                comando.Parameters.AddWithValue("@p1", item.Numero);
                comando.Parameters.AddWithValue("@p2", item.UniqueCode);
                comando.Parameters.AddWithValue("@p3", item.Splice);
                comando.Parameters.AddWithValue("@p4", item.Status);
                comando.Parameters.AddWithValue("@p5", item.Code_Person);
                
                comando.ExecuteNonQuery();
                
            }
            conn.Close();
            MessageBox.Show("Se actualizaron los datos correctamente...");

        }
        catch (SqlException ex)
        {
            MessageBox.Show("Error al mopdificar los renglones de la orden de corte...error code: " + ex);
        }
    }

    public void Update_Header_Documnet_OC(Orden orden)
    {
        try
        {
            using SqlConnection conn = new(StringConnex);
            conn.Open();
            //GUARDAR EL ENCABEZADO DE LA ORDEN.
            using SqlCommand comando = new()
            {
                Connection = conn,
                CommandText = "UPDATE orden_corte SET fecha=@p2,fecha_produccion=@p3,width_1=@p4,lenght_1=@p5,util1_real_width=@p6,util1_real_lenght=@p7,rest1_width=@p8,rest1_lenght=@p9,product_id=@p10,desperdicio=@p11,operador_id=@p12,customer_id=@p13,cortes_largo=@p14,longitud_cortar=@p15,cortes_ancho=@p16,cant_rollos=@p17,sellOrder=@p18,rollid_1=@p19,ubicacion=@p20 WHERE numero=@p1",
                CommandType = CommandType.Text
            };
            comando.Parameters.AddWithValue("@p1", orden.Numero);
            comando.Parameters.AddWithValue("@p2", orden.Fecha);
            comando.Parameters.AddWithValue("@p3", orden.Fecha_produccion);
            comando.Parameters.AddWithValue("@p4", orden.Width_1);
            comando.Parameters.AddWithValue("@p5", orden.Lenght_1);
            comando.Parameters.AddWithValue("@p6", orden.Util1_Real_Width);
            comando.Parameters.AddWithValue("@p7", orden.Util1_real_Lenght);
            comando.Parameters.AddWithValue("@p8", orden.Rest1_width);
            comando.Parameters.AddWithValue("@p9", orden.Rest2_lenght);
            comando.Parameters.AddWithValue("@p10", orden.Product_id);
            comando.Parameters.AddWithValue("@p11", orden.Desperdicio);
            comando.Parameters.AddWithValue("@p12", orden.Operador_id);
            comando.Parameters.AddWithValue("@p13", orden.Customer_Id);
            comando.Parameters.AddWithValue("@p14", orden.Cortes_Largo);
            comando.Parameters.AddWithValue("@p15", orden.Longitud_Cortar);
            comando.Parameters.AddWithValue("@p16", orden.Cortes_Ancho);
            comando.Parameters.AddWithValue("@p17", orden.Cantidad_Rollos);
            comando.Parameters.AddWithValue("@p18", orden.SellOrder);
            comando.Parameters.AddWithValue("@p19", orden.Rollid_1);
            comando.Parameters.AddWithValue("@p20", orden.Ubicacion);


            comando.ExecuteNonQuery();
            //BORRAR LOS CORTES ANTERIORES
            using SqlCommand comando_borrar_cortes = new()
            {
                Connection = conn,
                CommandText = "DELETE FROM cortes WHERE orden=@p1",
                CommandType = CommandType.Text
            };
            comando_borrar_cortes.Parameters.AddWithValue("@p1", orden.Numero);
            comando_borrar_cortes.ExecuteNonQuery();

            //GUARDAR LOS NUEVOS CORTES.
            foreach (var corte in orden.Cortes!)
            {
                using SqlCommand comando_insert_cortes = new()
                {
                    Connection = conn,
                    CommandText = "INSERT INTO cortes (num,width,lenght,msi,orden) VALUES(@p1,@p2,@p3,@p4,@p5)",
                    CommandType = CommandType.Text
                };
                comando_insert_cortes.Parameters.AddWithValue("@p1", corte.Numero);
                comando_insert_cortes.Parameters.AddWithValue("@p2", corte.Width);
                comando_insert_cortes.Parameters.AddWithValue("@p3", corte.Length);
                comando_insert_cortes.Parameters.AddWithValue("@p4", corte.Msi);
                comando_insert_cortes.Parameters.AddWithValue("@p5", corte.Orden);
                comando_insert_cortes.ExecuteNonQuery();
            }
            //BORRAR LOS ROLLOS CORTADOS ANTERIORES.
            using SqlCommand comando_borrar_rollos = new()
            {
                Connection = conn,
                CommandText = "DELETE FROM rolls_details WHERE numero=@p1",
                CommandType = CommandType.Text
            };
            comando_borrar_rollos.Parameters.AddWithValue("@p1", orden.Numero);
            comando_borrar_rollos.ExecuteNonQuery();

            //INGRESAR LOS NUEVOS ROLLOS CORTADOS
            foreach (var item in orden.rollos!)
            {
                using SqlCommand comando_rolls = new()
                {
                    Connection = conn,
                    CommandText = "INSERT INTO rolls_details (numero,roll_number,product_id,product_name,roll_id,width,large,msi,unique_code,splice,code_person,status,ubic,ratio,rollid_oculto,despacho,fecha,fecha_despacho) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,'nt',0,'','',GETDATE(),GETDATE())",
                    CommandType = CommandType.Text
                };
                comando_rolls.Parameters.AddWithValue("@p1", item.Numero);
                comando_rolls.Parameters.AddWithValue("@p2", item.RollNumber);
                comando_rolls.Parameters.AddWithValue("@p3", item.Product_Id);
                comando_rolls.Parameters.AddWithValue("@p4", item.Product_Name);
                comando_rolls.Parameters.AddWithValue("@p5", item.Roll_Id);
                comando_rolls.Parameters.AddWithValue("@p6", item.Width);
                comando_rolls.Parameters.AddWithValue("@p7", item.Length);
                comando_rolls.Parameters.AddWithValue("@p8", item.Msi);
                comando_rolls.Parameters.AddWithValue("@p9", item.UniqueCode);
                comando_rolls.Parameters.AddWithValue("@p10", item.Splice);
                comando_rolls.Parameters.AddWithValue("@p11", item.Code_Person);
                comando_rolls.Parameters.AddWithValue("@p12", item.Status);
                comando_rolls.ExecuteNonQuery();

            }






            conn.Close();
        }
        catch (SqlException ex)
        {
            MessageBox.Show("Error al modificar la orden de corte...error code: " + ex);
        }
    }

    public void RollosCortadosDispobnibles(string oc)
    {
        try
        {
            using SqlConnection conn = new(StringConnex);
            conn.Open();
            using SqlCommand comando = new()
            {
                Connection = conn,
                CommandText = "UPDATE rolls_details SET disponible=1 WHERE numero=@p1",
                CommandType = CommandType.Text
            };
            comando.Parameters.AddWithValue("@p1", oc);
            comando.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            MessageBox.Show("Error al modificar la orden de corte...error code: " + ex);
        }
    }
}
