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
        }
        public async Task<DataSet> LoadData() 
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


            await LoadTableHeaderMateriaPrima();
            await LoadTableDetailsMateriaPrima();
            await LoadTableProveedores();
            await LoadTableTransportista();
            await LoadProducts();
            await SetRelationsTables();
            return Ds;
        }


        public async Task LoadTableHeaderMateriaPrima()
        {
            await ServiceData.LoadTable(QUERY_COMMANDS("master"));
        }
        public async Task LoadTableDetailsMateriaPrima()
        {
            await ServiceData.LoadTable(QUERY_COMMANDS("details"));
        }
        public async Task LoadProducts()
        {
            await ServiceData.LoadTable(QUERY_COMMANDS("products"));
        }
      
        public async Task LoadTableProveedores()
        {
            await ServiceData.LoadTable(QUERY_COMMANDS("prov"));
        }
        public async Task LoadTableTransportista()
        {
          await ServiceData.LoadTable(QUERY_COMMANDS("transport"));
        }
        private ObjectQuery QUERY_COMMANDS(string table)
        {
            switch (table)
            {
                case "products":
                        return new ObjectQuery()
                        {
                            Query = R.SQL_STRING_QUERY.SELECT_QUERY_PRODUCTS,
                            Message = R.ERROR_MESSAGE_SYSTEM.ERROR_LOAD_PRODUCTS,
                            Adapter = DaProducts,
                            DataTableName = "Dtproducts",
                            DataSet = Ds
                        };
                case "master":     
                    return new ObjectQuery()
                    {
                            Query = R.SQL_STRING_QUERY.SELECT_QUERY_MP_MASTER,
                            Message = R.ERROR_MESSAGE_SYSTEM.ERROR_LOAD_MP_MASTER,
                            Adapter = DaMateria,
                            DataTableName = "DtMateria",
                            DataSet = Ds
                    };
                case "details":
                    return new ObjectQuery()
                    {
                        Query = R.SQL_STRING_QUERY.SELECT_QUERY_MP_DETAILS,
                        Message = R.ERROR_MESSAGE_SYSTEM.ERROR_MP_DETAILS,
                        Adapter = DaDetalle,
                        DataTableName = "DtDetalle",
                        DataSet = Ds
                    };
                case "prov":
                    return new ObjectQuery()
                    {
                        Query = R.SQL_STRING_QUERY.SELECT_QUERY_PROVEEDORES,
                        Message = R.ERROR_MESSAGE_SYSTEM.ERROR_MP_PROVEEDORES,
                        Adapter = DaProvider,
                        DataTableName = "DtProvider",
                        DataSet = Ds
                    };
                case "transport":
                    return new ObjectQuery()
                    {
                        Query = R.SQL_STRING_QUERY.SELECT_QUERY_TRANSPORTISTA ,
                        Message = R.ERROR_MESSAGE_SYSTEM.ERROR_MP_TRANSPORT,
                        Adapter = DaTransport,
                        DataTableName = "DtTransport",
                        DataSet = Ds
                    };
                default:
                    {
                        throw new ArgumentException($"Invalid table name at create object query : {table}");
                    }
            }
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
            //relacion master-details.
            DataColumn ParentCol0 = Ds.Tables["DtMateria"]!.Columns["numero"]!;
            DataColumn ChildCol0 = Ds.Tables["DtDetalle"]!.Columns["numero"]!;
            DataRelation master_details = new("MASTER_DETAILS", ParentCol0, ChildCol0, false);
            Ds.Relations.Add(master_details);
            //relacion details-products.
            DataColumn ParentCol1 = Ds.Tables["Dtproducts"]!.Columns["product_id"]!;
            DataColumn ChildCol1 = Ds.Tables["DtDetalle"]!.Columns["product_id"]!;
            DataRelation details_products = new("DETAILS_PRODUCTS", ParentCol1, ChildCol1, false);
            Ds.Relations.Add(details_products);
            Ds.Tables["DtDetalle"]!.Columns.Add("product_name", Type.GetType("System.String")!, "parent(DETAILS_PRODUCTS).Product_Name");
            //relacion provedores-master.
            //DataColumn ParentCol2 = Ds.Tables["Dtprovider"]!.Columns["proveedor_id"]!;
            //DataColumn ChildCol2 = Ds.Tables["DtMateria"]!.Columns["prov_id"]!;
            //DataRelation master_provider = new("MASTER_DETAILS", ParentCol2, ChildCol2, false);
            //Ds.Relations.Add(master_provider);
            //Ds.Tables["DtMateria"]!.Columns.Add("product_name", Type.GetType("System.String")!, "parent(DETAILS_PRODUCTS).Product_Name");
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
    }
}
