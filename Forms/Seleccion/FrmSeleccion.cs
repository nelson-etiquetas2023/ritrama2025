using Ritrama2025.Forms.Otros;
using System.ComponentModel;
using System.Data;


namespace Ritrama2025.Forms.Seleccion
{
    public partial class FrmSeleccion : Form
    {
        public FrmSeleccion()
        {
            InitializeComponent();
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTable DtItems { get; set; } = null!;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Id { get; set; } = null!;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Description { get; set; } = null!;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Titulo { get; set; } = null!;

        DataView Dv = new();
        string colname1 = null!;
        string colname2 = null!;

        private void Seleccion_Load(object sender, EventArgs e)
        {
            Dv = DtItems.DefaultView;
            Grid_Items.AutoGenerateColumns = false;
            Dv.RowFilter = "";
            Grid_Items.DataSource = Dv;
            Numero_reg.Text = Convert.ToString(Dv.Count) + " Registro Encontrados";
            titleform.Text = Titulo;
            bot_buscar.Focus();
            if (Titulo == "Clientes")
            {
                colname1 = "customer_id";
                colname2 = "customer_name";
            }
            if (Titulo == "Vendedores")
            {
                colname1 = "vendor_id";
                colname2 = "vendor_name";
            }
            if (Titulo == "Transporte")
            {
                colname1 = "transport_id";
                colname2 = "transport_name";
            }
            if (Titulo == "Chofer")
            {
                colname1 = "chofer_id";
                colname2 = "chofer_name";
            }
            if (Titulo == "Camion")
            {
                colname1 = "placas_id";
                colname2 = "camion_name";
            }
            EstilosGrid();
        }
        private void BuscarItems()
        {
            if (ra_id.Checked)
            {
                Dv.RowFilter = colname1 + " like '%" + txt_buscar.Text + "%'";
            }
            if (ra_description.Checked)
            {
                Dv.RowFilter = colname2 + " like '%" + txt_buscar.Text + "%'";
            }

        }
        private void EstilosGrid()
        {
            DataGridViewTextBoxColumn col1 = new()
            {
                Name = colname1,
                Width = 80,
                HeaderText = "Código",
                DataPropertyName = colname1
            };
            Grid_Items.Columns.Add(col1);
            DataGridViewTextBoxColumn col2 = new()
            {
                Name = colname2,
                Width = 320,
                HeaderText = "Descripción",
                DataPropertyName = colname2
            };
            Grid_Items.Columns.Add(col2);
        }

        private void Bot_buscar_Click(object sender, EventArgs e)
        {
            BuscarItems();
        }

        private void Grid_Items_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            Id = Grid_Items.Rows[e.RowIndex].Cells[0].Value!.ToString()!;
            Description = Grid_Items.Rows[e.RowIndex].Cells[1].Value!.ToString()!;
            this.Close();
        }

        private void btn_add_new_Click(object sender, EventArgs e)
        {
            if (Titulo == "Transporte") 
            {
                Frm_AddNew frmNew = new()
                {
                    TitleForm = "Agregar Transportes",
                    Dt = DtItems,
                    NombreEntidad = "Transporte"

                };
                frmNew.ShowDialog();
                DtItems = frmNew.Dt;
            }
            if (Titulo == "Chofer") 
            {
                Frm_AddNew frmNew = new()
                {
                    TitleForm = "Agregar Choferes",
                    Dt = DtItems,
                    NombreEntidad = "Chofer"
                };
                frmNew.ShowDialog();
                DtItems = frmNew.Dt;
            }
            if (Titulo == "Camion") 
            {
                Frm_AddNew frmNew = new()
                {
                    TitleForm = "Agregar Camiones",
                    Dt = DtItems,
                    NombreEntidad = "Camion"
                };
                frmNew.ShowDialog();
                DtItems = frmNew.Dt;
            }
        }
    }
}
