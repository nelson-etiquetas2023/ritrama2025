using Ritrama2025.Forms;

namespace Ritrama2025
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void bot_despacho_Click(object sender, EventArgs e)
        {

            OpenFormSingleInstance<FrmDespacho>("DESPACHO");
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void bot_ordencorte_Click(object sender, EventArgs e)
        {
            OpenFormSingleInstance<FrmOrdenCorte>("OC");
        }

        private void OpenFormSingleInstance<T>(string nameForm) where T : Form, new()
        {
            var existingForm = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (existingForm != null)
            {
                // Si ya existe, lo trae al frente
                existingForm.BringToFront();
                if (existingForm.WindowState == FormWindowState.Minimized)
                    existingForm.WindowState = FormWindowState.Normal;
            }
            else 
            {
                if (nameForm == "OC") 
                {
                    FrmOrdenCorte frmOrdenCorte = new FrmOrdenCorte()
                    {
                        MdiParent = this,
                        StartPosition = FormStartPosition.Manual,
                        Location = new Point { X = Location.X + 20, Y = Location.Y + 20 }
                   
                    };
                    frmOrdenCorte.Show();
                }
                if (nameForm == "DESPACHO")
                {
                    FrmDespacho frmdespacho = new FrmDespacho()
                    {
                        MdiParent = this,
                        StartPosition = FormStartPosition.Manual,
                        Location = new Point { X = Location.X + 20, Y = Location.Y + 20 }
                    };
                    frmdespacho.Show();
                }
            }
        }
    }
}
