using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Ritrama2025.Models;
using Ritrama2025.Services.CommonData;
using System.Data;

namespace Ritrama2025.Services.MateriaPrima
{
    public class ServiceMateriaPrima : IServiceMateriaPrima
    {
        public IConfiguration Config { get; }
        private readonly IServiceCommonData ServiceData;
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
        public SqlDataAdapter DaPerson = new();
        public DataTable DtPerson = new();

        public readonly Dictionary<string, (string query, string message, SqlDataAdapter adapter, string dataTableName)> mapTables;

        public ServiceMateriaPrima(IConfiguration Config, IServiceCommonData ServiceData)
        {
            this.Config = Config;
            //Carga el string de Connexion de la aplicacion.
            if (Config != null)
            {
                var ambiente = Config["Ambiente"] ?? R.ENVIRONMET.DESARROLLO;
                StringConnex = Config.GetSection("ConnectionStringsEnvironment")[ambiente]!;
            }
            //Injecta el servicio de datos.
            this.ServiceData = ServiceData;

            mapTables = new Dictionary<string, (string, string, SqlDataAdapter, string)>
            {
                ["master"] = (R.SQL_STRING_QUERY.SELECT_QUERY_MP_MASTER, R.ERROR_MESSAGE_SYSTEM.ERROR_LOAD_MP_MASTER, DaMateria, "DtMateria"),
                ["details"] = (R.SQL_STRING_QUERY.SELECT_QUERY_MP_DETAILS, R.ERROR_MESSAGE_SYSTEM.ERROR_MP_DETAILS, DaDetalle, "DtDetalle"),
                ["products"] = (R.SQL_STRING_QUERY.SELECT_QUERY_PRODUCTS, R.ERROR_MESSAGE_SYSTEM.ERROR_LOAD_PRODUCTS, DaProducts, "Dtproducts"),
                ["prov"] = (R.SQL_STRING_QUERY.SELECT_QUERY_PROVEEDORES, R.ERROR_MESSAGE_SYSTEM.ERROR_MP_PROVEEDORES, DaProvider, "DtProvider"),
                ["transport"] = (R.SQL_STRING_QUERY.SELECT_QUERY_TRANSPORTISTA, R.ERROR_MESSAGE_SYSTEM.ERROR_MP_TRANSPORT, DaTransport, "DtTransport"),
                ["person"] = (R.SQL_STRING_QUERY.SELECT_QUERY_PERSON, R.ERROR_MESSAGE_SYSTEM.ERROR_LOAD_PERSON, DaPerson, "DtPerson")
            };
        }
        public async Task LoadTableByName(string tableName)
        {
            await ServiceData.LoadTable(QUERY_COMMANDS(tableName));
        }
        public async Task<DataSet> LoadData()
        {
            LimpiarDataSet();
            await LoadTableHeaderMateriaPrima();
            await LoadTableDetailsMateriaPrima();
            await LoadTableProveedores();
            await LoadTableTransportista();
            await LoadProducts();
            await LoadPerson();
            await SetRelationsTables();
            return Ds;
        }
        public async Task LoadTableHeaderMateriaPrima() => await LoadTableByName("master");
        public async Task LoadTableDetailsMateriaPrima() => await LoadTableByName("details");
        public async Task LoadProducts() => await LoadTableByName("products");
        public async Task LoadTableProveedores() => await LoadTableByName("prov");
        public async Task LoadTableTransportista() => await LoadTableByName("transport");
        public async Task LoadPerson() => await LoadTableByName("person");
        private ObjectQuery QUERY_COMMANDS(string table)
        {
            if (!mapTables.TryGetValue(table, out var props))
                throw new ArgumentException($"Invalid table name at create object query: {table}");

            return new ObjectQuery
            {
                Query = props.query,
                Message = props.message,
                Adapter = props.adapter,
                DataTableName = props.dataTableName,
                DataSet = Ds
            };
        }
        public async Task SetRelationsTables()
        {
            await Task.Run(() =>
            {
                CreateRelation();
            });
        }
        private void CreateRelation()
        {
            //relacion details-products.
            DataColumn ParentCol1 = Ds.Tables["Dtproducts"]!.Columns["product_id"]!;
            DataColumn ChildCol1 = Ds.Tables["DtDetalle"]!.Columns["product_id"]!;
            DataRelation details_products = new("DETAILS_PRODUCTS", ParentCol1, ChildCol1, false);
            Ds.Relations.Add(details_products);
            Ds.Tables["DtDetalle"]!.Columns.Add("product_name", Type.GetType("System.String")!, "parent(DETAILS_PRODUCTS).Product_Name");
            //relacion provedores-master.
            DataColumn ParentCol2 = Ds.Tables["Dtprovider"]!.Columns["proveedor_id"]!;
            DataColumn ChildCol2 = Ds.Tables["DtMateria"]!.Columns["proveedor_id"]!;
            DataRelation master_provider = new("MASTER_PROVIDER", ParentCol2, ChildCol2, false);
            Ds.Relations.Add(master_provider);
            Ds.Tables["DtMateria"]!.Columns.Add("proveedor_name", Type.GetType("System.String")!, "parent(MASTER_PROVIDER).Proveedor_Name");
            //relacion transportista-master.
            DataColumn ParentCol3 = Ds.Tables["DtTransport"]!.Columns["transport_id"]!;
            DataColumn ChildCol3 = Ds.Tables["DtMateria"]!.Columns["transport_id"]!;
            DataRelation master_transport = new("MASTER_TRANSPORT", ParentCol3, ChildCol3, false);
            Ds.Relations.Add(master_transport);
            Ds.Tables["DtMateria"]!.Columns.Add("transport_name", Type.GetType("System.String")!, "parent(MASTER_TRANSPORT).Transport_Name");
            //relacion transportista-master.
            DataColumn ParentCol4 = Ds.Tables["DtPerson"]!.Columns["person_id"]!;
            DataColumn ChildCol4 = Ds.Tables["DtMateria"]!.Columns["person_id"]!;
            DataRelation master_person = new("MASTER_PERSON", ParentCol4, ChildCol4, false);
            Ds.Relations.Add(master_person);
            Ds.Tables["DtMateria"]!.Columns.Add("person_name", Type.GetType("System.String")!, "parent(MASTER_PERSON).Person_Name");
            // relacion master-details.
            DataColumn ParentCol0 = Ds.Tables["Dtmateria"]!.Columns["numero"]!;
            DataColumn ChildCol0 = Ds.Tables["DtDetalle"]!.Columns["numero"]!;
            DataRelation master_details = new("FK_MASTER_DETAILS", ParentCol0, ChildCol0, false);
            Ds.Relations.Add(master_details);
        }
        public int LoadConsecOrdenMateria(string filtro)
        {
            return ServiceData.GetConsecutive(filtro);
        }
        public bool AddOrdenMateriaPrima(OrdenRecepcion orden)
        {
            throw new NotImplementedException();
        }
        public bool CloseOrdenMateriaPrima(string orden)
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

        private void LimpiarDataSet()
        {
            //limpiar el dataset cualdo se carga el form varias veces.
            if (Ds.Tables.Count > 0)
            {
                DataTable tabla = Ds.Tables["DtMateria"]!;

                // Eliminar todas las restricciones del master
                var tempConstraints = tabla.Constraints.Cast<Constraint>().ToList();
                foreach (var constraint in tempConstraints)
                {
                    tabla.Constraints.Remove(constraint);
                }
                //eliminar las relaciones
                Ds.Relations.Clear();
                Ds.Tables.Clear();
                Ds.Clear();
                Ds.AcceptChanges();
            }
        }

        public bool GuardarOrden(OrdenMP orden)
        {
            using SqlConnection conn = new(StringConnex);
            conn.Open();
            using var transaction = conn.BeginTransaction();
            try
            {
                //Guardo el header de la Orden
                using SqlCommand comando = new()
                {
                    Connection = conn,
                    Transaction = transaction,
                    CommandType = CommandType.Text,
                    CommandText = "INSERT INTO OrdenMateria (numero,fecha_pro,fecha_recepcion,orden_compra,proveedor_id,persona_respons,notas,transport_id,guia_import,lote,doc_embarque,anulado,CloseDocument,total_cantidad,person_id,estado,fecha_hora_close) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)"
                };
                comando.Parameters.AddWithValue("@p1", orden.Numero);
                comando.Parameters.AddWithValue("@p2", orden.Fecha_Produccion);
                comando.Parameters.AddWithValue("@p3", orden.Fecha_Recepcion);
                comando.Parameters.AddWithValue("@p4", orden.Orden_Compra);
                comando.Parameters.AddWithValue("@p5", orden.Proveedor_id);
                comando.Parameters.AddWithValue("@p6", orden.Person_Name);
                comando.Parameters.AddWithValue("@p7", orden.Notas);
                comando.Parameters.AddWithValue("@p8", orden.Transport_id);
                comando.Parameters.AddWithValue("@p9", orden.Guia);
                comando.Parameters.AddWithValue("@p10", orden.Lote);
                comando.Parameters.AddWithValue("@p11", orden.Numero_Embarque);
                comando.Parameters.AddWithValue("@p12", false);
                comando.Parameters.AddWithValue("@p13", orden.CloseDocument);
                comando.Parameters.AddWithValue("@p14", orden.Renglones);
                comando.Parameters.AddWithValue("@p15", orden.Person_Id);
                comando.Parameters.AddWithValue("@p16", "open");
                comando.Parameters.AddWithValue("@p17", DateTime.Now);
                comando.ExecuteNonQuery();

                //guardar el detalle de la orden.
                foreach (var item in orden.Items)
                {
                    SqlCommand comandoItems = new()
                    {
                        Connection = conn,
                        Transaction = transaction,
                        CommandText = "INSERT INTO ItemsMateria (numero,product_id,type,cant_pedido,cant_real,width,length,msi,rollid,splice,ubicacion,core,largo_restante) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@restante)"
                    };
                    comandoItems.Parameters.AddWithValue("@p1", orden.Numero);
                    comandoItems.Parameters.AddWithValue("@p2", item.Product_Id);
                    comandoItems.Parameters.AddWithValue("@p3", item.Product_Type);
                    comandoItems.Parameters.AddWithValue("@p4", item.Cantidad_Pedido);
                    comandoItems.Parameters.AddWithValue("@p5", item.Cantidad_Real);
                    comandoItems.Parameters.AddWithValue("@p6", item.Width);
                    comandoItems.Parameters.AddWithValue("@p7", item.Length);
                    comandoItems.Parameters.AddWithValue("@p8", item.Msi);
                    comandoItems.Parameters.AddWithValue("@p9", item.RollId);
                    comandoItems.Parameters.AddWithValue("@p10", item.Splice);
                    comandoItems.Parameters.AddWithValue("@p11", item.Ubicacion);
                    comandoItems.Parameters.AddWithValue("@p12", item.Core);
                    comandoItems.Parameters.AddWithValue("@restante", item.Length);

                    comandoItems.ExecuteNonQuery();
                }
                transaction.Commit();
                MessageBox.Show("se guardo correctamente...");
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("error al tratar de grabar la orden..." + ex);
                return false;
            }
        }

        public int LoadConsecOrden(string filtro)
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

        public bool UpdateConsecOrden(string NumConsec)
        {
            try
            {
                SqlConnection conn = new(StringConnex);
                conn.Open();
                SqlCommand comando = new()
                {
                    Connection = conn,
                    CommandText = "update control set par1=@p1 where filter='CMP'",
                    CommandType = CommandType.Text
                };
                SqlParameter p1 = new("@p1", NumConsec);
                comando.Parameters.Add(p1);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al actualizar el consecutivo de la orden MATERIA PRIMA. Codigo de Error : " + ex.Message);
                return false;
            }
        }

        public bool AnularOrden(string orden)
        {
            try
            {
                SqlConnection conn = new(StringConnex);
                conn.Open();
                SqlCommand comando = new()
                {
                    Connection = conn,
                    CommandText = "update OrdenMateria SET Anulado=1 where numero=@p1",
                    CommandType = CommandType.Text
                };
                SqlParameter p1 = new("@p1", orden);
                comando.Parameters.Add(p1);
                comando.ExecuteNonQuery();
                MessageBox.Show("Orden Anulada correctamente.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al tratar de Anular el documento...[Codigo de Error:]" + ex.Message);
                return false;
            }
        }


        public bool CloseOrder(string orden)
        {
            try
            {
                SqlConnection conn = new(StringConnex);
                conn.Open();
                SqlCommand comando = new()
                {
                    Connection = conn,
                    CommandText = "update OrdenMateria SET CloseDocument=1 where numero=@p1",
                    CommandType = CommandType.Text
                };
                SqlParameter p1 = new("@p1", orden);
                comando.Parameters.Add(p1);
                comando.ExecuteNonQuery();
                MessageBox.Show("Orden cerrada correctamente.");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al tratar de cerrar el documento...[Codigo de Error:]" + ex.Message);
                return false;
            }
        }

        public bool UpDateLogsNotes(string orden, string logText)
        {
            try
            {
                SqlConnection conn = new(StringConnex);
                conn.Open();
                SqlCommand comando = new()
                {
                    Connection = conn,
                    CommandText = "update OrdenMateria SET notas = CONCAT(ISNULL(notas,''),CHAR(13),CHAR(10),@p2) where numero=@p1",
                    CommandType = CommandType.Text
                };
                SqlParameter p1 = new("@p1", orden);
                SqlParameter p2 = new("@p2", logText);
                comando.Parameters.Add(p1);
                comando.Parameters.Add(p2);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al tratar de actualizar los logs del documentos...[Codigo de Error:]" + ex.Message);
                return false;
            }
        }
    }      
}
