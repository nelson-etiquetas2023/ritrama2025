using Ritrama2025.Services.MateriaPrima;
using System.Data;

namespace Ritrama2025.Forms
{
    public partial class FrmMateriaPrima : Form
    {
        readonly ServiceMateriaPrima servicio = new();
        public DataSet Ds = new();
        readonly BindingSource Bs = [];
        readonly BindingSource BsDetalle = [];
        public FrmMateriaPrima()
        {
            InitializeComponent();
        }

        private void FrmMateriaPrima_Load(object sender, EventArgs e)
        {
            LoadDataAsync();
            BindDataSource();
            StyleGridColumns();
            BindingControls();
        }
        private void BindDataSource() 
        {
            //Configuracion del BindingSource.
            Bs.DataSource = Ds;
            Bs.DataMember = "DtMateria";
            Bs.Sort = "numero DESC";
            //Bindingsource para el detalle de los productos.
        }
        private void LoadDataAsync() 
        {
            //carga los datos de la base dfe datos.
            var task = Task.Run(async () =>
            {
                return await servicio.LoadData();
            });
            Ds = task.Result;
        }

        private void BindingControls() 
        {
            //trabajar con los enlaces a datos.
            txt_numeroOrden.DataBindings.Add("Text", Bs, "numero");
            txt_OrdenCompra.DataBindings.Add("Text", Bs, "orden_compra");
            txt_prov_Id.DataBindings.Add("Text", Bs, "prov_id");
            txt_fecha_produccion.DataBindings.Add("Text", Bs, "fecha_pro");
            txt_fecha_recepcion.DataBindings.Add("Text", Bs, "fecha_recepcion");
            txt_recepcionista.DataBindings.Add("Text", Bs, "persona_respons");
            txt_transport_id.DataBindings.Add("Text", Bs, "transport_id");
            txt_guia.DataBindings.Add("Text", Bs, "guia_import");
            txt_lote.DataBindings.Add("Text", Bs, "lote");
            txt_embarque.DataBindings.Add("Text", Bs, "doc_embarque");
            txt_total_cantidad.DataBindings.Add("Text", Bs, "total_cantidad");
            txt_data_document.DataBindings.Add("Text", Bs, "fecha_hora_close");
            txt_notas.DataBindings.Add("Text", Bs, "notas");
            chk_anulado.DataBindings.Add("Checked", Bs, "anulado");
        }
        private void StyleGridColumns() 
        {
            GridItems.AutoGenerateColumns = false;
            //Configurar las columnas del detalle de los productos.
            ADD_COLUMN_GRID("product_id", 70, "Product Id.", "product_id", GridItems);
            ADD_COLUMN_GRID("product_name", 200, "Product Name.", "product_name", GridItems);
            ADD_COLUMN_GRID("product_Type", 70, "Tipo", "product_type", GridItems);
            ADD_COLUMN_GRID("width", 75, "Width [Inch.]", "width", GridItems);
            ADD_COLUMN_GRID("length", 75, "Length [Pies]", "length", GridItems);
            ADD_COLUMN_GRID("msi", 75, "Msi", "msi", GridItems);
            ADD_COLUMN_GRID("rollid", 70, "Roll-Id.", "rollid", GridItems);
            ADD_COLUMN_GRID("ubic", 70, "Ubica.", "ucib", GridItems);
            ADD_COLUMN_GRID("splice", 65, "Splice", "splice", GridItems);
            ADD_COLUMN_GRID("core", 65, "Core", "core", GridItems);
            ADD_COLUMN_GRID("cantidad", 65, "Cantidad Pedido", "cantidad", GridItems);
            ADD_COLUMN_GRID("cant_real", 65, "Cantidad Real", "cant_real", GridItems);
        }

        private static void ADD_COLUMN_GRID(string name, int size, string title, string field_bd, DataGridView grid)
        {
            DataGridViewTextBoxColumn col = new()
            {
                Name = name,
                Width = size,
                HeaderText = title,
                DataPropertyName = field_bd,
            };
            grid.Columns.Add(col);
        }
    }
}
