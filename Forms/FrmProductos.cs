using Ritrama2025.Services.ProductsService;
using System.Data;

namespace Ritrama2025.Forms
{
    public partial class FrmProductos : Form
    {
        IProductsService ProductsService;
        public DataSet Ds = new();
        BindingSource Bs = new();
        DataRowView Row = null!;

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
            Refreshform();
        }

        private void Refreshform()
        {
            lbl_contador.Text = "Registros: " + (Bs.Position + 1).ToString() + "-" + Bs.Count.ToString();
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
            Refreshform();
        }

        private void bot_anterior_Click(object sender, EventArgs e)
        {
            Bs.Position = Bs.Position - 1;
            Refreshform();
        }

        private void bot_ultimo_Click(object sender, EventArgs e)
        {
            Bs.Position = Bs.Count - 1;
            Refreshform();
        }

        private void bot_primero_Click(object sender, EventArgs e)
        {
            Bs.Position = 0;
            Refreshform();
        }

        private void FrmProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Ds.Tables.Clear();
            Ds.Dispose();
        }

        private void bot_nuevo_Click(object sender, EventArgs e)
        {
            OpenEditForm();
            chk_product_anulado.DataBindings.Clear();
            rad_master.DataBindings.Clear();
            rad_hoja.DataBindings.Clear();
            rad_graphics.DataBindings.Clear();
            Row = (DataRowView)Bs.AddNew();
            Row.BeginEdit();
           
            //Row.EndEdit();
        }
        private void OpenEditForm() 
        {
            txt_partid.ReadOnly = false;
            txt_productname.ReadOnly = false;
            txt_productdescription.ReadOnly = false;
            txt_referencia.ReadOnly = false;
            txt_codebar.ReadOnly = false;
            txt_precio.ReadOnly = false;
            txt_ratio.ReadOnly = false;
            rad_master.Enabled = true;
            rad_hoja.Enabled = true;
            rad_graphics.Enabled = true;
            rad_graphics.Checked = false;
            rad_hoja.Checked = false;
            rad_master.Checked = false;
        }
    }
}
