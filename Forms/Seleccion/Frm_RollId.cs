using System.Data;
using System.ComponentModel;


namespace Ritrama2025.Forms.Seleccion
{
    public partial class Frm_RollId : Form
    {
        DataView Dv = new();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTable DtRollid { get; set; } = null!;
        public Frm_RollId()
        {
            InitializeComponent();
        }

        private void Frm_RollId_Load(object sender, EventArgs e)
        {
            Dv = DtRollid.DefaultView;
            GridItems.AutoGenerateColumns = false;
            StyleGridColumns();
            GridItems.DataSource = DtRollid;
            CONTADOR_REGISTROS.Text = Convert.ToString(Dv.Count) + " registros encontrados.";
        }
        private void StyleGridColumns()
        {
            GridItems.DataSource = null;
            GridItems.Columns.Clear();
            AGREGAR_COLUMN_GRID("rollid", 82, "Roll Id", "Roll_Id");
            AGREGAR_COLUMN_GRID("product_id", 65, "Product Id", "part_number");
            AGREGAR_COLUMN_GRID("product_name", 240, "Nombre del Producto", "product_name");
            AGREGAR_COLUMN_GRID("width", 65, "Width", "width");
            AGREGAR_COLUMN_GRID("lenght", 65, "Lenght", "lenght");
            AGREGAR_COLUMN_GRID("fecha_pro", 67, "Fecha produccion", "fecha_pro");
            AGREGAR_COLUMN_GRID("fecha_doc", 67, "Fecha Recepcion", "fecha_recep");
            AGREGAR_COLUMN_GRID("splice", 50, "Splice", "splice");
            AGREGAR_COLUMN_GRID("ubicacion", 60, "Ubicacion", "ubicacion");
            AGREGAR_COLUMN_GRID("tipo_mov", 40, "Tipo", "tipo_mov");
            GridItems.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            GridItems.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            GridItems.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridItems.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            if (!chk_rebobinado.Checked)
            {
                Dv.RowFilter = "part_number LIKE '%%'";
            }
            if (rad_rollid.Checked && !chk_rebobinado.Checked)
            {
                Dv.RowFilter = "Roll_Id LIKE '%" + txt_buscar.Text + "%'";
            }
            if (rad_productname.Checked && !chk_rebobinado.Checked)
            {
                Dv.RowFilter = "Product_Name LIKE '%" + txt_buscar.Text + "%'";
            }
            if (rad_uniquecode.Checked && chk_rebobinado.Checked)
            {
                Dv.RowFilter = "unique_code LIKE '%" + txt_buscar.Text + "%'";
            }
            if (rad_productid.Checked && !chk_rebobinado.Checked)
            {
                Dv.RowFilter = "part_number LIKE '%" + txt_buscar.Text + "%'";
            }
            if (rad_productid.Checked && chk_rebobinado.Checked)
            {
                Dv.RowFilter = "product_id LIKE '%" + txt_buscar.Text + "%'";
            }
            CONTADOR_REGISTROS.Text = Convert.ToString(Dv.Count) + " registros encontrados.";
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            BuscarMasterIdData();
        }
    }
}
