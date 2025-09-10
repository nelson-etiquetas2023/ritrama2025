using Ritrama2025.Forms;
using Ritrama2025.Helpers;
using System.ComponentModel;


namespace Ritrama2025
{
    public partial class Main : Form
    {
        private readonly FormManager _formManager;

        public Main(FormManager formManager)
        {
            InitializeComponent();
            _formManager = formManager;
        }

        private void Main_Load(object sender, EventArgs e)
        {
         
        }
        private void Bot_despacho_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<FrmDespacho>(this);
        }

        private void Bot_ordencorte_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<FrmOrdenCorte>(this);
        }

        private void Bot_recepciones_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<FrmMateriaPrima>(this);
        }

        private void OPC_MENU_LABELS_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<FrmCodeBarLabel>(this);
        }

        private void Bot_products_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<FrmProductos>(this);
        }

        private void Bot_inventario_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<Frm_Inventarios>(this);
        }
    }   
}