using Ritrama2025.Models;
using Ritrama2025.Services.ProduccionService;
using System.ComponentModel;

namespace Ritrama2025.Forms.Otros
{
    public partial class Frm_ConfigVueltas : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Numero_Vueltas { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double Longitud_a_Cortar { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string OC { get; set; } = "";
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        IProduccionService ProduccionService { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double Total_Length_utilizado { get; set; } = 0;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool StatusConfigVueltas { get; set; }
        public List<ConfigVueltas> Vueltas = [];
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int EditMode { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SaveChenged { get; set; } = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Splice { get; set; } = 0;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<int> VueltasModificadas { get; set; } = [];

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int NumeroCortes { get; set; } = 0;
        public Frm_ConfigVueltas(IProduccionService produccionService)
        {
            InitializeComponent();
            ProduccionService = produccionService;
        }

        private void Frm_ConfigVueltas_Load(object sender, EventArgs e)
        {
            Vueltas.Clear();
            if (EditMode == 0)
            {
                btn_saveChanges.Enabled = false;
                Grid_ConfigVueltas.ReadOnly = true;
            }

            if (StatusConfigVueltas)
            {
                //buscar ConfigVueltas en la BD.
                Vueltas = ProduccionService.GetConfigVueltas(OC);
                Total_Length_utilizado = Vueltas.Sum(v => v.Longitud_Cortar);

            }
            else
            {
                //Armar la ConfigVueltas desde cero de la forma predeterminada. 
                Total_Length_utilizado = Numero_Vueltas * Longitud_a_Cortar;
                
                for (int v = 1; v <= Numero_Vueltas; v++)
                {
                    int inicio = (v - 1) * NumeroCortes + 1;
                    int fin = v * NumeroCortes;

                    Vueltas.Add(new ConfigVueltas { OrdenCorte = OC, Vuelta_numero = v, Longitud_Cortar = Longitud_a_Cortar, Rollos = $"{inicio}-{fin}"});

                }
            }
            Grid_ConfigVueltas.DataSource = Vueltas;
            Grid_ConfigVueltas.Columns[0].Visible = false;
            Grid_ConfigVueltas.Columns[1].HeaderText = "Vueltas";
            Grid_ConfigVueltas.Columns[2].HeaderText = "No. Rollos";
            Grid_ConfigVueltas.Columns[3].HeaderText = "Length";
            Grid_ConfigVueltas.Columns[4].HeaderText = "Splice";
            Grid_ConfigVueltas.Columns[1].ReadOnly = true;
            Grid_ConfigVueltas.Columns[2].ReadOnly = true;
            Grid_ConfigVueltas.Columns[1].Width = 60;
            Grid_ConfigVueltas.Columns[2].Width = 60;
            Grid_ConfigVueltas.Columns[3].Width = 70;
            Grid_ConfigVueltas.Columns[4].Width = 70;
            txt_Total_Utilizado.Text = Total_Length_utilizado.ToString("N2");

        }

        private void Grid_ConfigVueltas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double total_Utilizado = 0;
            for (int i = 1; i <= Numero_Vueltas; i++)
            {
                total_Utilizado += Convert.ToDouble(Grid_ConfigVueltas.Rows[i - 1].Cells["Longitud_Cortar"].Value);
            }
            txt_Total_Utilizado.Text = total_Utilizado.ToString("N2");
        }

        private void Btn_saveChanges_Click(object sender, EventArgs e)
        {

            if (StatusConfigVueltas)
            {
                //guardar los cambios en la BD Modificacion.
                ProduccionService.UpdateConfigVueltas(Vueltas);
            }
            else
            {
                //INSERT a la BD Nueva Configuracion. 
                ProduccionService.GuardarConfigVueltas(Vueltas);
            }
            //actualizar el real utilizado con Configuracion de Vueltas.
            Total_Length_utilizado = Convert.ToDouble(txt_Total_Utilizado.Text);

            this.SaveChenged = true;
            this.Close();
        }

        private void Grid_ConfigVueltas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewRow filamodif = Grid_ConfigVueltas.Rows[e.RowIndex];
            filamodif.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;


            int numVueltaMod = Convert.ToInt32(filamodif.Cells[1].Value);
            if (!VueltasModificadas.Contains(numVueltaMod)) 
            {
                VueltasModificadas.Add(numVueltaMod);
            }
        }
    }
}
