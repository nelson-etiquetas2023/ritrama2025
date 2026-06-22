using Microsoft.Extensions.Configuration;
using Ritrama2025.Forms;
using Ritrama2025.Helpers;

namespace Ritrama2025
{
    public partial class Main : Form
    {
        private IConfiguration Config { get; set; } = null!;
        private readonly FormManager _formManager;
        private string MODE = "";

        public Main(FormManager formManager, IConfiguration config)
        {
            InitializeComponent();
            _formManager = formManager;
            Config = config;

        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (Config != null)
            {
                MODE = Config["Ambiente"] ?? R.ENVIRONMET.DESARROLLO;
            }
            if (MODE == "Desarrollo")
            {
                panel2.BackColor = Color.Orange;
            }
            if (MODE == "Produccion")
            {
                panel2.BackColor = Color.LightGreen;
            }
            if (MODE == "Testing")
            {
                panel2.BackColor = Color.OrangeRed;
            }
            LAB_MODE_RUN.Text = MODE;

        }
        private void Bot_despacho_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<FrmDespacho>();
        }

        private void Bot_ordencorte_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<FrmOrdenCorte>();
        }

        private void Bot_recepciones_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<FrmMateriaPrima>();
        }

        private void OPC_MENU_LABELS_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<FrmCodeBarLabel>();
        }

        private void Bot_products_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<FrmProductos>();
        }

        private void Bot_inventario_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<Frm_Inventarios>();
        }
    }
}