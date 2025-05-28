using Newtonsoft.Json;
using Ritrama2025.Forms.Seleccion;
using Ritrama2025.Services;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace Ritrama2025.Forms
{
    public partial class FrmOrdenCorte : Form
    {
        private readonly ProduccionService Service = new();
        DataSet Ds = new();
        readonly BindingSource Bs = [];
        readonly BindingSource BsCortes = [];
        readonly BindingSource BsRollos = [];
        //private readonly Color LineColor = Color.DarkGray;
        //public Pen pen1 = new(Color.Black, 4);
        //public Pen pen2 = new(Color.Black, 4);
        //public Pen pen3 = new(Color.Black, 4);
        //public Pen pen4 = new(Color.Black, 4);
        //int StepIndicator = 0;
        DataRowView ParentRow = null!;
        DataRowView ChildRowCortes = null!;
        DataRowView RollosCortados = null!;

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
            ADD_COLUMN_GRID("width", 60, "Width [INCH]", "width", grid_cortes);
            ADD_COLUMN_GRID("lenght", 60, "Lenght [PIES]", "lenght", grid_cortes);
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
            ADD_COLUMN_GRID("width", 65, "Width [Inch]", "width", grid_items);
            ADD_COLUMN_GRID("large", 65, "Length [Pies]", "large", grid_items);
            ADD_COLUMN_GRID("msi", 60, "MSI", "msi", grid_items);
            ADD_COLUMN_GRID("splice", 45, "Splice", "splice", grid_items);
            ADD_COLUMN_GRID("roll_id", 65, "Roll Id.", "roll_id", grid_items);
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
            //txt_vueltas1.DataBindings.Add("Text", Bs, "cortes_largo");
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
            //{
            //    Graphics lin1 = e.Graphics;
            //    Graphics lin2 = e.Graphics;
            //    Graphics lin3 = e.Graphics;
            //    Graphics lin4 = e.Graphics;
            //    // Crear un Pen de color rojo y grosor 10
            //    lin1.DrawLine(pen1, 200, 658, 240, 658);
            //    lin2.DrawLine(pen2, 280, 658, 320, 658);
            //    lin3.DrawLine(pen3, 360, 658, 400, 658);
            //    lin4.DrawLine(pen4, 440, 658, 480, 658);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //StepIndicator++;
            //switch (StepIndicator)
            //{
            //    case 1:
            //        pictureBox1.Image = imageList1.Images[0]; // Cambia la imagen del PictureBox
            //        break;
            //    case 2:
            //        pictureBox1.Image = imageList1.Images[5]; // Cambia la imagen del PictureBox

            //        pictureBox2.Image = imageList1.Images[1]; // Cambia la imagen del PictureBox

            //        pen1.Color = Color.DarkGray;
            //        break;
            //    case 3:
            //        pictureBox2.Image = imageList1.Images[6]; // Cambia la imagen del PictureBox
            //        pictureBox3.Image = imageList1.Images[2]; // Cambia la imagen del PictureBox
            //        pen2.Color = Color.DarkGray;
            //        break;
            //    case 4:
            //        pictureBox3.Image = imageList1.Images[7]; // Cambia la imagen del PictureBox
            //        pictureBox4.Image = imageList1.Images[3]; // Cambia la imagen del PictureBox
            //        pen3.Color = Color.DarkGray;
            //        break;
            //    case 5:
            //        pictureBox4.Image = imageList1.Images[8]; // Cambia la imagen del PictureBox
            //        pictureBox5.Image = imageList1.Images[4]; // Cambia la imagen del PictureBox
            //        pen4.Color = Color.DarkGray;
            //        break;
            //}
            //this.Invalidate(); // Redibuja el formulario para aplicar el nuevo color
        }

        private void Opt_create_document_Click(object sender, EventArgs e)
        {
            //1.- Inicialiozar el Documento de Orden de Corte.
            ParentRow = (DataRowView)Bs.AddNew()!;
            ParentRow.BeginEdit();
            ParentRow["numero"] = "8902";
            ParentRow["rollid_1"] = "0";
            ParentRow["rollid_2"] = "0";
            ParentRow["width_1"] = "0";
            ParentRow["lenght_1"] = "0";
            ParentRow["width_2"] = "0";
            ParentRow["lenght_2"] = "0";
            ParentRow["util1_real_width"] = "0";
            ParentRow["util1_real_lenght"] = "0";
            ParentRow["rest1_width"] = "0";
            ParentRow["rest1_lenght"] = "0";
            ParentRow["rest2_width"] = "0";
            ParentRow["rest2_lenght"] = "0";
            ParentRow["util2_real_width"] = "0";
            ParentRow["util2_real_lenght"] = "0";
            ParentRow["plus1_pies"] = "0";
            ParentRow["plus2_pies"] = "0";
            ParentRow["longitud_cortar"] = "0";
            ParentRow["cortes_ancho"] = "0";
            ParentRow["cortes_largo"] = "0";
            ParentRow["cant_rollos"] = "0";

            txt_menos1.Text = "0";
            txt_real1.Text = "0";
            txt_real2.Text = "0";
            txt_plus1.Text = "0";
            txt_menos2.Text = "0";

            ParentRow.EndEdit();
            //Crear la Dimension de los Cortes.
            for (int i = 0; i < 5; i++)
            {
                ChildRowCortes = (DataRowView)BsCortes.AddNew()!;
                ChildRowCortes.BeginEdit();
                ChildRowCortes["num"] = i + 1;
                ChildRowCortes["width"] = "0";
                ChildRowCortes["lenght"] = "0";
                ChildRowCortes["msi"] = "0";
                ChildRowCortes["code_person"] = "S/N";
                ChildRowCortes.EndEdit();
            }

            grid_cortes.ReadOnly = false;
            btn_add_row_corte.Enabled = true;
            btn_delete_row_corte.Enabled = true;
            txt_long_cortar.ReadOnly = false;
            txt_vueltas1.ReadOnly = false;
            btn_buscar_operador.Enabled = true;
            btn_buscar_customer.Enabled = true;


            //3.- Abrir los Textbox para editar los datos de la Orden de Corte.
            txt_numeroOC.ReadOnly = false;
            txt_fecha_emision.Enabled = true;
            txt_fecha_produccion.Enabled = true;
            txt_plus1.ReadOnly = false;
            txt_menos1.ReadOnly = false;
            txt_plus2.ReadOnly = false;
            txt_menos2.ReadOnly = false;
            btn_buscar_rollid1.Enabled = true;
        }

        private void Btn_buscar_rollid1_Click(object sender, EventArgs e)
        {
            Frm_RollId frmrollid = new()
            {
                DtRollid = Ds.Tables["DtRollid"]!
            };
            frmrollid.ShowDialog();
            if (frmrollid.MasterRoll != null)
            {
                txt_rollid_1.Text = Convert.ToString(frmrollid.MasterRoll.Roll_Id);
                txt_width1.Text = frmrollid.MasterRoll.Width.ToString("N2");
                txt_length1.Text = frmrollid.MasterRoll.Length.ToString("N2");
                txt_real1.Text = frmrollid.MasterRoll.Length.ToString("N2");
                txt_product_id.Text = frmrollid.MasterRoll.Product_Id;
                txt_product_name.Text = frmrollid.MasterRoll.Product_Name;
            }
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
        private void UpdateValueRealLenghtMaster1()
        {
            if (txt_real1.Text != "")
            {
                double num = Convert.ToDouble(txt_length1.Text) - Convert.ToDouble(txt_menos1.Text) + Convert.ToDouble(txt_plus1.Text);
                txt_real1.Text = num.ToString();
            }

        }

        private void Txt_plus1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateValueRealLenghtMaster1();
        }

        private void Txt_menos1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateValueRealLenghtMaster1();
        }
        public static void ValidaSoloNumerosDec(KeyPressEventArgs k)
        {
            if (char.IsDigit(k.KeyChar))
            {
                k.Handled = false;
            }
            else if (char.IsSeparator(k.KeyChar))
            {
                k.Handled = false;
            }
            else if (char.IsControl(k.KeyChar))
            {
                k.Handled = false;
            }
            else if (k.KeyChar.ToString().Equals(".") || k.KeyChar.ToString().Equals(">") || k.KeyChar.ToString().Equals("<") || k.KeyChar.ToString().Equals("="))
            {
                k.Handled = false;
            }
            else
            {
                k.Handled = true;
            }
        }

        private void Btn_buscar_rollid2_Click(object sender, EventArgs e)
        {

        }

        private void Btn_delete_row_corte_Click(object sender, EventArgs e)
        {
            if (grid_cortes.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in grid_cortes.SelectedRows)
                {
                    grid_cortes.Rows.Remove(row);
                }
                txt_cortes_ancho.Text = grid_cortes.Rows.Count.ToString();

            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Txt_long_cortar_KeyUp(object sender, KeyEventArgs e)
        {
            for (int i = 0; i <= grid_cortes.Rows.Count - 1; i++)
            {
                grid_cortes.Rows[i].Cells["lenght"].Value = txt_long_cortar.Text;
                grid_cortes.Rows[i].Cells["msi"].Value = Convert.ToDouble(grid_cortes.Rows[i].Cells["width"].Value) * Convert.ToDouble(grid_cortes.Rows[i].Cells["lenght"].Value) * R.CONSTANTES.FACTOR_CALCULO_MSI;
                txt_cortes_ancho.Text = grid_cortes.Rows.Count.ToString();
                CalcularRealUtil1();
                CalcularMatRestante1();
                CalcularConsumosLenght();
            }
            if (grid_items.Rows.Count > 0)
            {
                BorrarRollosCortadosHijos();
            }

        }

        private void Txt_vueltas1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_vueltas1.Text) && !string.IsNullOrEmpty(txt_cortes_ancho.Text))
            {
                double num = Convert.ToDouble(txt_cortes_ancho.Text) * Convert.ToDouble(txt_vueltas1.Text);
                txt_rollos_cortar1.Text = num.ToString();
            }
            CalcularConsumosLenght();
        }

        private void CalcularRealUtil1()
        {
            double num = 0.0;
            double num2 = 0.0;
            for (int i = 0; i <= grid_cortes.Rows.Count - 1; i++)
            {
                // Fixing CS1001, CS1002, and CS1525 by using the correct method name and syntax
                num += Convert.ToDouble(grid_cortes.Rows[i].Cells["width"].Value);
                num2 += Convert.ToDouble(grid_cortes.Rows[i].Cells["lenght"].Value);
                // Fixing the incomplete line for updating txt_real1_width
                txt_real1_width.Text = num.ToString("N2");
                txt_real1_length.Text = num2.ToString("N2");
            }
        }
        private void CalcularMatRestante1()
        {
            double num = (Convert.ToDouble(txt_width1.Text) - Convert.ToDouble(txt_real1_width.Text));

            double num2 = (Convert.ToDouble(txt_length1.Text) - Convert.ToDouble(txt_real1_length.Text));

            txt_matrest1_width.Text = num.ToString("N2");
            txt_matrest1_lenght.Text = num2.ToString("N2");
        }

        private void Btn_buscar_operador_Click(object sender, EventArgs e)
        {
            FrmSeleccion SelOperator = new()
            {
                DtItems = Ds.Tables["DtOperator"]!,
                Titulo = "Operadores",
            };
            SelOperator.ShowDialog();
            txt_operador_id.Text = SelOperator.Id;
            txt_operador_name.Text = SelOperator.Description;
        }

        private void Btn_buscar_customer_Click(object sender, EventArgs e)
        {
            FrmSeleccion SelCust = new()
            {
                DtItems = Ds.Tables["DtCustomer"]!,
                Titulo = "Clientes",
            };
            SelCust.ShowDialog();
            txt_cust_id.Text = SelCust.Id;
            txt_cust_name.Text = SelCust.Description;
        }
        private void GENERAR_ROLLOS_CORTADOS()
        {
            int vueltas = Convert.ToInt32(txt_vueltas1.Text);
            int numcortes = (grid_cortes.Rows.Count);
            int renglon = 1;
            for (int i = 1; i <= vueltas; i++)
            {
                for (int j = 0; j <= numcortes - 1; j++)
                {
                    RollosCortados = (DataRowView)BsRollos.AddNew()!;
                    RollosCortados.BeginEdit();
                    RollosCortados["roll_number"] = renglon;
                    RollosCortados["product_id"] = txt_product_id.Text;
                    RollosCortados["product_name"] = txt_product_name.Text;
                    RollosCortados["unique_code"] = "0";
                    RollosCortados["Width"] = grid_cortes.Rows[j].Cells["width"].Value;
                    RollosCortados["large"] = grid_cortes.Rows[0].Cells["Lenght"].Value;
                    RollosCortados["msi"] = grid_cortes.Rows[j].Cells["msi"].Value;
                    RollosCortados["splice"] = 0;
                    RollosCortados["roll_id"] = txt_rollid_1.Text;
                    RollosCortados["code_person"] = "n/t";
                    RollosCortados["status"] = "OK.";
                    RollosCortados.Row.SetParentRow(ParentRow.Row);
                    RollosCortados.EndEdit();
                    renglon += 1;
                }
            }
        }

        private void Btn_generar_rollos_Click(object sender, EventArgs e)
        {
            GENERAR_ROLLOS_CORTADOS();
        }

        private void Grid_cortes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int num = 0;
            for (int i = 0; i <= grid_cortes.Rows.Count - 1; i++)
            {
                num += (Convert.ToInt32(grid_cortes.Rows[i].Cells["width"].Value));
                txt_ancho_corte.Text = num.ToString();
            }
            //calcular los cortes a lo ancho
            txt_cortes_ancho.Text = grid_cortes.Rows.Count.ToString();
        }

        private void Txt_vueltas1_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txt_vueltas1.Text))
            {
                txt_vueltas1.Text = "0";
            }
        }

        private void Txt_long_cortar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_long_cortar.Text))
            {
                txt_long_cortar.Text = "0";
            }
        }

        private void Txt_plus1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_plus1.Text))
            {
                txt_plus1.Text = "0";
            }
        }

        private void Txt_menos1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_menos1.Text))
            {
                txt_menos1.Text = "0";
            }
        }

        private void Txt_plus2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_plus2.Text))
            {
                txt_plus2.Text = "0";
            }

        }

        private void Txt_menos2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_menos2.Text))
            {
                txt_menos2.Text = "0";
            }
        }


        private void Txt_vueltas1_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_vueltas1.Text))
            {
                txt_vueltas1.Text = "0";
            }

            if (grid_items.Rows.Count > 0) 
            {
                BorrarRollosCortadosHijos();
            }


        }

        private void Txt_vueltas1_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_vueltas1.Text))
            {
                txt_vueltas1.Value = 0;
            }
            CalcularConsumosLenght();
            CALCULAR_TOTAL_ROLLOS_CORTAR();
            if (grid_items.Rows.Count > 0)
            {
                BorrarRollosCortadosHijos();
            }
        }
        private void CalcularConsumosLenght()
        {
            double num = Convert.ToDouble(txt_long_cortar.Text) *
                Convert.ToDouble(txt_vueltas1.Value);
            txt_largo_corte.Text = num.ToString();
        }

        private void Txt_vueltas1_ValueChanged_1(object sender, EventArgs e)
        {

            CalcularConsumosLenght();
            CALCULAR_TOTAL_ROLLOS_CORTAR();
            if (grid_items.Rows.Count > 0)
            {
                BorrarRollosCortadosHijos();
            }

        }
        private void CALCULAR_TOTAL_ROLLOS_CORTAR()
        {
            //Multiplicacion de las vueltas x los cortes son los rollos totales a producir.
            int num = Convert.ToInt32(txt_vueltas1.Value) * Convert.ToInt32(txt_cortes_ancho.Text);
            txt_rollos_cortar1.Text = num.ToString();
        }
        private void BorrarRollosCortadosHijos()
        {
            if (Bs.Current == null) return;

            // Obtener la fila maestra actual como DataRowView
            DataRowView rowMaestro = (DataRowView)Bs.Current;

            // Obtener todas las filas hijas relacionadas
            DataRow[] filasHijas = rowMaestro.Row.GetChildRows("FK_MASTER_ROLLOS");

            // Eliminar cada fila hija
            foreach (DataRow filaHija in filasHijas)
            {
                filaHija.Delete();
            }

            // Actualizar el DataGridView
            BsRollos.EndEdit();

            // Si usas un DataAdapter, aquí iría la actualización a la base de datos
            // dataAdapterDetalle.Update(dataSet, "TablaDetalle");
        }


    }
}
