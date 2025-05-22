using Ritrama2025.Services;
using System.Data;


namespace Ritrama2025.Forms
{
    public partial class FrmOrdenCorte : Form
    {
        private readonly ProduccionService Service = new();
        DataSet Ds = new();
        readonly BindingSource Bs = [];

        public FrmOrdenCorte()
        {
            InitializeComponent();
        }


        private void FrmOrdenCorte_Load(object sender, EventArgs e)
        {
            //1.- Procedimiento para cargar las Ordenes de Corte.
            var task = Task.Run(async () =>
            {
                return await Service.LoadDataOC();
            });
            Ds = task.Result;
            //Enlace a datos Encabezado.
            Bs.DataSource = Ds;
            Bs.DataMember = "DtMaster";
            txt_numeroOC.DataBindings.Add("Text", Bs, "numero");
            txt_fecha_emision.DataBindings.Add("Text", Bs, "fecha");
            txt_fecha_produccion.DataBindings.Add("Text", Bs, "fecha_produccion");
            txt_rollid_1.DataBindings.Add("Text", Bs, "rollid_1");
            txt_width1.DataBindings.Add("Text", Bs, "width_1");
            txt_length1.DataBindings.Add("Text", Bs, "lenght_1");
            txt_real1_width.DataBindings.Add("Text", Bs, "util1_real_width");
            txt_real1_length.DataBindings.Add("Text", Bs, "util1_real_lenght");
            txt_real2_width.DataBindings.Add("Text", Bs, "util2_real_width");
            txt_real2_length.DataBindings.Add("Text", Bs, "util2_real_lenght");
            txt_rollid_2.DataBindings.Add("Text", Bs, "rollid_2");
            txt_width2.DataBindings.Add("Text", Bs, "width_2");
            txt_length2.DataBindings.Add("Text", Bs, "lenght_2");
            txt_matrest1_width.DataBindings.Add("Text", Bs, "rest1_width");
            txt_matrest1_lenght.DataBindings.Add("Text", Bs, "rest1_lenght");
            txt_matrest2_width.DataBindings.Add("Text", Bs, "rest2_width");
            txt_matrest2_lenght.DataBindings.Add("Text", Bs, "rest2_lenght");


        }

        private void TextBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void bot_primero_Click(object sender, EventArgs e)
        {
            Bs.Position = 0;
        }

        private void bot_anterior_Click(object sender, EventArgs e)
        {
            Bs.Position -= 1;
        }

        private void bot_siguiente_Click(object sender, EventArgs e)
        {
            Bs.Position += 1;
        }

        private void bot_ultimo_Click(object sender, EventArgs e)
        {
            Bs.Position = Bs.Count - 1;
        }
    }
}
