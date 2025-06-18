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

        public readonly Dictionary<string, (string query, string message, SqlDataAdapter adapter, string dataTableName)> mapTables;


        public ServiceMateriaPrima(IConfiguration Config, IServiceCommonData ServiceData)
        {
            this.Config = Config;
            //Carga el string de Connexion de la aplicacion.
            if (Config != null)
            {
                StringConnex = Convert.ToString(Config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value)!;
            }
            //Injecta el servicio de datos.
            this.ServiceData = ServiceData;

            mapTables = new Dictionary<string, (string, string, SqlDataAdapter, string)>
            {
                ["master"] = (R.SQL_STRING_QUERY.SELECT_QUERY_MP_MASTER, R.ERROR_MESSAGE_SYSTEM.ERROR_LOAD_MP_MASTER, DaMateria, "DtMateria"),
                ["details"] = (R.SQL_STRING_QUERY.SELECT_QUERY_MP_DETAILS, R.ERROR_MESSAGE_SYSTEM.ERROR_MP_DETAILS, DaDetalle, "DtDetalle"),
                ["products"] = (R.SQL_STRING_QUERY.SELECT_QUERY_PRODUCTS, R.ERROR_MESSAGE_SYSTEM.ERROR_LOAD_PRODUCTS, DaProducts, "Dtproducts"),
                ["prov"] = (R.SQL_STRING_QUERY.SELECT_QUERY_PROVEEDORES, R.ERROR_MESSAGE_SYSTEM.ERROR_MP_PROVEEDORES, DaProvider, "DtProvider"),
                ["transport"] = (R.SQL_STRING_QUERY.SELECT_QUERY_TRANSPORTISTA, R.ERROR_MESSAGE_SYSTEM.ERROR_MP_TRANSPORT, DaTransport, "DtTransport")
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
            await SetRelationsTables();
            return Ds;
        }
        public async Task LoadTableHeaderMateriaPrima() => await LoadTableByName("master");
        public async Task LoadTableDetailsMateriaPrima() => await LoadTableByName("details");
        public async Task LoadProducts() => await LoadTableByName("products");
        public async Task LoadTableProveedores() => await LoadTableByName("prov");
        public async Task LoadTableTransportista() => await LoadTableByName("transport");
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
            DataColumn ChildCol2 = Ds.Tables["DtMateria"]!.Columns["prov_id"]!;
            DataRelation master_provider = new("MASTER_PROVIDER", ParentCol2, ChildCol2, false);
            Ds.Relations.Add(master_provider);
            Ds.Tables["DtMateria"]!.Columns.Add("proveedor_name", Type.GetType("System.String")!, "parent(MASTER_PROVIDER).Proveedor_Name");
            //relacion transportista-master.
            DataColumn ParentCol3 = Ds.Tables["DtTransport"]!.Columns["transport_id"]!;
            DataColumn ChildCol3 = Ds.Tables["DtMateria"]!.Columns["transport_id"]!;
            DataRelation master_transport = new("MASTER_TRANSPORT", ParentCol3, ChildCol3, false);
            Ds.Relations.Add(master_transport);
            Ds.Tables["DtMateria"]!.Columns.Add("transport_name", Type.GetType("System.String")!, "parent(MASTER_TRANSPORT).Transport_Name");
            // relacion master-details.
            DataColumn ParentCol0 = Ds.Tables["Dtmateria"]!.Columns["numero"]!;
            DataColumn ChildCol0 = Ds.Tables["DtDetalle"]!.Columns["numero"]!;
            DataRelation master_details = new("FK_MASTER_DETAILS", ParentCol0, ChildCol0, false);
            Ds.Relations.Add(master_details);
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
    }
}
