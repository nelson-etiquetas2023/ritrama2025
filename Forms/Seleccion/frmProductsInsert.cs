using Ritrama2025.Models;
using System.Data;

namespace Ritrama2025.Forms.Seleccion
{

    public partial class FrmProductsInsert : Form
    {
        public DataTable DtItems { get; set; } = null!;
        public string Titulo { get; set; } = string.Empty;
        public ProductMAP Producto { get; set; } = new ProductMAP();
        public string TypeProduct { get; set; } = "";
        public FrmProductsInsert()
        {
            InitializeComponent();
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            FrmSeleccion frmSelectProducts = new()
            {
                DtItems = DtItems,
                Titulo = "Producto"
            };
            frmSelectProducts.ShowDialog();
            txt_productid.Text = frmSelectProducts.Id;
            txt_productname.Text = frmSelectProducts.Description;

            switch (frmSelectProducts.Tipo)
            {
                case "Master":
                    rad_master.Checked = true;
                    rad_hojas.Checked = false;
                    rad_graphics.Checked = false;
                    rad_rolloCortado.Checked = false;
                    TypeProduct = "Master";
                    break;
                case "Resma":
                    rad_master.Checked = false;
                    rad_hojas.Checked = true;
                    rad_graphics.Checked = false;
                    rad_rolloCortado.Checked = false;
                    TypeProduct = "Resma";
                    break;
                case "Graphics":
                    rad_master.Checked = false;
                    rad_hojas.Checked = false;
                    rad_graphics.Checked = true;
                    rad_rolloCortado.Checked = false;
                    TypeProduct = "Graphics";
                    break;
                case "Rollo Cortado":
                    rad_master.Checked = false;
                    rad_hojas.Checked = false;
                    rad_graphics.Checked = false;
                    rad_rolloCortado.Checked = true;
                    TypeProduct = "Rollo Cortado";
                    break;
                default:
                    break;
            }
        }

        private void FrmProductsInsert_Load(object sender, EventArgs e)
        {
            txt_cant.Text = "1";
            txt_width.Text = "0";
            txt_msi.Text = "0";
            txt_lenght.Text = "0";
            txt_splice.Text = "0";
            txt_core.Text = "0";
           
        }
        private void CALCULAR_MSI()
        {
            if (txt_width.Text == "" || txt_lenght.Text == "") return;

            double width = Convert.ToDouble(txt_width.Text);
            double lenght = Convert.ToDouble(txt_lenght.Text);
            double msi = ((width * lenght) * R.CONSTANTES.FACTOR_CALCULO_MSI);
            txt_msi.Text = msi.ToString();
        }

        private void Txt_width_KeyUp(object sender, KeyEventArgs e)
        {
            CALCULAR_MSI();
        }

        private void Txt_lenght_KeyUp(object sender, KeyEventArgs e)
        {

            CALCULAR_MSI();
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            Producto = new ProductMAP
            {
                Product_Id = txt_productid.Text,
                Product_Name = txt_productname.Text,
                Product_Type = TypeProduct,
                Width = Convert.ToDouble(txt_width.Text),
                Length = Convert.ToDouble(txt_lenght.Text),
                Msi = Convert.ToDouble(txt_msi.Text),
                Core = Convert.ToInt32(txt_core.Text),
                Rollid = txt_rollid.Text,
                Splice = Convert.ToInt16(txt_splice.Text),
                Cant = Convert.ToInt32(txt_cant.Text),
                Ubic = txt_ubic.Text,
            };
            this.Close();
        }
    }
}
