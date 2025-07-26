using DocumentFormat.OpenXml.Spreadsheet;
using Ritrama2025.Services.CommonService;
using Ritrama2025.Services.ProduccionService;
using System.ComponentModel;
using System.Data;


namespace Ritrama2025.Forms.Otros
{
    public partial class Frm_DetailsConsumos : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Rollid { get; set; } = null!;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Productid { get; set; } = null!;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Product_Name { get; set; } = null!;
        private DataTable DtItems { get; set; } = new();

        private IProduccionService ProduccionService { get; set; }
        public Frm_DetailsConsumos(IProduccionService produccionService)
        {
            InitializeComponent();
            ProduccionService = produccionService;
        }
        
        private async void Frm_DetailsConsumos_Load(object sender, EventArgs e)
        {
            LoadParameters();
            ColumnDefinitionsGrid();
            await LoadData();
            CalculateTotalConsumo();
        }
        private void CalculateTotalConsumo()
        {
            if (Grid_Items.Rows.Count == 0) return;
            double total_consumo = 0;
            for (int i = 1; i < Grid_Items.Rows.Count + 1; i++)
            {
                Grid_Items.Rows[i - 1].Cells["item"].Value = i.ToString();
                total_consumo += Convert.ToDouble(Grid_Items.Rows[i - 1].Cells["consumo"].Value);
            }
            txt_total.Text = total_consumo.ToString("N2");
            RowCounter.Text = "Numero de Filas: " + Grid_Items.Rows.Count.ToString();
        }

        private async Task LoadData()
        {
            var dt = await ProduccionService.LoadDataDetailsConsumosMasterInic(Rollid);
            DtItems = dt ?? new DataTable();
            Grid_Items.DataSource = DtItems;
        }

        private void ColumnDefinitionsGrid() 
        {
            
            Grid_Items.AutoGenerateColumns = false;
            CommonService.ADD_COLUMN_GRID("item", 30, "It.", "", Grid_Items);
            CommonService.ADD_COLUMN_GRID("orden",80,"Orden Corte","orden",Grid_Items);
            CommonService.ADD_COLUMN_GRID("consumo", 100, "Consumo Length [Pies]", "consumo", Grid_Items);
            CommonService.ADD_COLUMN_GRID("fecha", 150, "Fecha Registro", "fecha_reg", Grid_Items);
            var colCheck = new DataGridViewCheckBoxColumn
            {
                Name = "chk_desper",
                Width = 80,
                HeaderText = "Desperdicio",
                DataPropertyName = "check",
            };
            colCheck.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_Items.Columns.Add(colCheck);
        }
        private void LoadParameters() 
        {
            txt_rollid.Text = Rollid;
            txt_productid.Text = Productid;
            txt_productName.Text = Product_Name;
        }
    }
}
