using Newtonsoft.Json;
using Ritrama2025.Forms.Buscadores;
using Ritrama2025.Forms.Otros;
using Ritrama2025.Forms.Seleccion;
using Ritrama2025.Models;
using Ritrama2025.Services.CommonService;
using Ritrama2025.Services.ExportData;
using Ritrama2025.Services.ProduccionService;
using Ritrama2025.Services.ReportsService.ReportsService;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace Ritrama2025.Forms;

public partial class FrmOrdenCorte : Form
{
    private readonly IProduccionService Service;
    private readonly IExportDataService ExportDataService;
    private readonly IReportsService ReportService;
    private readonly ICommonService CommonService;
    DataSet Ds = new();
    readonly BindingSource BsMaster = [];
    readonly BindingSource BsDetails = [];
    readonly BindingSource BsCortes = [];

    DataRowView ParentRow = null!;
    DataRowView ChildRowCortes = null!;
    DataRowView RollosCortados = null!;
    readonly string operadorId = "ff8fe855-0f8b-4062-8aa5-860d94f804d5";
    readonly string operadorName = "NO-ASIGNADO";
    private string TipoMovimiento = "";
    int EditMode = 0;
    Orden Orden { get; set; } = null!;
    List<Corte> Cortes { get; set; } = [];
    List<RolloCortado> Detalle { get; set; } = [];


    public FrmOrdenCorte(IProduccionService service, IExportDataService exportService, IReportsService reportService, ICommonService commonService)
    {
        InitializeComponent();
        Service = service;
        ExportDataService = exportService;
        ReportService = reportService;
        CommonService = commonService;
        BsMaster.PositionChanged += BsMaster_PositionChanged;
    }

    private void Dtrollos_RowDeleted(object sender, DataRowChangeEventArgs e)
    {
        if (e.Row.RowState == DataRowState.Deleted)
        {
            e.Row.RejectChanges();
        }
    }

    private void BsMaster_PositionChanged(object? sender, EventArgs e)
    {
        if (BsMaster.Current is DataRowView drv)
        {
            var row = drv.Row;
            if (row.RowState == DataRowState.Deleted)
            {
                row.RejectChanges();
                Ds.AcceptChanges();
            }
        }
    }

    private async void FrmOrdenCorte_Load(object sender, EventArgs e)
    {
        Ds = await Service.LoadDataOC();
        Ds.RejectChanges();        Ds.AcceptChanges();
        Ds.Tables["Dtrollos"]!.RowDeleted += Dtrollos_RowDeleted;
        //Enlace a datos Encabezado de la Orden Corte.
        HeaderBinding();
        BindingRollos();
        BindingCortes();
        UpdateStepIndicator();
        ContadorRegistros();
    }

    private void HeaderBinding()
    {
        BsMaster.DataSource = Ds;
        BsMaster.DataMember = "DtMaster";
        txt_numeroOC.DataBindings.Add("Text", BsMaster, "numero");
        txt_fecha_emision.DataBindings.Add("Text", BsMaster, "fecha");
        txt_fecha_produccion.DataBindings.Add("Text", BsMaster, "fecha_produccion");
        txt_rollid_1.DataBindings.Add("Text", BsMaster, "rollid_1");
        txt_width1.DataBindings.Add("Text", BsMaster, "width_1");
        txt_length1.DataBindings.Add("Text", BsMaster, "lenght_1");
        txt_real1_width.DataBindings.Add("Text", BsMaster, "util1_real_width");
        txt_real1_length.DataBindings.Add("Text", BsMaster, "util1_real_lenght");
        txt_real2_width.DataBindings.Add("Text", BsMaster, "util2_real_width");
        txt_real2_length.DataBindings.Add("Text", BsMaster, "util2_real_lenght");
        txt_rollid_2.DataBindings.Add("Text", BsMaster, "rollid_2");
        txt_width2.DataBindings.Add("Text", BsMaster, "width_2");
        txt_length2.DataBindings.Add("Text", BsMaster, "lenght_2");
        txt_matrest1_width.DataBindings.Add("Text", BsMaster, "rest1_width");
        txt_matrest1_lenght.DataBindings.Add("Text", BsMaster, "rest1_lenght");
        txt_matrest2_width.DataBindings.Add("Text", BsMaster, "rest2_width");
        txt_matrest2_lenght.DataBindings.Add("Text", BsMaster, "rest2_lenght");
        txt_product_id.DataBindings.Add("Text", BsMaster, "product_id");
        txt_product_name.DataBindings.Add("Text", BsMaster, "product_Name");
        txt_operador_id.DataBindings.Add("Text", BsMaster, "operador_id");
        txt_operador_name.DataBindings.Add("Text", BsMaster, "nombre");
        txt_cust_id.DataBindings.Add("Text", BsMaster, "customer_id");
        txt_cust_name.DataBindings.Add("Text", BsMaster, "customer_name");
        txt_resta_corte.DataBindings.Add("Text", BsMaster, "resta_entrada");
        txt_largo_corte.DataBindings.Add("Text", BsMaster, "lenght_entrada");
        txt_plus1.DataBindings.Add("Text", BsMaster, "plus1_pies");
        txt_plus2.DataBindings.Add("Text", BsMaster, "plus2_pies");
        txt_long_cortar.DataBindings.Add("Text", BsMaster, "longitud_cortar");
        txt_cortes_ancho.DataBindings.Add("Text", BsMaster, "cortes_ancho");
        txt_vueltas1.DataBindings.Add("Text", BsMaster, "cortes_largo");
        txt_rollos_cortar1.DataBindings.Add("Text", BsMaster, "cant_rollos");
        txt_ancho_corte.DataBindings.Add("Text", BsMaster, "total_salida");
        txt_step.DataBindings.Add("Text", BsMaster, "step");
        txt_sellOrder.DataBindings.Add("Text", BsMaster, "sellOrder");
        chk_desperdicio1.DataBindings.Add("Checked", BsMaster, "desperdicio", true);
        //check desperdicios.
        chk_desperdicio1.DataBindings["Checked"]!.Format += (s, e) =>
        {
            if (e.Value == DBNull.Value || e.Value == null) e.Value = false;
        };
        chk_desperdicio1.DataBindings["Checked"]!.Parse += (s, e) =>
        {
            if (e.Value == DBNull.Value || e.Value == null) e.Value = false;
        };
    }
    private void BindingRollos()
    {
        //Enlace a datos de Grid-Rollos Cortados.
        BsDetails.DataSource = BsMaster;
        BsDetails.DataMember = R.PARAMETERS.NAME_RELATION_OC_MASTER_DETAILS;

        grid_items.AutoGenerateColumns = false;
        ADD_COLUMN_GRID("roll_number", 23, "#", "roll_number", grid_items);
        ADD_COLUMN_GRID("product_id", 50, "Product Id", "product_id", grid_items);
        ADD_COLUMN_GRID("product_name", 210, "Product Name", "product_name", grid_items);
        ADD_COLUMN_GRID("unique_code", 65, "Unique Code", "unique_code", grid_items);
        ADD_COLUMN_GRID("width", 65, "Width [Inch]", "width", grid_items);
        ADD_COLUMN_GRID("large", 75, "Length [Pies]", "large", grid_items);
        ADD_COLUMN_GRID("msi", 60, "MSI", "msi", grid_items);
        ADD_COLUMN_GRID("splice", 40, "Splice", "splice", grid_items);
        ADD_COLUMN_GRID("roll_id", 70, "Roll Id.", "roll_id", grid_items);
        ADD_COLUMN_GRID("code_person", 60, "Code Person.", "code_person", grid_items);
        DataGridViewComboBoxColumn estado = new()
        {
            HeaderText = "Status",
            DropDownWidth = 200,
            Width = 110,
            FlatStyle = FlatStyle.Flat,
            Name = "status",
            DisplayMember = "status",
            ValueMember = "status",
            DataPropertyName = "status"
        };

        //Agregar las opciones.
        estado.Items.AddRange("Ok-Correcto", "Mal Estado", "Reservado", "Observacion");
        grid_items.Columns.Add(estado);
        BsDetails.Sort = "roll_number";
        grid_items.DataSource = BsDetails;
    }

    private void BindingCortes()
    {
        // Enlace a datos de Grid-Cortes.
        BsCortes.DataSource = BsMaster;
        BsCortes.DataMember = "FK_ENCABEZADO_CORTES";
        grid_cortes.AutoGenerateColumns = false;
        ADD_COLUMN_GRID("it", 30, "It.", "num", grid_cortes);
        ADD_COLUMN_GRID("width", 80, "Width [INCH]", "width", grid_cortes);
        ADD_COLUMN_GRID("lenght", 80, "Lenght [PIES]", "lenght", grid_cortes);
        ADD_COLUMN_GRID("msi", 80, "Msi", "msi", grid_cortes);
        grid_cortes.DataSource = BsCortes;
    }

    private void Bot_primero_Click(object sender, EventArgs e)
    {
        BsMaster.MoveFirst();
        UpdateStepIndicator();
        ContadorRegistros();
    }

    private void Bot_anterior_Click(object sender, EventArgs e)
    {
        BsMaster.MovePrevious();
        UpdateStepIndicator();
        ContadorRegistros();
    }

    private void Bot_siguiente_Click(object sender, EventArgs e)
    {
        BsMaster.MoveNext();
        UpdateStepIndicator();
        ContadorRegistros();
    }

    private void Bot_ultimo_Click(object sender, EventArgs e)
    {
        BsMaster.Position = BsMaster.Count + 1;
        UpdateStepIndicator();
        ContadorRegistros();
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
    private void Opt_create_document_Click(object sender, EventArgs e)
    {
        //1.- Inicialiozar el Documento de Orden de Corte.
        ParentRow = (DataRowView)BsMaster.AddNew()!;
        ParentRow.BeginEdit();
        ParentRow["numero"] = Service.BuscarConsecOC();
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
        ParentRow["cant_rollos2"] = "0";
        txt_menos1.Text = "0";
        txt_real1.Text = "0";
        txt_real2.Text = "0";
        txt_plus1.Text = "0";
        txt_menos2.Text = "0";
        txt_rollos_cortar2.Text = "0";
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
        if (grid_cortes.Rows.Count > 0)
        {
            grid_cortes.ClearSelection();
            grid_cortes.CurrentCell = grid_cortes.Rows[0].Cells[0];
            grid_cortes.Rows[0].Selected = true;
        }

        //OPERADOR POR DEFECTO.
        Service.CheckOperatorDefault(operadorId, operadorName);
        txt_operador_id.Text = operadorId;
        txt_operador_name.Text = operadorName;
        grid_cortes.ReadOnly = false;
        btn_add_row_corte.Enabled = true;
        btn_delete_row_corte.Enabled = true;
        txt_long_cortar.ReadOnly = false;
        txt_vueltas1.ReadOnly = false;
        btn_buscar_operador.Enabled = true;
        btn_buscar_customer.Enabled = true;
        //3.- Abrir los Textbox para editar los datos de la Orden de Corte.
        txt_fecha_emision.Enabled = true;
        txt_fecha_produccion.Enabled = true;
        txt_plus1.ReadOnly = false;
        txt_menos1.ReadOnly = false;
        txt_plus2.ReadOnly = false;
        txt_menos2.ReadOnly = false;
        txt_sellOrder.ReadOnly = false;
        btn_buscar_rollid1.Enabled = true;
        CloseToolsBar();
        //Controles del Formulario.
        btn_generar_rollos.Enabled = true;
        btn_add_row_corte.Enabled = true;
        btn_delete_row_corte.Enabled = true;
        txt_vueltas1.Enabled = true;
        txt_step.Text = "1";
        chk_desperdicio1.Enabled = true;
        btn_buscar_orden.Enabled = false;
        btn_generar_txt.Enabled = false;
        UpdateStepIndicator();
        EditMode = 1;
    }
    private void CloseToolsBar()
    {
        //Menu opciones
        bot_primero.Enabled = false;
        bot_siguiente.Enabled = false;
        bot_ultimo.Enabled = false;
        bot_anterior.Enabled = false;
        bot_accion.Enabled = false;
        bot_imprimir.Enabled = false;
        bot_exportar.Enabled = false;
        bot_editOrden.Enabled = false;
        bot_guardar.Enabled = true;
        bot_cancelar.Enabled = true;
        bot_buscarOrders.Enabled = false;
    }
    private void Btn_buscar_rollid1_Click(object sender, EventArgs e)
    {
        Frm_RollId frmrollid = new(Service)
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
            TipoMovimiento = frmrollid.MasterRoll.tipo_mov;
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
            CalcularConsumosLenght();
        }
        if (grid_items.Rows.Count > 0)
        {
            BorrarRollosCortadosHijos();
        }
        ACTUALIZAR_ROLLID_1();
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

    private void ACTUALIZAR_ROLLID_1()
    {
        //Actualiza lo real consumido del RollId 1
        txt_real1_width.Text = txt_ancho_corte.Text;
        txt_real1_length.Text = txt_largo_corte.Text;
        txt_matrest1_width.Text = txt_width1.Text;
        if (txt_real1_length.Text == "")
        {
            txt_real1_length.Text = "0";

        }
        if (txt_length1.Text == "")
        {
            txt_length1.Text = "0";

        }

        //Actualiza el material restante del RollId 1
        double num2 = Convert.ToDouble(txt_length1.Text) - Convert.ToDouble(txt_real1_length.Text);
        txt_matrest1_lenght.Text = num2.ToString("N2");
    }
    private void Btn_buscar_operador_Click(object sender, EventArgs e)
    {
        FrmSeleccion SelOperator = new()
        {
            DtItems = Ds.Tables["DtOperator"]!,
            Titulo = "operadores",
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
            Titulo = "clientes",
        };
        SelCust.ShowDialog();
        txt_cust_id.Text = SelCust.Id;
        txt_cust_name.Text = SelCust.Description;
    }
    private void GENERAR_ROLLOS_CORTADOS()
    {
        //VERIFICA SI EXISTEN ROLLOS ANTERIORES PARA BORRARLOS Y VOLVER A GENERARLOS.
        if (grid_items.Rows.Count > 0)
        {
            BorrarRollosCortadosHijos();
        }
        //CALCULO DE ROLLOS CORTADOS.
        int vueltas = Convert.ToInt32(txt_vueltas1.Text);
        int numcortes = (grid_cortes.Rows.Count);
        int renglon = 1;
        for (int i = 1; i <= vueltas; i++)
        {
            for (int j = 0; j <= numcortes - 1; j++)
            {
                RollosCortados = (DataRowView)BsDetails.AddNew()!;
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
                RollosCortados["status"] = "";
                RollosCortados.Row.SetParentRow(ParentRow.Row);
                RollosCortados.EndEdit();
                renglon += 1;
            }
        }
        BsDetails.Sort = "roll_number";
        if (grid_items.Rows.Count > 0)
        {
            grid_items.Focus();
            grid_items.Rows[0].Selected = true;
            grid_items.CurrentCell = grid_items.Rows[0].Cells[0];
        }
    }

    private void Btn_generar_rollos_Click(object sender, EventArgs e)
    {
        if (!ValidDefintionsCortes())
        {
            MessageBox.Show("debe definir los cortes primero...");
            return;
        }
        GENERAR_ROLLOS_CORTADOS();

        grid_items.ReadOnly = false;

        foreach (DataGridViewRow row in grid_items.Rows)
        {
            if (row.Cells["status"] is DataGridViewComboBoxCell comboCell)
            {
                comboCell.Value = comboCell.Items[0]; // Asignar la primera opción  
            }
        }






    }

    private void Grid_cortes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        //CALCULAR LA SUMATORIA DE WIDTH DE LOS CORTES 
        double num = 0;
        for (int i = 0; i <= grid_cortes.Rows.Count - 1; i++)
        {
            num += (Convert.ToDouble(grid_cortes.Rows[i].Cells["width"].Value));
            txt_ancho_corte.Text = num.ToString();
        }
        //calcular los cortes a lo ancho
        txt_cortes_ancho.Text = grid_cortes.Rows.Count.ToString();
        //ACTUALIZAR ROLLID_1
        ACTUALIZAR_ROLLID_1();
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
        ACTUALIZAR_ROLLID_1();
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
        ACTUALIZAR_ROLLID_1();

    }
    private void CALCULAR_TOTAL_ROLLOS_CORTAR()
    {
        if (txt_cortes_ancho.Text == "")
        {
            txt_cortes_ancho.Text = "0";
        }
        //Multiplicacion de las vueltas x los cortes son los rollos totales a producir.
        int num = Convert.ToInt32(txt_vueltas1.Value) * Convert.ToInt32(txt_cortes_ancho.Text);
        txt_rollos_cortar1.Text = num.ToString();
    }
    private void BorrarRollosCortadosHijos()
    {
        if (BsMaster.Current == null) return;

        // Obtener la fila maestra actual como DataRowView
        DataRowView rowMaestro = (DataRowView)BsMaster.Current;

        // Obtener todas las filas hijas relacionadas
        DataRow[] filasHijas = rowMaestro.Row.GetChildRows(R.PARAMETERS.NAME_RELATION_OC_MASTER_DETAILS);

        // Eliminar cada fila hija
        foreach (DataRow filaHija in filasHijas)
        {
            filaHija.Delete();
        }

        // Actualizar el DataGridView
        BsDetails.EndEdit();
    }
       
    private void CREATE_HEADER_ORDEN()
    {
        Orden = new()
        {
            Numero = Convert.ToInt32(txt_numeroOC.Text),
            Fecha = Convert.ToDateTime(txt_fecha_emision.Text),
            Fecha_produccion = Convert.ToDateTime(txt_fecha_produccion.Text),
            Rollid_1 = txt_rollid_1.Text,
            Width_1 = Convert.ToDecimal(txt_width1.Text),
            Lenght_1 = Convert.ToDecimal(txt_length1.Text),
            Util1_Real_Width = Convert.ToDouble(txt_real1_width.Text),
            Util1_real_Lenght = Convert.ToDouble(txt_real1_length.Text),
            Rest1_width = Convert.ToDouble(txt_matrest1_width.Text),
            Rest1_lenght = Convert.ToDouble(txt_matrest1_lenght.Text),
            Rollid_2 = txt_rollid_2.Text,
            Width_2 = Convert.ToDecimal(txt_width2.Text),
            Lenght_2 = Convert.ToDecimal(txt_length2.Text),
            Util2_Real_Width = Convert.ToDouble(txt_real2_width.Text),
            Util2_real_Lenght = Convert.ToDouble(txt_real2_length.Text),
            Rest2_width = Convert.ToDouble(txt_matrest2_width.Text),
            Rest2_lenght = Convert.ToDouble(txt_matrest2_lenght.Text),
            Product_id = txt_product_id.Text,
            Product_name = txt_product_name.Text,
            operador_id = Guid.Parse(txt_operador_id.Text),
            Nombre_operador = txt_operador_name.Text,
            Customer_Id = Guid.Parse(txt_cust_id.Text),
            Customer_Name = txt_cust_name.Text ?? string.Empty,
            Longitud_Cortar = Convert.ToDouble(txt_long_cortar.Text),
            Cortes_Largo = Convert.ToInt32(txt_vueltas1.Value),
            Cortes_Largo2 = Convert.ToInt32(txt_vueltas2.Value),
            Cortes_Ancho = Convert.ToInt32(txt_cortes_ancho.Text),
            Cantidad_Rollos = Convert.ToInt32(txt_rollos_cortar1.Text),
            Cantidad_Rollos2 = Convert.ToInt32(txt_rollos_cortar2.Text == "" ? 0 : txt_rollos_cortar2.Text),
            Anulada = false,
            Procesado = false,
            CloseDocument = false,
            Descartable1_pies = 0,
            Descartable2_pies = 0,
            Total_Inch_Ancho = Convert.ToDouble(txt_ancho_corte.Text == "" ? 0 : txt_ancho_corte.Text),
            Lenght_Master_Real = Convert.ToDouble(txt_real1.Text == "" ? 0 : txt_real1.Text),
            Master_lenght2_Real = Convert.ToDouble(txt_real2.Text == "" ? 0 : txt_real2.Text),
            LastUpdate = DateTime.Now,
            FechaAutorize = DateTime.Now,
            Step = 1,
            ToAutorize = "",
            Note = "",
            Plus1_pies = Convert.ToDecimal(txt_plus1.Text),
            Plus2_pies = Convert.ToDecimal(txt_plus2.Text),
            Tipo_Mov1 = "",
            Tipo_Mov2 = "",
            Rollo_unificado = chk_unificar_rollos.Checked,
            Lenght_entrada = 0,
            Real_usado_r1 = 0,
            Real_usado_r2 = 0,
            Restante_rollid1 = txt_matrest1_lenght.Text,
            Restante_rollid2 = txt_matrest2_lenght.Text,
            SellOrder = txt_sellOrder.Text == string.Empty ? "0" : txt_sellOrder.Text,
            Desperdicio = chk_desperdicio1.Checked
        };


    }

    private void CREATE_CORTES()
    {
        Cortes = [];
        for (int i = 0; i <= grid_cortes.Rows.Count - 1; i++)
        {
            //var codePersonValue = grid_cortes.Rows[i].Cells["code_person"].Value;
            //string codePerson = codePersonValue?.ToString() ?? string.Empty; // Ensure no null reference

            Corte corte = new()
            {
                Numero = i + 1,
                Width = Convert.ToDouble(grid_cortes.Rows[i].Cells["width"].Value),
                Length = Convert.ToDouble(grid_cortes.Rows[i].Cells["lenght"].Value),
                Msi = Convert.ToDouble(grid_cortes.Rows[i].Cells["msi"].Value),
                Orden = Convert.ToInt32(txt_numeroOC.Text)
            };
            Cortes.Add(corte);
        }

    }

    private void CREATE_DETALLE_ORDEN()
    {
        Detalle = [];
        for (int i = 0; i <= grid_items.Rows.Count - 1; i++)
        {
            var rollNumberValue = grid_items.Rows[i].Cells["roll_number"].Value;
            var uniqueCodeValue = grid_items.Rows[i].Cells["unique_code"].Value;
            var productIdValue = grid_items.Rows[i].Cells["product_id"].Value;
            var productNameValue = grid_items.Rows[i].Cells["product_name"].Value;
            var widthValue = grid_items.Rows[i].Cells["width"].Value;
            var lengthValue = grid_items.Rows[i].Cells["large"].Value;
            var msiValue = grid_items.Rows[i].Cells["msi"].Value;
            var spliceValue = grid_items.Rows[i].Cells["splice"].Value;
            var rollIdValue = grid_items.Rows[i].Cells["roll_id"].Value;
            var codePersonValue = grid_items.Rows[i].Cells["code_person"].Value;
            var statusRollo = grid_items.Rows[i].Cells["status"].Value;


            RolloCortado rollo = new()
            {
                Numero = txt_numeroOC.Text?.ToString() ?? string.Empty,
                UniqueCode = uniqueCodeValue?.ToString() ?? string.Empty,
                Product_Id = productIdValue?.ToString() ?? string.Empty,
                Product_Name = productNameValue?.ToString() ?? string.Empty,
                RollNumber = rollNumberValue != null ? Convert.ToInt32(rollNumberValue) : 0,
                Width = widthValue != null ? Convert.ToDecimal(widthValue) : 0,
                Length = lengthValue != null ? Convert.ToDecimal(lengthValue) : 0,
                Msi = msiValue != null ? Convert.ToDecimal(msiValue) : 0,
                Splice = spliceValue != null ? Convert.ToInt32(spliceValue) : 0,
                Roll_Id = rollIdValue?.ToString() ?? string.Empty,
                Cantidad_despacho = 0,
                Cantidad = 0,
                Tipo = "CORTADO",
                Paleta = string.Empty,
                Code_Person = codePersonValue?.ToString() ?? string.Empty,
                Ubicacion = ".",
                Status = statusRollo?.ToString() ?? string.Empty,
            };
            Detalle.Add(rollo);


        }



    }

    private void GuardarOrdeAddMode()
    {
        Service.GuardarEncabezadoOrdenCorte(Orden);
        Service.GuardarCortes(Cortes);
        Service.GuardarRollos(Detalle);
    }
    private void GuardarOrderUpdateMode()
    {
        Service.UpdateOrdenCorte(Orden);
    }


    private void Bot_guardar_Click(object sender, EventArgs e)
    {
        if (EditMode == 1) 
        {
            GuardarOrderNew();
        }
        if (EditMode == 2) 
        {
            GuardarOrderUpdate();
        }
        
    }

    private void GuardarOrderUpdate()
    {
        DataRowView rowMaestro = (DataRowView)BsMaster.Current!;

        if (rowMaestro == null) 
        {
            MessageBox.Show("Error al modifcar la orden de corte");
            return;
        } 

        var items = rowMaestro.Row.GetChildRows(R.PARAMETERS.NAME_RELATION_OC_MASTER_DETAILS);

        // Solución: Convertir cada DataRow modificado en un objeto RolloCortado
        List<RolloCortado> Lista = [.. items
            .Where(h => h.RowState == DataRowState.Modified)
            .Select(h => new RolloCortado
            {
                Numero = txt_numeroOC.Text?.ToString() ?? string.Empty,
                Splice = h["splice"] != null ? Convert.ToInt32(h["splice"]) : 0,
                UniqueCode = h["unique_code"]?.ToString() ?? string.Empty,
                Status = h["status"]?.ToString() ?? string.Empty,
                Code_Person = h["code_person"]?.ToString() ?? string.Empty
            })];

        //actualiza la base de datos.
        Service.Update_Items_Orden_Corte(Lista);

        //configurar la barra de herramientas
        bot_guardar.Enabled = false;
        bot_primero.Enabled = true;
        bot_siguiente.Enabled = true;
        bot_anterior.Enabled = true;
        bot_ultimo.Enabled = true;
        bot_accion.Enabled = true;
        bot_editOrden.Enabled = true;
        bot_imprimir.Enabled = true;
        bot_exportar.Enabled = true;
        btn_buscar_orden.Enabled = true;
        bot_buscarOrders.Enabled = true;
        bot_cancelar.Enabled = false;

        grid_items.ReadOnly = true;

        label_ModoEdition.Visible = false;
        ICON_EDITMODE.Visible = false;

        foreach (DataGridViewRow row in grid_items.Rows)
        {
            row.DefaultCellStyle.BackColor = Color.White;
        }

        //Modo Solo-Lectura.
        EditMode = 0;

        //actualizo la ui 
        BsDetails.EndEdit();
        BsMaster.EndEdit();
        grid_items.EndEdit();

        //generar el txt para 
        ExportDataService.ExportTxtFormatRollosCortados(BuscarItemsDetailsOrden(), false, Convert.ToDateTime(txt_fecha_produccion.Text).ToShortDateString(), Convert.ToDateTime(txt_fecha_emision .Text).ToShortDateString(), false);
    }

    private void GuardarOrderNew() 
    {
        //1.- Validar los datos del formulario.
        if (!Validar()) return;

        //2.- Crear los objetos (clases) de la Orden de Corte.
        CrearObjetoOrden();

        // 3.- Guardar el documento en la Base de Datos.
        SaveDocument();

        //4.- Actualizar la UI.
        RefrescarUI();

        //Crear el txt de rollos cortados
        ExportDataService.ExportTxtFormatRollosCortados(BuscarItemsDetailsOrden(), chk_generartxt_rc.Checked, Convert.ToDateTime(txt_fecha_produccion.Text).ToShortDateString(), Convert.ToDateTime(txt_fecha_produccion.Text).ToShortDateString(), false);

        EditMode = 0;
    }


    private void SaveDocument()
    {
        if (EditMode == 1)
        {
            GuardarOrdeAddMode();

            //Actualizar el consecutivo de la Orden de Corte den la Base de Datos.
            string UpdateConsecBd = (Convert.ToInt32(txt_numeroOC.Text) + 1).ToString();
            Service.UpdateConsecOC(UpdateConsecBd);
            ACTUALIZAR_INVENTARIOS_MASTER();
        }
        else if (EditMode == 2)
        {
            GuardarOrderUpdateMode();
        }
    }

    private void RefrescarUI()
    {
        BsMaster.MoveLast();
        BsMaster.EndEdit();
        BsMaster.ResetBindings(false);
        BsDetails.EndEdit();
        BsDetails.ResetBindings(false);
        Ds.Tables["DtMaster"]!.AcceptChanges();
        Ds.Tables["DtRollos"]!.AcceptChanges();
        grid_items.Refresh();
        CerrarForms();
        ContadorRegistros();
    }


    private bool Validar()
    {
        if (!ValidDefintionsCortes() || !ValidarDocumento())
            return false;

        return true;

    }

    private void CrearObjetoOrden()
    {
        //Actualizar la base de datos
        CREATE_HEADER_ORDEN();
        CREATE_CORTES();
        CREATE_DETALLE_ORDEN();
    }


    private bool ValidarDocumento()
    {
        bool validateDoc;
        if (txt_rollid_1.Text == "")
        {
            MessageBox.Show("debe seleccionar el roll-id del master a montar...");
            validateDoc = false;
            return validateDoc;
        }
        if (txt_operador_id.Text == "")
        {
            MessageBox.Show("debe introducir el nombre del operador...");
            validateDoc = false;
            return validateDoc;
        }
        if (txt_cust_id.Text == "" && txt_cust_name.Text == "")
        {
            MessageBox.Show("debe introducir los datos del cliente...");
            validateDoc = false;
            return validateDoc;
        }
        if (txt_long_cortar.Text == "")
        {
            MessageBox.Show("debe introducir la longitud a cortar...");
            validateDoc = false;
            return validateDoc;
        }
        if (txt_vueltas1.Value == 0)
        {
            MessageBox.Show("debe agregar el numero de vueltas...");
            validateDoc = false;
            return validateDoc;
        }
        if (grid_items.Rows.Count == 0)
        {
            MessageBox.Show("no tiene renglones de rollos cortados, debe generar los rollos ...");
            validateDoc = false;
            return validateDoc;
        }
        if (grid_cortes.Rows.Count == 0)
        {
            MessageBox.Show("no tiene la definicion de los cortres, definirla por favor...");
            validateDoc = false;
            return validateDoc;
        }
        return true;
    }

    private void CerrarForms()
    {
        //Menu opciones
        bot_primero.Enabled = true;
        bot_siguiente.Enabled = true;
        bot_ultimo.Enabled = true;
        bot_anterior.Enabled = true;
        bot_accion.Enabled = true;
        bot_imprimir.Enabled = true;
        bot_exportar.Enabled = true;
        bot_editOrden.Enabled = true;
        bot_buscarOrders.Enabled = true;
        bot_guardar.Enabled = false;
        bot_cancelar.Enabled = false;
        //botones formulario
        btn_buscar_customer.Enabled = false;
        btn_buscar_rollid1.Enabled = false;
        btn_buscar_rollid2.Enabled = false;
        btn_buscar_operador.Enabled = false;
        btn_generar_rollos.Enabled = false;
        btn_add_row_corte.Enabled = false;
        btn_delete_row_corte.Enabled = false;
        btn_buscar_orden.Enabled = true;
        btn_generar_txt.Enabled = true;
       
        //controles del formulario.
        txt_fecha_emision.Enabled = false;
        txt_fecha_produccion.Enabled = false;
        txt_plus1.ReadOnly = true;
        txt_plus2.ReadOnly = true;
        txt_menos1.ReadOnly = true;
        txt_menos2.ReadOnly = true;
        txt_sellOrder.ReadOnly = true;
        txt_vueltas1.Enabled = false;
        txt_largo_corte.Enabled = false;
        txt_long_cortar.ReadOnly = true;
        chk_desperdicio1.Enabled = false;
        grid_cortes.ReadOnly = true;

    }


    private async void ACTUALIZAR_INVENTARIOS_MASTER()
    {
        //actualizar la tabla de detalle de consumo parciales.
        double cons = txt_real1_length.Text == "" ? 0 : Convert.ToDouble(txt_real1_length.Text);
        var p = new { rollid = txt_rollid_1.Text, orden = txt_numeroOC.Text, consumo = cons, fecha = DateTime.Now, desperdicio = false };
        await Service.UpdateDetailsConsumosMasterIniciales(p.rollid, p.orden, p.consumo, p.fecha, p.desperdicio);


        //manejom de desperdicio.
        if (chk_desperdicio1.Checked)
        {
            double consumo_desper = txt_matrest1_lenght.Text == "" ? 0 : Convert.ToDouble(txt_matrest1_lenght.Text);
            var d = new { rollid = txt_rollid_1.Text, orden = txt_numeroOC.Text, consumo = consumo_desper, fecha = DateTime.Now, desperdicio = true };
            await Service.UpdateDetailsConsumosMasterIniciales(d.rollid, d.orden, d.consumo, d.fecha, d.desperdicio);
        }

        // actualiza el campo largo_consumido en orden_corte.
        double consumoParcial = txt_real1_length.Text == "" ? 0 : Convert.ToDouble(txt_real1_length.Text);
        string rollid = txt_rollid_1.Text;
        string nameTable = TipoMovimiento == "Inic." ? "MasterInic" : "ItemsMateria";
        string ssql = TipoMovimiento == "Inic." ? R.QUERY.PRODUCTION.SQL_QUERY_ACTUALIZAR_INVENTARIO_INICIALES :
            R.QUERY.PRODUCTION.SQL_QUERY_ACTUALIZAR_INVENTARIO_MATERIA;

        var objeto = new { consumo = consumoParcial, roll_id = rollid, nametable = nameTable, sql = ssql };

        await Service.UpdateInventaryMasterInitial(objeto);

        if (chk_desperdicio1.Checked)
        {
            double consumo_desperdicio = txt_matrest1_lenght.Text == "" ? 0 : Convert.ToDouble(txt_matrest1_lenght.Text);
            var objeto_desper = new { consumo = consumo_desperdicio, roll_id = rollid, nametable = nameTable, sql = ssql };

            await Service.UpdateInventaryMasterInitial(objeto_desper);
        }

        //actualiza el registro de la tabla de consumos parciales master [recarga los iniciales] EN LA UI.
        var fila = Ds.Tables["DtRollid"]!.AsEnumerable()
                            .FirstOrDefault(row => row.Field<string>("Roll_Id") == p.rollid);

        if (fila != null)
        {
            decimal cantidadActual = fila.Field<decimal>("largo_consumido");
            decimal length_original = fila.Field<decimal>("lenght");
            decimal cond = txt_real1_length.Text == "" ? 0 : Convert.ToDecimal(txt_real1_length.Text);

            if (chk_desperdicio1.Checked)
            {
                decimal consumo_desperdicio = txt_matrest1_lenght.Text == "" ? 0 : Convert.ToDecimal(txt_matrest1_lenght.Text);
                cond += consumo_desperdicio;
            }
            fila.SetField("largo_consumido", cantidadActual + cond);
            fila.SetField("largo_restante", length_original - (cantidadActual + cond));
            decimal restante = fila.Field<decimal>("largo_restante");
            decimal consumos = (cantidadActual + cond);

            string estado = restante == 0 ? "Agotado" :
                consumos == 0 ? "Completo" :
                "Parcialmente Utilizado";
            fila.SetField("estado", estado);
        }
    }

    private void ContadorRegistros()
    {
        registros.Text = "Registros: " + (BsMaster.Position + 1) + "/" + BsMaster.Count.ToString();
    }

    private void InitStepIndicator()
    {
        labelstep1.Visible = false;
        pictureBox1.Image = Properties.Resources.step1_deactivate;
        labelstep2.Visible = false;
        pictureBox2.Image = Properties.Resources.step2_deactivate;
        labelstep3.Visible = false;
        pictureBox3.Image = Properties.Resources.step3_deactive;
        labelstep4.Visible = false;
        pictureBox4.Image = Properties.Resources.step4_deactive;
        labelstep5.Visible = false;
        pictureBox5.Image = Properties.Resources.step5_deactive;
    }

    private void UpdateOptionMenuAction(bool b1, bool b2, bool b3, bool b4, bool b5)
    {
        opt_send_production.Enabled = b1;
        opt_etiquetar_orden.Enabled = b2;
        opt_aprobar_orden.Enabled = b3;
        opt_cerrar_orden.Enabled = b4;
        opt_modif_orden.Enabled = b5;
    }

    private void UpdateStepIndicator()
    {
        if (txt_step.Text == string.Empty) return;
        int opt = Convert.ToInt32(txt_step.Text);

        if (opt == 1)
        {
            InitStepIndicator();
            labelstep1.Visible = true;
            pictureBox1.Image = Properties.Resources.step1;
            UpdateOptionMenuAction(true, true, true, true, true);
        }
        if (opt == 2)
        {
            InitStepIndicator();
            labelstep2.Visible = true;
            pictureBox2.Image = Properties.Resources.step2_active;
            UpdateOptionMenuAction(false, true, true, true, true);
        }
        if (opt == 3)
        {
            InitStepIndicator();
            labelstep3.Visible = true;
            pictureBox3.Image = Properties.Resources.step3_active;
            UpdateOptionMenuAction(false, false, true, true, true);
        }
        if (opt == 4)
        {
            //Aprobado.
            InitStepIndicator();

            labelstep4.Visible = true;
            pictureBox4.Image = Properties.Resources.step4_active;
            UpdateOptionMenuAction(false, false, false, true, true);
        }
        if (opt == 5)
        {
            //Aprobado.
            InitStepIndicator();
            labelstep5.Visible = true;
            pictureBox5.Image = Properties.Resources.step5_active;
            UpdateOptionMenuAction(false, false, false, false, false);
        }
    }
    private void StateProductionOC()
    {
        //se actualiza en la Base de Datos
        Service.UpdateStatusDocumentOC(2, txt_numeroOC.Text);
        //se actualiza en la UI del Sistema.
        DataRowView FilaActual;
        FilaActual = (DataRowView)BsMaster.Current!;
        FilaActual["step"] = 2;
        BsMaster.EndEdit();
        UpdateStepIndicator();
        MessageBox.Show("Se ha cambiado el estatus del documento a PRODUCCION...");
    }

    private void Opt_send_production_Click(object sender, EventArgs e)
    {
        StateProductionOC();
    }
    private void EtiquetarOrdenCorte()
    {
        //se actualiza en la Base de Datos el step del documento
        Service.UpdateStatusDocumentOC(3, txt_numeroOC.Text);
        //actualiza la ui del textbox de step-indicator
        DataRowView FilaActual;
        FilaActual = (DataRowView)BsMaster.Current!;
        FilaActual["step"] = 3;
        BsMaster.EndEdit();
        //se actualiza el unique code
        if (BsMaster.Current == null) return;
        // Obtener la fila maestra actual como DataRowView
        DataRowView rowMaestro = (DataRowView)BsMaster.Current;
        // Obtener todas las filas hijas relacionadas
        DataRow[] filasHijas = rowMaestro.Row.GetChildRows(R.PARAMETERS.NAME_RELATION_OC_MASTER_DETAILS);
        int numero_unico = Service.BuscarUniqueCodeConsec();
        //actualiza la ui del datagrid items rollos cortados
        List<RolloCortado> rolls = [];
        foreach (DataRow item in filasHijas)
        {
            RolloCortado rollo = new();
            item.BeginEdit();
            numero_unico += 1;
            item["unique_code"] = "RC" + Convert.ToString(numero_unico);
            item.EndEdit();
            rollo.Numero = txt_numeroOC.Text;
            rollo.RollNumber = Convert.ToInt32(item["roll_number"]);
            rollo.UniqueCode = item["unique_code"].ToString()!;
            rolls.Add(rollo);
        }

        //se actualizan los rollos cortados en la BD con los unique code nuevos
        Service.UpdateUniqueCodeRollosCortados(rolls);

        //actualiza el consecutivo de codigo unico
        Service.UpdateUniqueCodeBD(numero_unico.ToString());
        //actualiza la ui del indicator
        UpdateStepIndicator();
        //se crea el txt de los rollos cortados.
        ExportDataService.ExportTxtFormatRollosCortados(BuscarItemsDetailsOrden(), chk_generartxt_rc.Checked, Convert.ToDateTime(txt_fecha_produccion.Text).ToShortDateString(), Convert.ToDateTime(txt_fecha_emision.Text).ToShortDateString(), false);

        MessageBox.Show("Se ha Etiquetado la Orden de Corte...");
    }

    private void Opt_etiquetar_orden_Click(object sender, EventArgs e)
    {
        EtiquetarOrdenCorte();
    }

    public DataRow[] BuscarItemsDetailsOrden()
    {
        DataRowView rowMaestro = (DataRowView)BsMaster.Current!;
        return rowMaestro.Row.GetChildRows(R.PARAMETERS.NAME_RELATION_OC_MASTER_DETAILS);
    }

    private void Btn_generar_txt_Click(object sender, EventArgs e)
    {

        ExportDataService.ExportTxtFormatRollosCortados(BuscarItemsDetailsOrden(), chk_generartxt_rc.Checked, Convert.ToDateTime(txt_fecha_produccion.Text).ToShortDateString(), Convert.ToDateTime(txt_fecha_produccion.Text).ToShortDateString(), true);
    }

    private void Bot_exportar_Click(object sender, EventArgs e)
    {
        List<RolloCortado> rollosCortados = CREATE_ROLLOS_CORTADOS();
        ExportDataService.ExportToExcel<RolloCortado>(rollosCortados, "RollosCortados.xlsx");
    }

    private List<RolloCortado> CREATE_ROLLOS_CORTADOS()
    {
        List<RolloCortado> Lista_Rollos = [];
        //picking-list;
        for (int i = 0; i <= grid_items.Rows.Count - 1; i++)
        {
            RolloCortado Rollo = new()
            {
                RollNumber = Convert.ToInt16(grid_items.Rows[i].Cells["Roll_Number"].Value),
                Product_Id = Convert.ToString(grid_items.Rows[i].Cells["product_id"].Value) ?? string.Empty,
                Product_Name = Convert.ToString(grid_items.Rows[i].Cells["product_name"].Value) ?? string.Empty,
                UniqueCode = Convert.ToString(grid_items.Rows[i].Cells["unique_code"].Value) ?? string.Empty,
                Width = Convert.ToDecimal(grid_items.Rows[i].Cells["width"].Value),
                Length = Convert.ToDecimal(grid_items.Rows[i].Cells["large"].Value),
                Msi = Convert.ToDecimal(grid_items.Rows[i].Cells["msi"].Value),
                Splice = Convert.ToInt16(grid_items.Rows[i].Cells["splice"].Value),
                Roll_Id = Convert.ToString(grid_items.Rows[i].Cells["roll_id"].Value) ?? string.Empty,
                Code_Person = Convert.ToString(grid_items.Rows[i].Cells["code_person"].Value) ?? string.Empty,
            };
            Lista_Rollos.Add(Rollo);
        }
        return Lista_Rollos;
    }

    private void Opt_aprobar_orden_Click(object sender, EventArgs e)
    {
        //cargar el formulario de aprobacion
        Frm_AprobarOC form = new(CommonService)
        {
            NumeroOC = txt_numeroOC.Text,
            TypeAction = "WRITE"
        };
        form.ShowDialog();
        //se actualiza en la Base de Datos
        Service.UpdateStatusDocumentOC(4, txt_numeroOC.Text);
        //actualiza la ui del textbox de step-indicator
        DataRowView FilaActual;
        FilaActual = (DataRowView)BsMaster.Current!;
        FilaActual["step"] = 4;
        BsMaster.EndEdit();
        UpdateStepIndicator();
    }

    private void Btn_datosDocAprob_Click(object sender, EventArgs e)
    {
        int opt = Convert.ToInt32(txt_step.Text);
        if (opt < 4)
        {
            MessageBox.Show("el documento no esta aprobado...");
            return;
        }
        Frm_AprobarOC form = new(CommonService)
        {
            NumeroOC = txt_numeroOC.Text,
            TypeAction = "READ"
        };
        form.ShowDialog();
    }

    private void Opt_cerrar_orden_Click(object sender, EventArgs e)
    {
        DialogResult resultado = MessageBox.Show("¿Realmente desea Cerrar la Orden de Corte", "Advertencia...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (resultado == DialogResult.Yes)
        {
            //se actualiza en la Base de Datos.
            Service.UpdateStatusDocumentOC(5, txt_numeroOC.Text);
            //actualiza la ui del textbox de step-indicator.
            UpdateUIStepIndicator(5);
            //actualizar el control de Step Indicator.
            UpdateStepIndicator();
        }
    }
    private void UpdateUIStepIndicator(int step)
    {
        DataRowView FilaActual;
        FilaActual = (DataRowView)BsMaster.Current!;
        FilaActual["step"] = step;
        BsMaster.EndEdit();

        //crear el txt de rollos cortados
        ExportDataService.ExportTxtFormatRollosCortados(BuscarItemsDetailsOrden(), chk_generartxt_rc.Checked, Convert.ToDateTime(txt_fecha_produccion.Text).ToShortDateString(), Convert.ToDateTime(txt_fecha_produccion.Text).ToShortDateString(), true);
    }

    private void Btn_buscar_orden_Click(object sender, EventArgs e)
    {
        Frm_oneparameter frmBuscar = new()
        {
            //MdiParent = (Form)this.Parent!,
            StartPosition = StartPosition = FormStartPosition.Manual,
            Location = new Point { X = Location.X + 300, Y = Location.Y + 150 }
        };
        frmBuscar.ShowDialog();
        if (frmBuscar.Parameter != null)
        {
            int busqueda = BsMaster.Find("numero", frmBuscar.Parameter);
            if (busqueda > 0)
            {
                BsMaster.Position = busqueda;
                UpdateStepIndicator();
                ContadorRegistros();
            }
            else
            {
                MessageBox.Show("No se encontro la orden de corte...", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    private void Bot_imprimir_Click(object sender, EventArgs e)
    {
        ReportService.Reporte_Orden_Corte(txt_numeroOC.Text, this, R.REPORT_NAME.REPORT_OC, R.REPORT_TITLE.REPORT_OC);
    }

    private void Bot_accion_Click(object sender, EventArgs e)
    {

    }

    private void Bot_cancelar_Click(object sender, EventArgs e)
    {
        DataRowView FilaActual;
        FilaActual = (DataRowView)BsMaster.Current!;
        FilaActual.Row.Delete();
        BsMaster.EndEdit();
        BsMaster.Position = BsMaster.Count;
        bot_primero.Enabled = true;
        bot_siguiente.Enabled = true;
        bot_ultimo.Enabled = true;
        bot_anterior.Enabled = true;
        bot_guardar.Enabled = false;
        bot_cancelar.Enabled = false;
        bot_imprimir.Enabled = true;
        bot_exportar.Enabled = true;
        bot_accion.Enabled = true;
        bot_editOrden.Enabled = true;
        //cerrar el formulario
        txt_long_cortar.ReadOnly = true;
        txt_vueltas1.ReadOnly = true;
        txt_vueltas2.ReadOnly = true;

        btn_add_row_corte.Enabled = false;
        btn_buscar_customer.Enabled = false;
        btn_buscar_operador.Enabled = false;
        btn_buscar_rollid1.Enabled = false;
        btn_buscar_rollid2.Enabled = false;
        btn_generar_rollos.Enabled = false;

    }

    private void Btn_add_row_corte_Click(object sender, EventArgs e)
    {
        RollosCortados = (DataRowView)BsCortes.AddNew()!;
        RollosCortados[0] = grid_cortes.Rows.Count.ToString();
        RollosCortados["width"] = 0;
        RollosCortados["lenght"] = 0;
        RollosCortados["msi"] = 0;
        RollosCortados["code_person"] = "S/N";
        RollosCortados.BeginEdit();

    }
    private bool ValidDefintionsCortes()
    {
        for (int i = 0; i < grid_cortes.Rows.Count; i++)
        {
            if (grid_cortes.Rows[i].Cells["width"].Value!.ToString() == "0" ||
                grid_cortes.Rows[i].Cells["lenght"].Value!.ToString() == "0" ||
                grid_cortes.Rows[i].Cells["msi"].Value!.ToString() == "0")
            {
                MessageBox.Show("Debe completar todas la definicion de los cortes antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        return true;
    }

    private void Btn_code_person_Click(object sender, EventArgs e)
    {
        if (txt_code_person.Text == "")
        {
            MessageBox.Show("Debe ingresar el codigo personalizado...", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        foreach (DataRowView row in BsDetails)
        {
            row["code_person"] = txt_code_person.Text.ToString();
        }
        Service.OrdenUpdateCodePerson(txt_numeroOC.Text, txt_code_person.Text);
        //Generar el txt de los rollos cortados.
        ExportDataService.ExportTxtFormatRollosCortados(BuscarItemsDetailsOrden(), chk_generartxt_rc.Checked, Convert.ToDateTime(txt_fecha_produccion.Text).ToShortDateString(), Convert.ToDateTime(txt_fecha_produccion.Text).ToShortDateString(), false);
    }

    private void Bot_buscar_Click(object sender, EventArgs e)
    {
        txt_fecha_emision.Enabled = true;
        txt_fecha_produccion.Enabled = true;
        btn_buscar_operador.Enabled = true;
        btn_buscar_customer.Enabled = true;
        txt_sellOrder.ReadOnly = false;
        chk_desperdicio1.Enabled = true;
        CloseToolsBar();
        EditMode = 2;
    }

    private void Bot_buscarOrders_Click(object sender, EventArgs e)
    {
        FrmBuscadorOC fbuscador = new()
        {
            DtItems = Ds.Tables["DtMaster"]!
        };
        fbuscador.ShowDialog();
        if (fbuscador.Orden != null && fbuscador.Orden != "")
        {
            int busqueda = BsMaster.Find("numero", fbuscador.Orden);
            if (busqueda > 0)
            {
                BsMaster.Position = busqueda;
            }
        }
    }

    private void Opt_modif_orden_Click(object sender, EventArgs e)
    {
        //configurar la barra de herramientas
        bot_guardar.Enabled = true;
        bot_primero.Enabled = false;
        bot_siguiente.Enabled = false;
        bot_anterior.Enabled = false;
        bot_ultimo.Enabled = false;
        bot_accion.Enabled = false;
        bot_editOrden.Enabled = false;
        bot_imprimir.Enabled = false;
        bot_exportar.Enabled = false;
        btn_buscar_orden.Enabled = false;
        bot_buscarOrders.Enabled = false;
        bot_cancelar.Enabled = true;

        //configurar elm grid
        grid_items.ReadOnly = false;
        grid_items.Columns[0].ReadOnly = true;
        grid_items.Columns[1].ReadOnly = true;
        grid_items.Columns[2].ReadOnly = true;
        grid_items.Columns[3].ReadOnly = true;
        grid_items.Columns[4].ReadOnly = true;
        grid_items.Columns[5].ReadOnly = true;
        grid_items.Columns[6].ReadOnly = true;
        grid_items.Columns[8].ReadOnly = true;
        
        //cambiar el color del grid.
        foreach (DataGridViewRow row in grid_items.Rows)
        {
            row.DefaultCellStyle.BackColor = Color.LightYellow;
        }

        label_ModoEdition.Visible = true;
        ICON_EDITMODE.Visible = true;

        EditMode = 2;

    }
}