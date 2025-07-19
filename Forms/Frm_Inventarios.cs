using Ritrama2025.Forms.Otros;
using Ritrama2025.Services.InventarioService;   

namespace Ritrama2025.Forms
{
    public partial class Frm_Inventarios : Form
    {
        IInventarioService InventarioService { get; set; }
        public Frm_Inventarios(IInventarioService inventarioService)
        {
            InventarioService = inventarioService;
            InitializeComponent();
        }

        private void Frm_Inventarios_Load(object sender, EventArgs e)
        {
            //llenar la lista de las columnas.
            var columnas = new List<ColumnaType>()
            {
                new ColumnaType { Description = "Product Id   ", Index = 1, TipoValor = "string  " },
                new ColumnaType { Description = "Product Name ", Index = 2, TipoValor = "string  " },
                new ColumnaType { Description = "Width        ", Index = 3, TipoValor = "decimal " },
                new ColumnaType { Description = "Length       ", Index = 4, TipoValor = "decimal " },
                new ColumnaType { Description = "Msi          ", Index = 5, TipoValor = "decimal " }
            };
            ListColumns.DataSource = columnas;
            ListColumns.DisplayMember = "InfoParaDisplay";
            ListColumns.ValueMember = "Index";
        }

        private void btn_load_sheet_Click(object sender, EventArgs e)
        {
            //validacion del tipo de producto
            if (!rad_master.Checked && !rad_graphics.Checked)
            {
                MessageBox.Show("Debe escoger el tipo de producto primero...");
                return;
            }
            //open dialog para seleccionar el archivo de excel
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm",
                Title = "Select an Excel File"
            };
            dialog.ShowDialog();

            string filePath = dialog.FileName;
            string fileName = Path.GetFileName(filePath);

            txt_file_name.Text = fileName;
            txt_file_path.Text = filePath;
        }

        private void btn_import_excel_Click(object sender, EventArgs e)
        {
            Frm_Imports importData = new Frm_Imports(this.InventarioService)
            {
              FileName = txt_file_name.Text,
              PathFileName = txt_file_path.Text
            };
            importData.ShowDialog();
        }
    }
}

public class ColumnaType 
{
    public string Description { get; set; } = null!;
    public int Index { get; set; }
    public string TipoValor { get; set; } = null!;

    public string InfoParaDisplay
    {
        get
        {
            // PadRight alinea el texto agregando espacios a la derecha.
            // Ajusta el número (25) según el ancho que necesites para la primera columna.
            return $"{Description}{TipoValor}{Index}";
        }
    }
}
