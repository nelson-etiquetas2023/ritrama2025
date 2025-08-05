using System.Data;
using System.ComponentModel;
using Ritrama2025.Models;
using Ritrama2025.Forms.Otros;
using Ritrama2025.Services.ProduccionService;


namespace Ritrama2025.Forms.Seleccion
{
    public partial class Frm_RollId : Form
    {
        DataView Dv = new();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTable DtRollid { get; set; } = null!;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RolloCortado MasterRoll { get; set; } = null!;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string tipo_mov { get; set; } = "";

        private IProduccionService ProduccionService  { get; set; }
        public Frm_RollId(IProduccionService produccionService)
        {
            InitializeComponent();
            ProduccionService = produccionService;
        }

        private void Frm_RollId_Load(object sender, EventArgs e)
        {
            Dv = DtRollid.DefaultView;
            GridItems.AutoGenerateColumns = false;
            StyleGridColumns();
            GridItems.DataSource = DtRollid;
            RefreshForms();
        }
        private void RefreshForms()
        {
            CONTADOR_REGISTROS.Text = Convert.ToString(Dv.Count) + " registros encontrados.";
        }
        private void StyleGridColumns()
        {
            GridItems.DataSource = null;
            GridItems.Columns.Clear();
            AGREGAR_COLUMN_GRID("rollid", 70, "Roll Id", "Roll_Id");
            AGREGAR_COLUMN_GRID("product_id", 60, "Product Id", "part_number");
            AGREGAR_COLUMN_GRID("product_name", 240, "Nombre del Producto", "product_name");
            AGREGAR_COLUMN_GRID("Ancho", 65, "Width", "width");
            AGREGAR_COLUMN_GRID("lenght", 65, "Largo Original", "lenght");
            AGREGAR_COLUMN_GRID("lenght_consumido", 70, "Largo Consumido", "largo_consumido");
            AGREGAR_COLUMN_GRID("largo_restante", 70, "Largo Restante", "largo_restante");
            AGREGAR_COLUMN_GRID("estado", 70, "Estado", "estado");
            AGREGAR_COLUMN_GRID("fecha_pro", 67, "Fecha produccion", "fecha_pro");
            AGREGAR_COLUMN_GRID("fecha_doc", 67, "Fecha Recepcion", "fecha_recep");
            AGREGAR_COLUMN_GRID("splice", 50, "Splice", "splice");
            AGREGAR_COLUMN_GRID("ubicacion", 60, "Ubicacion", "ubicacion");
            AGREGAR_COLUMN_GRID("tipo_mov", 40, "Tipo", "tipo_mov");
        }
        private void AGREGAR_COLUMN_GRID(string name, int size, string title, string field_bd)
        {
            DataGridViewTextBoxColumn dataGridViewColumn = new()
            {
                Name = name,
                Width = size,
                HeaderText = title,
                DataPropertyName = field_bd
            };
            GridItems.Columns.Add(dataGridViewColumn);
        }
        private void BuscarMasterIdData()
        {

            if (rad_productid.Checked)
            {
                Dv.RowFilter = "part_number LIKE '%" + txt_buscar.Text + "%'";
            }
            if (rad_rollid.Checked)
            {
                Dv.RowFilter = "Roll_Id LIKE '%" + txt_buscar.Text + "%'";
            }
            if (rad_productname.Checked)
            {
                Dv.RowFilter = "Product_Name LIKE '%" + txt_buscar.Text + "%'";
            }
            RefreshForms();
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            BuscarMasterIdData();
        }

        private void GridItems_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                double resto = GridItems.Rows[e.RowIndex].Cells["largo_restante"].Value!.ToString() == "" ? 0 : Convert.ToDouble(GridItems.Rows[e.RowIndex].Cells["largo_restante"].Value);

                if (resto <= 0)
                {
                    MessageBox.Show("este rollo ya ha sido consumido...");
                    return;
                }
                // Ensure that the cell values are not null before accessing them
                var rollIdValue = GridItems.Rows[e.RowIndex].Cells[0].Value?.ToString();
                var productIdValue = GridItems.Rows[e.RowIndex].Cells[1].Value?.ToString();
                var productNameValue = GridItems.Rows[e.RowIndex].Cells[2].Value?.ToString();
                var widthValue = GridItems.Rows[e.RowIndex].Cells[3].Value;
                var lengthValue = GridItems.Rows[e.RowIndex].Cells["largo_restante"].Value;
                var tipo_movi = GridItems.Rows[e.RowIndex].Cells["tipo_mov"].Value!.ToString();



                if (rollIdValue != null && productIdValue != null && productNameValue != null &&
                    widthValue != null && lengthValue != null && tipo_movi != null)
                {
                    MasterRoll = new()
                    {
                        Roll_Id = rollIdValue,
                        Product_Id = productIdValue,
                        Product_Name = productNameValue,
                        Width = Convert.ToDecimal(widthValue),
                        Length = Convert.ToDecimal(lengthValue),
                        tipo_mov = tipo_movi,
                    };
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Algunos valores de las celdas son nulos. Por favor, verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_reload_Click(object sender, EventArgs e)
        {
            Dv.RowFilter = string.Empty; // Clear the filter
            RefreshForms();
            txt_buscar.Text = string.Empty; // Clear the search text    

        }

        private void Btn_DetailsConsumos_Click(object sender, EventArgs e)
        {
            Frm_DetailsConsumos frmDetails = new(ProduccionService) 
            {
                Rollid = GridItems.CurrentRow?.Cells["rollid"].Value?.ToString() ?? string.Empty,
                Productid = GridItems.CurrentRow?.Cells["product_id"].Value?.ToString() ?? string.Empty,
                Product_Name = GridItems.CurrentRow?.Cells["product_name"].Value?.ToString() ?? string.Empty,
                Width_t = GridItems.CurrentRow?.Cells["Ancho"].Value?.ToString() ?? string.Empty,
                Length = GridItems.CurrentRow?.Cells["lenght"].Value?.ToString() ?? string.Empty

            };
            frmDetails.ShowDialog();
        }
    }
}
