using Ritrama2025.Services.ProductsService;
using System.Data;

namespace Ritrama2025.Forms
{
    public partial class FrmProductos : Form
    {
        IProductsService ProductsService;
        public DataSet Ds = new();
        BindingSource Bs = new();

        public FrmProductos(IProductsService productsService)
        {
            InitializeComponent();
            ProductsService = productsService;
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            GetProductsAsync();
            Bs.DataSource = Ds;
            Bs.DataMember = "Dtproducts";
            txt_partid.DataBindings.Add("text", Bs, "product_id");
            txt_productname.DataBindings.Add("text", Bs, "product_name");
            txt_productdescription.DataBindings.Add("text", Bs, "product_descrip");
            txt_referencia.DataBindings.Add("text", Bs, "Product_Ref");
            txt_codebar.DataBindings.Add("text", Bs, "codebar");
            txt_precio.DataBindings.Add("text", Bs, "precio");
            txt_ratio.DataBindings.Add("text", Bs, "ratio");
            chk_product_anulado.DataBindings.Add("Checked", Bs, "anulado");
            rad_master.DataBindings.Add("Checked", Bs, "MasterRolls");
            rad_hoja.DataBindings.Add("Checked", Bs, "Resmas");
            rad_graphics.DataBindings.Add("Checked", Bs, "Graphics");


        }

        private void GetProductsAsync()
        {
            var task = Task.Run(async () =>
            {
                return await ProductsService.Load();
            });
            Ds = task.Result;
        }

        private void bot_siguiente_Click(object sender, EventArgs e)
        {
            Bs.Position = Bs.Position + 1;
        }

        private void bot_anterior_Click(object sender, EventArgs e)
        {
            Bs.Position = Bs.Position - 1;
        }

        private void bot_ultimo_Click(object sender, EventArgs e)
        {
            Bs.Position = Bs.Count - 1;
        }

        private void bot_primero_Click(object sender, EventArgs e)
        {
            Bs.Position = 0;
        }
    }
}
