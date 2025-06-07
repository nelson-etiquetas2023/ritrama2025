using Ritrama2025.Services.MateriaPrima;
using System.Data;


namespace Ritrama2025.Forms
{
    public partial class FrmMateriaPrima : Form
    {
        readonly ServiceMateriaPrima servicio = new();
        public DataSet Ds = new();
        readonly BindingSource Bs = [];


        public FrmMateriaPrima()
        {
            InitializeComponent();
        }

        private void FrmMateriaPrima_Load(object sender, EventArgs e)
        {
            //carga los datos de la base dfe datos.
            var task = Task.Run(async () =>
            {
                return await servicio.LoadData(); 
            });
            Ds = task.Result;
            //Configuracion del BindingSource.
            Bs.DataSource = Ds;
            Bs.DataMember = "DtMateria";
            Bs.Sort = "numero DESC";




            //define las columnas del grid.
            StyleGridColumns();
            //trabajar con los enlaces a datos.
            txt_numeroOrden.DataBindings.Add("Text", Bs, "numero");
        }

        private void StyleGridColumns() 
        {
            GridItems.AutoGenerateColumns = false;
            //Configurar las columnas del detalle de los productos.
            ADD_COLUMN_GRID("product_id", 70, "Product Id.", "product_id", GridItems);
            ADD_COLUMN_GRID("product_name", 200, "Product Name.", "product_name", GridItems);
            ADD_COLUMN_GRID("product_Type", 70, "Tipo", "product_type", GridItems);
            ADD_COLUMN_GRID("width", 80, "Width [Inch.]", "width", GridItems);
            ADD_COLUMN_GRID("length", 80, "Length [Pies]", "length", GridItems);
            ADD_COLUMN_GRID("msi", 80, "Msi", "msi", GridItems);
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
