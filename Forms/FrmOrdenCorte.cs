using Ritrama2025.Services;
using System.Configuration;
using System.Data;
using Newtonsoft.Json;
using Ritrama2025.Forms.Seleccion;

namespace Ritrama2025.Forms
{
    public partial class FrmOrdenCorte : Form
    {
        private readonly ProduccionService Service = new();
        DataSet Ds = new();
        readonly BindingSource Bs = [];
        readonly BindingSource BsCortes = [];
        readonly BindingSource BsRollos = [];
        private readonly Color LineColor = Color.DarkGray;
        public Pen pen1 = new(Color.Black, 4);
        public Pen pen2 = new(Color.Black, 4);
        public Pen pen3 = new(Color.Black, 4);
        public Pen pen4 = new(Color.Black, 4);
        int StepIndicator = 0;
        DataRowView ParentRow = null!;



        public FrmOrdenCorte()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(FrmOrdenCorte_Paint);
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
            //Enlace a datos Encabezado de la Orden Corte.
            HeaderBinding();
            //Enlace a datos de Grid-Cortes.
            BsCortes.DataSource = Bs;
            BsCortes.DataMember = "FK_ENCABEZADO_CORTES";
            grid_cortes.AutoGenerateColumns = false;
            ADD_COLUMN_GRID("it", 25, "It.", "num", grid_cortes);
            ADD_COLUMN_GRID("width", 60, "Width", "width", grid_cortes);
            ADD_COLUMN_GRID("lenght", 60, "Lenght", "lenght", grid_cortes);
            ADD_COLUMN_GRID("msi", 60, "Msi", "msi", grid_cortes);
            ADD_COLUMN_GRID("code_person", 80, "Code Person", "code_person", grid_cortes);
            grid_cortes.DataSource = BsCortes;
            //Enlace a datos de Grid-Rollos Cortados.
            BsRollos.DataSource = Bs;
            BsRollos.DataMember = "FK_MASTER_ROLLOS";
            grid_items.AutoGenerateColumns = false;
            ADD_COLUMN_GRID("number", 25, "#", "roll_number", grid_items);
            ADD_COLUMN_GRID("product_id", 60, "Product Id", "product_id", grid_items);
            ADD_COLUMN_GRID("product_name", 250, "Product Name", "product_name", grid_items);
            ADD_COLUMN_GRID("unique_code", 60, "Unique Code", "unique_code", grid_items);
            ADD_COLUMN_GRID("width", 70, "Width [Inch]", "width", grid_items);
            ADD_COLUMN_GRID("large", 70, "Length [Pies]", "large", grid_items);
            ADD_COLUMN_GRID("msi", 65, "MSI", "msi", grid_items);
            ADD_COLUMN_GRID("splice", 55, "Splice", "splice", grid_items);
            ADD_COLUMN_GRID("roll_id", 60, "Roll Id.", "roll_id", grid_items);
            ADD_COLUMN_GRID("code_person", 60, "Code Person.", "code_person", grid_items);
            ADD_COLUMN_GRID("status", 80, "Status", "status", grid_items);

            grid_items.DataSource = BsRollos;




        }

        private void Bot_primero_Click(object sender, EventArgs e)
        {
            Bs.Position = 0;
        }

        private void Bot_anterior_Click(object sender, EventArgs e)
        {
            Bs.Position -= 1;
        }

        private void Bot_siguiente_Click(object sender, EventArgs e)
        {
            Bs.Position += 1;
        }

        private void Bot_ultimo_Click(object sender, EventArgs e)
        {
            Bs.Position = Bs.Count - 1;
        }
        private void HeaderBinding()
        {
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
            txt_product_id.DataBindings.Add("Text", Bs, "product_id");
            txt_product_name.DataBindings.Add("Text", Bs, "product_Name");
            txt_operador_id.DataBindings.Add("Text", Bs, "id_operador");
            txt_operador_name.DataBindings.Add("Text", Bs, "nombre");
            txt_cust_id.DataBindings.Add("Text", Bs, "customer_id");
            txt_cust_name.DataBindings.Add("Text", Bs, "customer_name");
            txt_resta_corte.DataBindings.Add("Text", Bs, "resta_entrada");
            txt_largo_corte.DataBindings.Add("Text", Bs, "lenght_entrada");
            txt_plus1.DataBindings.Add("Text", Bs, "plus1_pies");
            txt_plus2.DataBindings.Add("Text", Bs, "plus2_pies");
            txt_long_cortar.DataBindings.Add("Text", Bs, "longitud_cortar");
            txt_cortes_ancho.DataBindings.Add("Text", Bs, "cortes_ancho");
            txt_vueltas1.DataBindings.Add("Text", Bs, "cortes_largo");
            txt_rollos_cortar1.DataBindings.Add("Text", Bs, "cant_rollos");
            txt_ancho_corte.DataBindings.Add("Text", Bs, "total_salida");
        }

        private static void ADD_COLUMN_GRID(string name, int size, string title, string field_bd, DataGridView grid)
        {
            DataGridViewTextBoxColumn col = new()
            {
                Name = name,
                Width = size,
                HeaderText = title,
                DataPropertyName = field_bd,
            };
            grid.Columns.Add(col);
        }
        private void FrmOrdenCorte_Paint(object? sender, PaintEventArgs e)
        {
            Graphics lin1 = e.Graphics;
            Graphics lin2 = e.Graphics;
            Graphics lin3 = e.Graphics;
            Graphics lin4 = e.Graphics;
            // Crear un Pen de color rojo y grosor 10
            lin1.DrawLine(pen1, 200, 658, 240, 658);
            lin2.DrawLine(pen2, 280, 658, 320, 658);
            lin3.DrawLine(pen3, 360, 658, 400, 658);
            lin4.DrawLine(pen4, 440, 658, 480, 658);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StepIndicator++;
            switch (StepIndicator)
            {
                case 1:
                    pictureBox1.Image = imageList1.Images[0]; // Cambia la imagen del PictureBox
                    break;
                case 2:
                    pictureBox1.Image = imageList1.Images[5]; // Cambia la imagen del PictureBox

                    pictureBox2.Image = imageList1.Images[1]; // Cambia la imagen del PictureBox

                    pen1.Color = Color.DarkGray;
                    break;
                case 3:
                    pictureBox2.Image = imageList1.Images[6]; // Cambia la imagen del PictureBox
                    pictureBox3.Image = imageList1.Images[2]; // Cambia la imagen del PictureBox
                    pen2.Color = Color.DarkGray;
                    break;
                case 4:
                    pictureBox3.Image = imageList1.Images[7]; // Cambia la imagen del PictureBox
                    pictureBox4.Image = imageList1.Images[3]; // Cambia la imagen del PictureBox
                    pen3.Color = Color.DarkGray;
                    break;
                case 5:
                    pictureBox4.Image = imageList1.Images[8]; // Cambia la imagen del PictureBox
                    pictureBox5.Image = imageList1.Images[4]; // Cambia la imagen del PictureBox
                    pen4.Color = Color.DarkGray;
                    break;
            }
            this.Invalidate(); // Redibuja el formulario para aplicar el nuevo color
        }

        private void Opt_create_document_Click(object sender, EventArgs e)
        {
            ParentRow = (DataRowView)Bs.AddNew()!;
            ParentRow.BeginEdit();
            ParentRow["numero"] = "8900";
            ParentRow.EndEdit();


            txt_numeroOC.ReadOnly = false;
            txt_fecha_emision.Enabled = true;
            txt_fecha_produccion.Enabled = true;
            txt_plus1.ReadOnly = false;
            txt_menos1.ReadOnly = false;
            btn_buscar_rollid1.Enabled = true;




        }

        private void btn_buscar_rollid1_Click(object sender, EventArgs e)
        {
            Frm_RollId frmrollid = new Frm_RollId();
            frmrollid.ShowDialog();
        }

        private static void UpdateAppSettingJson<T>(string key, T value)
        {
            try
            {
                // Ruta del archivo appsettings.json en tiempo de desarrollo
                string appSettingsPath = AppDomain.CurrentDomain.BaseDirectory + "appsettings.json";
                string json = File.ReadAllText(appSettingsPath);
                dynamic jsonObj = JsonConvert.DeserializeObject(json)!;
                var sectionPath = key.Split(":")[0];
                if (!string.IsNullOrEmpty(sectionPath))
                {
                    var keyPath = key.Split(":")[1];
                    jsonObj[sectionPath][keyPath] = value;
                }
                else
                {
                    jsonObj[sectionPath] = value; // if no sectionpath just set the value
                }
                string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                File.WriteAllText(appSettingsPath, output);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }

        }
    }
}
