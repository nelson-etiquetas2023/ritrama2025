using Ritrama2025.Forms;
using Ritrama2025.Services;

namespace Ritrama2025
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Bot_despacho_Click(object sender, EventArgs e)
        {

            OpenFormSingleInstance<FrmDespacho>("DESPACHO");
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void Bot_ordencorte_Click(object sender, EventArgs e)
        {
            OpenFormSingleInstance<FrmOrdenCorte>("OC");
        }

        private void bot_recepciones_Click(object sender, EventArgs e)
        {
            OpenFormSingleInstance<FrmMateriaPrima>("MT");
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
                    FrmOrdenCorte frmOrdenCorte = new()
                    {
                        MdiParent = this,
                        StartPosition = FormStartPosition.Manual,
                        Location = new Point { X = Location.X + 20, Y = Location.Y + 20 }
                    };
                    frmOrdenCorte.Show();
                }
                if (nameForm == "DESPACHO")
                {
                    FrmDespacho frmdespacho = new()
                    {
                        MdiParent = this,
                        StartPosition = FormStartPosition.Manual,
                        Location = new Point { X = Location.X + 20, Y = Location.Y + 20 }
                    };
                    frmdespacho.Show();
                }
                if (nameForm == "MT")
                {
                    FrmMateriaPrima formMT = new()
                    {
                        MdiParent = this,
                        StartPosition = FormStartPosition.Manual,
                        Location = new Point { X = Location.X + 20, Y = Location.Y + 20 }
                    };
                    formMT.Show();
                }
            }
        }
    }
}
