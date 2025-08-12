using Ritrama2025.Models;
using Ritrama2025.Forms.Otros;
using Ritrama2025.Services.CommonService;
using Ritrama2025.Services.InventarioService;
using Ritrama2025.Services.ProduccionService;
using System.Data;
using Ritrama2025.Services.ExportData;


namespace Ritrama2025.Forms
{
    public partial class Frm_Inventarios : Form
    {
        IInventarioService InventarioService { get; set; }
        IProduccionService ProduccionService { get; set; }
        IExportDataService ExportDataService { get; set; }
        private DataTable? DtMaster { get; set; }
        private DataView Dv { get; set; } = new();
        public Frm_Inventarios(IInventarioService inventarioService, IProduccionService produccionService, IExportDataService exportDataService)
        {
            InventarioService = inventarioService;
            ProduccionService = produccionService;
            ExportDataService = exportDataService;
            InitializeComponent();
        }

        private void Frm_Inventarios_Load(object sender, EventArgs e)
        {
            DefColumnsSheetExcel();
            BindingMasterGrid();
        }
        private List<ProductMAP> CreateListaMasterRolls()
        {
            List<ProductMAP> lista = [];
            for (int i = 0; i <= GridMaster.Rows.Count - 1; i++)
            {
                ProductMAP master = new()
                {
                    ItemNo = i + 1,
                    Product_Id = GridMaster.Rows[i].Cells["product_id"].Value?.ToString() ?? string.Empty,
                    Product_Name = GridMaster.Rows[i].Cells["product_name"].Value?.ToString() ?? string.Empty,
                    Rollid = GridMaster.Rows[i].Cells["roll_id"].Value?.ToString() ?? string.Empty,
                    Width = Convert.ToDouble(GridMaster.Rows[i].Cells["width"].Value),
                    Length = Convert.ToDouble(GridMaster.Rows[i].Cells["length"].Value),
                    Length_Consumido = Convert.ToDouble(GridMaster.Rows[i].Cells["length_consumido"].Value),
                    Length_Restante = Convert.ToDouble(GridMaster.Rows[i].Cells["length_restante"].Value),
                    Estado = GridMaster.Rows[i].Cells["estado"].Value?.ToString() ?? string.Empty,
                    //Msi = Convert.ToDouble(GridMaster.Rows[i].Cells["msi"].Value),
                    Ubic = GridMaster.Rows[i].Cells["ubic"].Value?.ToString() ?? string.Empty,
                    Cant = 1, // Assuming each row represents one roll
                    Recepcion = GridMaster.Rows[i].Cells["fecha"].Value?.ToString() ?? string.Empty,
                    Fecha_Fabricacion = Convert.ToDateTime(GridMaster.Rows[i].Cells["fecha_pro"].Value),
                    Fecha_Llegada = DateTime.Now, // Assuming current date for arrival
                };
                lista.Add(master);
            }
            return lista;
        }
        private void BindingMasterGrid()
        {
            GridMaster.AutoGenerateColumns = false;
            CommonService.ADD_COLUMN_GRID("product_id", 80, "Prod. Id", "part_number", GridMaster);
            CommonService.ADD_COLUMN_GRID("product_name", 250, "Product Name", "product_name", GridMaster);
            CommonService.ADD_COLUMN_GRID("roll_id", 100, "Rollid", "roll_id", GridMaster);
            CommonService.ADD_COLUMN_GRID("width", 80, "Width", "width", GridMaster);
            CommonService.ADD_COLUMN_GRID("length", 80, "Length", "lenght", GridMaster);
            CommonService.ADD_COLUMN_GRID("length_consumido", 80, "Consumido", "largo_consumido", GridMaster);
            CommonService.ADD_COLUMN_GRID("length_restante", 80, "Restante", "largo_restante", GridMaster);
            CommonService.ADD_COLUMN_GRID("estado", 80, "Estado", "estado", GridMaster);
            CommonService.ADD_COLUMN_GRID("fecha_pro", 80, "Produccion", "fecha_pro", GridMaster);
            CommonService.ADD_COLUMN_GRID("fecha", 80, "Recep.", "fecha", GridMaster);
            CommonService.ADD_COLUMN_GRID("splice", 80, "Splice", "splice", GridMaster);
            CommonService.ADD_COLUMN_GRID("ubic", 80, "Ubic. ", "ubicacion", GridMaster);
            CommonService.ADD_COLUMN_GRID("tipo_mov", 80, "Tipo", "tipo_mov", GridMaster);
        }
        private async void Btn_reload_Click(object sender, EventArgs e)
        {
            string activeTabtext = tabControl1.SelectedTab!.Text;
            if (activeTabtext == "Master")
            {
                DtMaster = await Task.Run(() => InventarioService.LoadMasterInventario());
                Dv = DtMaster!.DefaultView;
                ContarRegistros();
                GridMaster.DataSource = Dv;
            }
            if (activeTabtext == "Graphics")
            {
                MessageBox.Show("Inventario de Graphics");
            }
            if (activeTabtext == "Hojas")
            {
                MessageBox.Show("Inventario de Hojas");
            }
        }
        private void ContarRegistros()
        {
            COUNT_ROWS.Text = Dv.Count.ToString() + " Registros Encontrados." ?? "0 Registros Encontrados";
        }
        private void DefColumnsSheetExcel()
        {
            //llenar la lista de las columnas.
            var columnas = new List<ColumnaType>()
            {
                new() { Description = "Product Id   ", Index = 1, TipoValor = "string  " },
                new() { Description = "Product Name ", Index = 2, TipoValor = "string  " },
                new() { Description = "Width        ", Index = 3, TipoValor = "decimal " },
                new() { Description = "Length       ", Index = 4, TipoValor = "decimal " },
                new() { Description = "Msi          ", Index = 5, TipoValor = "decimal " }
            };
            ListColumns.DataSource = columnas;
            ListColumns.DisplayMember = "InfoParaDisplay";
            ListColumns.ValueMember = "Index";
        }
        private void Btn_load_sheet_Click(object sender, EventArgs e)
        {
            //validacion del tipo de producto
            if (!rad_master.Checked && !rad_graphics.Checked)
            {
                MessageBox.Show("Debe escoger el tipo de producto primero...");
                return;
            }
            //open dialog para seleccionar el archivo de excel
            OpenFileDialog dialog = new()
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
        private void Btn_import_excel_Click(object sender, EventArgs e)
        {
            Frm_Imports importData = new(this.InventarioService)
            {
                FileName = txt_file_name.Text,
                PathFileName = txt_file_path.Text
            };
            importData.ShowDialog();
        }
        private void ToolStripButton1_Click(object sender, EventArgs e)
        {

        }
        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            if (rad_rollid.Checked)
            {
                Dv.RowFilter = "roll_id like '%" + txt_buscar.Text + "%'";
            }
            if (rad_productid.Checked)
            {
                Dv.RowFilter = "part_number like '%" + txt_buscar.Text + "%'";
            }
            if (rad_product_name.Checked)
            {
                Dv.RowFilter = "product_name like '%" + txt_buscar.Text + "%'";
            }
            if (rad_ubication.Checked)
            {
                Dv.RowFilter = "ubicacion like '%" + txt_buscar.Text + "%'";
            }
            ContarRegistros();
        }
        private void Btn_limpiar_filtros_Click(object sender, EventArgs e)
        {
            txt_buscar.Text = string.Empty;
            Dv.RowFilter = string.Empty;
            ContarRegistros();
        }

        private void Btn_DetailsConsumos_Click(object sender, EventArgs e)
        {
            Frm_DetailsConsumos frmDetails = new(ProduccionService)
            {
                Rollid = GridMaster.CurrentRow?.Cells["roll_id"].Value?.ToString() ?? string.Empty,
                Productid = GridMaster.CurrentRow?.Cells["product_id"].Value?.ToString() ?? string.Empty,
                Product_Name = GridMaster.CurrentRow?.Cells["product_name"].Value?.ToString() ?? string.Empty,
                Width_t = GridMaster.CurrentRow?.Cells["width"].Value!.ToString() ?? string.Empty,
                Length = GridMaster.CurrentRow?.Cells["length"].Value!.ToString() ?? string.Empty,
            };
            frmDetails.ShowDialog();
        }

        private void Bot_Excel_Click(object sender, EventArgs e)
        {
            List<ProductMAP> listaMasterRolls = CreateListaMasterRolls();
            ExportDataService.ExportToExcel<ProductMAP>(listaMasterRolls, "InventarioMaster.xlsx");
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
}


