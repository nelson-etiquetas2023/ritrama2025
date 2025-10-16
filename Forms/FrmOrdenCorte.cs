using Newtonsoft.Json;
using Ritrama2025.Forms.Buscadores;
using Ritrama2025.Forms.Otros;
using Ritrama2025.Forms.Seleccion;
using Ritrama2025.Models;
using Ritrama2025.Services.CommonService;
using Ritrama2025.Services.ExportData;
using Ritrama2025.Services.ProduccionService;
using Ritrama2025.Services.ReportsService.ReportsService;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

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
    string Rollid_master = string.Empty;
    Orden Orden { get; set; } = null!;
    List<Corte> Cortes { get; set; } = [];
    List<RolloCortado> Detalle { get; set; } = [];

    bool RecalcGridCortes = false;


   
    public FrmOrdenCorte(IProduccionService service, IExportDataService exportService, IReportsService reportService, ICommonService commonService)
    {
        InitializeComponent();
        Service = service;
        ExportDataService = exportService;
        ReportService = reportService;
        CommonService = commonService;
        this.AutoScaleMode = AutoScaleMode.Font;
    }



   

    private async void FrmOrdenCorte_Load(object sender, EventArgs e)
    {
        Ds = await Task.Run(() => Service.LoadDataOC());

        this.Invoke(() =>
        {
            BsMaster.DataSource = Ds;
            BsMaster.DataMember = "DtMaster";
            BsDetails.DataSource = BsMaster;
            BsDetails.DataMember = R.PARAMETERS.NAME_RELATION_OC_MASTER_DETAILS;
            Ds.Tables["DtMaster"]!.AcceptChanges();
            Ds.Tables["DtCortes"]!.AcceptChanges();
            Ds.Tables["DtRollos"]!.AcceptChanges();
            Ds.Tables["DtOperator"]!.AcceptChanges();
            Ds.Tables["DtCustomer"]!.AcceptChanges();

        });

        //Enlace a datos Encabezado de la Orden Corte.
        HeaderBinding();
        BindingRollos();
        BindingCortes();
        UpdateStepIndicator();
        ContadorRegistros();

        // Reemplaza la línea incorrecta en el método FrmOrdenCorte_Load:
        // BsMaster.PositionChanged += BsMaster_PositionChanged(object sender, EventArgs e);

        // Por la forma correcta de suscribirse al evento PositionChanged:
        BsMaster.PositionChanged += BsMaster_PositionChanged;
      
    }





    #region ENLACE A DATOS
    private void HeaderBinding()
    {
        txt_numeroOC.DataBindings.Add("Text", BsMaster, "numero");
        txt_fecha_emision.DataBindings.Add("Text", BsMaster, "fecha");
        txt_fecha_produccion.DataBindings.Add("Text", BsMaster, "fecha_produccion");
        txt_rollid_1.DataBindings.Add("Text", BsMaster, "rollid_1");

        txt_width1.DataBindings.Add("Text", BsMaster, "width_1");
        txt_length1.DataBindings.Add("Text", BsMaster, "lenght_1");

        txt_real1_width.DataBindings.Add("Text", BsMaster, "util1_real_width");
        txt_real1_length.DataBindings.Add("Text", BsMaster, "util1_real_lenght");
        txt_tipo_master.DataBindings.Add("Text", BsMaster, "master_tipo");

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
        txt_operador_id.DataBindings.Add("Text", BsMaster, "operador_id", true, DataSourceUpdateMode.OnPropertyChanged);
        txt_operador_name.DataBindings.Add("Text", BsMaster, "nombre");
        txt_cust_id.DataBindings.Add("Text", BsMaster, "customer_id", true, DataSourceUpdateMode.OnPropertyChanged);
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
        txt_ubic.DataBindings.Add("Text", BsMaster, "Ubicacion");
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

        chk_ConfigVueltas.DataBindings.Add("Checked", BsMaster, "configvueltas");
        chk_ConfigVueltas.DataBindings["Checked"]!.Format += (s, e) =>
        {
            if (e.Value == DBNull.Value || e.Value == null) e.Value = false;
        };
        chk_ConfigVueltas.DataBindings["Checked"]!.Parse += (s, e) =>
        {
            if (e.Value == DBNull.Value || e.Value == null) e.Value = false;
        };

    }
    private void BindingRollos()
    {
        //Enlace a datos de Grid-Rollos Cortados.
        grid_items.AutoGenerateColumns = false;
        grid_items.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
        ADD_COLUMN_GRID("vuelta", 60, "Vuelta", "vuelta", grid_items);

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
        grid_items.Columns[4].DefaultCellStyle.Format = "N3";
        grid_items.Columns[5].DefaultCellStyle.Format = "N3";
        grid_items.Columns[6].DefaultCellStyle.Format = "N3";
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
        grid_cortes.Columns[1].DefaultCellStyle.Format = "N3";
        grid_cortes.Columns[2].DefaultCellStyle.Format = "N3";
        grid_cortes.Columns[3].DefaultCellStyle.Format = "N3";
        grid_cortes.DataSource = BsCortes;
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
    #endregion

    #region CALCULAR ORDEN-CORTE
    private void Btn_buscar_rollid1_Click(object sender, EventArgs e)
    {
        Frm_RollId frmrollid = new(Service)
        {
            DtRollid = Ds.Tables["DtRollid"]!
        };
        frmrollid.ShowDialog();
        if (frmrollid.MasterRoll != null)
        {
            Rollid_master = frmrollid.MasterRoll.Roll_Id;
            txt_rollid_1.Text = Convert.ToString(frmrollid.MasterRoll.Roll_Id);
            txt_width1.Text = frmrollid.MasterRoll.Width.ToString("N2");
            txt_length1.Text = frmrollid.MasterRoll.Length.ToString("N2");
            txt_real1.Text = frmrollid.MasterRoll.Length.ToString("N2");
            txt_product_id.Text = frmrollid.MasterRoll.Product_Id;
            txt_product_name.Text = frmrollid.MasterRoll.Product_Name;
            TipoMovimiento = frmrollid.MasterRoll.tipo_mov;
            txt_tipo_master.Text = frmrollid.MasterRoll.tipo_mov;

            CALCULATE_TOTAL_WIDTH_CORTES();
            CALCULATE_MATERIAL_RESTANTE();

            this.Validate();

            txt_rollid_1.Focus();
            txt_rollid_1.Select();

            BsMaster.EndEdit();
            Ds.Tables["DtMaster"]!.AcceptChanges();
            BsMaster.ResetBindings(false);


        }
    }
    private void CALCULATE_MATERIAL_RESTANTE()
    {
        double material_rest_width = Convert.ToDouble(txt_width1.Text) - Convert.ToDouble(txt_real1_width.Text);

        double material_rest_len = Convert.ToDouble(txt_length1.Text) - Convert.ToDouble(txt_real1_length.Text);


        txt_matrest1_width.Text = (Math.Round(material_rest_width, 2)).ToString("N2");

        txt_matrest1_lenght.Text = (Math.Round(material_rest_len, 2)).ToString("N2");


    }
    private void CALCULATE_DATA_CORTES()
    {
        if (EditMode == 0) return;

        double long_cortar = txt_long_cortar.Text == string.Empty ? 0 : Convert.ToDouble(txt_long_cortar.Text);

        if (long_cortar <= 0) return;

        for (int i = 0; i <= grid_cortes.Rows.Count - 1; i++)
        {
            //llenar la columna length.
            grid_cortes.Rows[i].Cells["lenght"].Value = long_cortar;
            //calcular el msi.
            grid_cortes.Rows[i].Cells["msi"].Value = Convert.ToDouble(grid_cortes.Rows[i].Cells["width"].Value) * Convert.ToDouble(grid_cortes.Rows[i].Cells["lenght"].Value) * R.CONSTANTES.FACTOR_CALCULO_MSI;

            //ASIGNAR CORTES A LO ANCHO.
            txt_cortes_ancho.Text = grid_cortes.Rows.Count.ToString();

            CalcularLONGITUDACORTAR();
        }

        ACTUALIZAR_ROLLID_1();
    }
    private void ACTUALIZAR_ROLLID_1()
    {

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
    private void Txt_vueltas1_KeyUp(object sender, KeyEventArgs e)
    {
        if (!string.IsNullOrEmpty(txt_vueltas1.Text) && !string.IsNullOrEmpty(txt_cortes_ancho.Text))
        {
            double num = Convert.ToDouble(txt_cortes_ancho.Text) * Convert.ToDouble(txt_vueltas1.Text);
            txt_rollos_cortar1.Text = num.ToString();
        }
        CalcularLONGITUDACORTAR();
    }
    private void GENERAR_ROLLOS_CORTADOS()
    {
        //VERIFICA SI EXISTEN ROLLOS ANTERIORES PARA BORRARLOS Y VOLVER A GENERARLOS.
        if (grid_items.Rows.Count > 0)
        {
            BorrarRollosCortadosHijos();
        }
        //CALCULO DE ROLLOS CORTADOS.
        if (EditMode == 2)
        {
            ParentRow = (DataRowView)BsMaster.Current!;
        }
        int vueltas = Convert.ToInt32(txt_vueltas1.Text);
        int numcortes = (grid_cortes.Rows.Count);
        int renglon = 1;
        for (int i = 1; i <= vueltas; i++)
        {
            int numvuelta = i;
            for (int j = 0; j <= numcortes - 1; j++)
            {
                RollosCortados = (DataRowView)BsDetails.AddNew()!;
                RollosCortados.BeginEdit();
                RollosCortados["roll_number"] = renglon;
                RollosCortados["product_id"] = txt_product_id.Text;
                RollosCortados["product_name"] = txt_product_name.Text;
                RollosCortados["unique_code"] = "0";
                RollosCortados["Width"] = grid_cortes.Rows[j].Cells["width"].Value;
                RollosCortados["large"] = grid_cortes.Rows[j].Cells["Lenght"].Value;
                RollosCortados["msi"] = grid_cortes.Rows[j].Cells["msi"].Value;
                RollosCortados["splice"] = 0;
                RollosCortados["roll_id"] = txt_rollid_1.Text;
                RollosCortados["code_person"] = "n/t";
                RollosCortados["vuelta"] = numvuelta;
                RollosCortados["status"] = "";

                RollosCortados.Row.SetParentRow(ParentRow.Row);
                RollosCortados.EndEdit();
                renglon += 1;
            }
        }
        //BsDetails.Sort = "roll_number";
        if (grid_items.Rows.Count > 0)
        {
            grid_items.Focus();
            grid_items.Rows[0].Selected = true;
            grid_items.CurrentCell = grid_items.Rows[0].Cells[0];
        }
    }
    private void Btn_generar_rollos_Click(object sender, EventArgs e)
    {
        if (txt_rollid_1.Text == "0")
        {
            MessageBox.Show("Tiene que seleccionar un roll-id primero... ");
            return;
        }
        if (txt_product_id.Text == "0")
        {
            MessageBox.Show("Tiene que seleccionar un producto primero... ");
            return;
        }

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
    private void CALCULATE_TOTAL_WIDTH_CORTES()
    {
        double num = 0;
        for (int i = 0; i <= grid_cortes.Rows.Count - 1; i++)
        {
            num += (Convert.ToDouble(grid_cortes.Rows[i].Cells["width"].Value));
            txt_ancho_corte.Text = num.ToString();
            txt_real1_width.Text = num.ToString();
        }
    }
    private void Grid_cortes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {

        txt_cortes_ancho.Text = grid_cortes.Rows.Count.ToString();

        CALCULATE_TOTAL_WIDTH_CORTES();
        ACTUALIZAR_ROLLID_1();
        CALCULATE_MATERIAL_RESTANTE();
        CALCULAR_TOTAL_ROLLOS_CORTAR();
        GENERAR_ROLLOS_CORTADOS();
    }
    private void ReCalcularDocumento(int fil)
    {

        if (!RecalcGridCortes)
        {
            RecalcGridCortes = true;
            grid_cortes.Rows[fil].Cells["msi"].Value = Convert.ToDouble(grid_cortes.Rows[fil].Cells["width"].Value) * Convert.ToDouble(grid_cortes.Rows[fil].Cells["lenght"].Value) * R.CONSTANTES.FACTOR_CALCULO_MSI;

        }

        CALCULATE_TOTAL_WIDTH_CORTES();

        int vueltas = Convert.ToInt32(txt_vueltas1.Text);
        int numcortes = (grid_cortes.Rows.Count);
        int indice = 0;
        for (int i = 1; i <= vueltas; i++)
        {
            for (int j = 0; j <= numcortes - 1; j++)
            {
                DataRowView fila = (DataRowView)BsDetails[indice]!;
                fila["large"] = grid_cortes.Rows[j].Cells["Lenght"].Value;
                fila["msi"] = Convert.ToDouble(grid_cortes.Rows[j].Cells["width"].Value) * Convert.ToDouble(grid_cortes.Rows[j].Cells["lenght"].Value) * R.CONSTANTES.FACTOR_CALCULO_MSI;

                indice += 1;
                fila.EndEdit();
            }
        }
        Ds.Tables["DtRollos"]!.AcceptChanges();
        RecalcGridCortes = false;
    }
    private void CalcularLONGITUDACORTAR()
    {
        if (txt_long_cortar.Text == string.Empty) return;

        double num = Convert.ToDouble(txt_long_cortar.Text) *
            Convert.ToDouble(txt_vueltas1.Value);

        txt_largo_corte.Text = num.ToString();
        txt_real1_length.Text = num.ToString();
    }
    private void Txt_vueltas1_ValueChanged_1(object sender, EventArgs e)
    {
        if (EditMode == 0) return;
        CalcularLONGITUDACORTAR();
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

        if (EditMode == 0) return;
        if (BsMaster.Current == null) return;


        Ds.EnforceConstraints = false;
        BsMaster.EndEdit();
        BsCortes.EndEdit();
        BsDetails.EndEdit();

        // Obtener las filas hijas actuales (excluye eliminadas)
        var filasHijas = BuscarItemsDetailsOrden();

        foreach (var filaHija in filasHijas)
        {
            if (filaHija.RowState != DataRowState.Deleted && filaHija.RowState != DataRowState.Detached)
            {
                filaHija.Delete(); // Marca como Deleted
            }
        }

        Ds.Tables["DtMaster"]!.AcceptChanges();
        Ds.Tables["DtRollos"]!.AcceptChanges();
        Ds.Tables["DtCortes"]!.AcceptChanges();
        BsMaster.ResetBindings(false);
        BsDetails.ResetBindings(false);
        BsCortes.ResetBindings(false);
        Ds.EnforceConstraints = false;
    }
    private void Txt_long_cortar_KeyUp(object sender, KeyEventArgs e)
    {
        if (EditMode == 0) return;

        double longitud_cortar = txt_long_cortar.Text != "" ? Convert.ToDouble(txt_long_cortar.Text) : 0;

        if (longitud_cortar > 0)
        {
            CALCULATE_DATA_CORTES();
            CALCULAR_TOTAL_ROLLOS_CORTAR();
            if (grid_items.Rows.Count > 0)
            {
                BorrarRollosCortadosHijos();
            }

        }
    }


    #endregion

    #region FORMS UI
    private void CloseUIFormAddNewMode()
    {
        //4.- Actualizar la UI.
        RefrescarUI();

        //Crear el txt de rollos cortados
        ExportDataService.ExportTxtFormatRollosCortados(BuscarItemsDetailsOrden(), chk_generartxt_rc.Checked, Convert.ToDateTime(txt_fecha_produccion.Text).ToShortDateString(), Convert.ToDateTime(txt_fecha_produccion.Text).ToShortDateString(), false);

        EditMode = 0;
    }
    private void CloseUIFormUpdateMode()
    {
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

        txt_fecha_emision.Enabled = false;
        txt_fecha_produccion.Enabled = false;


        btn_buscar_rollid1.Enabled = false;
        chk_desperdicio1.Enabled = false;
        btn_buscar_operador.Enabled = false;
        txt_sellOrder.ReadOnly = true;
        btn_generar_rollos.Enabled = false;
        txt_long_cortar.ReadOnly = true;
        txt_vueltas1.Enabled = false;
        txt_ubic.ReadOnly = true;
        grid_items.ReadOnly = true;

        btn_add_row_corte.Enabled = false;
        btn_delete_row_corte.Enabled = false;
        btn_buscar_customer.Enabled = false;

        label_ModoEdition.Visible = false;
        ICON_EDITMODE.Visible = false;

        foreach (DataGridViewRow row in grid_items.Rows)
        {
            row.DefaultCellStyle.BackColor = Color.White;
        }

        //actualizo la ui 
        BsDetails.EndEdit();
        BsMaster.EndEdit();
        grid_items.EndEdit();

        //generar el txt para 
        ExportDataService.ExportTxtFormatRollosCortados(BuscarItemsDetailsOrden(), false, Convert.ToDateTime(txt_fecha_produccion.Text).ToShortDateString(), Convert.ToDateTime(txt_fecha_emision.Text).ToShortDateString(), false);

        //Modo Solo-Lectura.
        EditMode = 0;

    }
    private void ContadorRegistros()
    {
        registros.Text = "Registros: " + (BsMaster.Position + 1) + "/" + BsMaster.Count.ToString();
    }
    private void UpdateOptionMenuAction(bool b1, bool b2, bool b3, bool b4, bool b5)
    {
        opt_send_production.Enabled = b1;
        opt_etiquetar_orden.Enabled = b2;
        opt_aprobar_orden.Enabled = b3;
        opt_cerrar_orden.Enabled = b4;
        opt_modif_orden.Enabled = b5;
    }
    private void Txt_vueltas1_Enter(object sender, EventArgs e)
    {
        var numeric = (NumericUpDown)sender;

        if (string.IsNullOrWhiteSpace(numeric.Text))
            numeric.Text = "0";

        numeric.BeginInvoke(new Action(() =>
        {
            numeric.Select(0, numeric.Text.Length);
        }));

    }
    private void Txt_long_cortar_Enter(object sender, EventArgs e)
    {
        var txt = (TextBox)sender;

        if (string.IsNullOrWhiteSpace(txt.Text))
            txt.Text = "0";

        txt.BeginInvoke(new Action(() => txt.SelectAll()));
    }
    private void Grid_cortes_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
        var grid = (DataGridView)sender;

        // Mostrar contexto del error
        MessageBox.Show($"Error en celda [{e.RowIndex}, {e.ColumnIndex}]: {e.Context}",
                        "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        // Si es una excepción de restricción (por ejemplo, clave duplicada o nulo no permitido)
        if (e.Exception is ConstraintException)
        {
            grid.Rows[e.RowIndex].ErrorText = "Error de restricción en los datos.";
            grid.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Dato inválido.";
            e.ThrowException = false; // Evita que se propague la excepción
        }

        // Puedes cancelar el error si no quieres que se propague
        e.Cancel = true;

    }
    private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
    {
        // Permitir solo números y control (Backspace, Supr, etc.)
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
        {
            e.Handled = true;
        }
    }
    private void Txt_long_cortar_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
        }
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
    private void Txt_menos2_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txt_menos2.Text))
        {
            txt_menos2.Text = "0";
        }
    }
    #endregion

    #region ACTIONS ADD-UPDATE-CANCEL
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
            var vuelta = grid_items.Rows[i].Cells["vuelta"].Value;


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
                Disponible = false,
                vuelta = vuelta != null ? Convert.ToInt32(vuelta) : 0,
            };
            Detalle.Add(rollo);
        }
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
            Operador_id = Guid.Parse(txt_operador_id.Text),
            Nombre_operador = txt_operador_name.Text,
            Customer_Id = Guid.Parse(txt_cust_id.Text),
            Customer_Name = txt_cust_name.Text ?? string.Empty,
            Longitud_Cortar = Convert.ToDouble(txt_long_cortar.Text),
            Cortes_Largo = Convert.ToInt32(txt_vueltas1.Value),
            Cortes_Largo2 = Convert.ToInt32(txt_vueltas2.Value),
            Cortes_Ancho = Convert.ToInt32(txt_cortes_ancho.Text),
            Cantidad_Rollos = Convert.ToInt32(txt_rollos_cortar1.Text),
            //Cantidad_Rollos2 = Convert.ToInt32(txt_rollos_cortar2.Text == "" ? 0 : txt_rollos_cortar2.Text),
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
            Desperdicio = chk_desperdicio1.Checked,
            Master_Tipo = TipoMovimiento,
            Ubicacion = txt_ubic.Text == string.Empty ? "n/t" : txt_ubic.Text,
        };
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


    private async void Bot_guardar_Click(object sender, EventArgs e)
    {
        if (EditMode == 1)
        {
            //1.- Validar los datos del formulario.
            if (!Validar()) return;

            Toggleloading(true);
            await Task.Run(() => GuardarOrderNew());
            Toggleloading(false);
            this.Invoke(() =>
            {
                CloseUIFormAddNewMode();
            });
        }
        if (EditMode == 2)
        {
            //
            if (grid_items.Rows.Count <= 0)
            {
                MessageBox.Show("No hay rollos cortados para guardar...");
                return;
            }

            Toggleloading(true);
            await Task.Run(() => GuardarOrderUpdate());
            Toggleloading(false);
            this.Invoke(() =>
            {
                CloseUIFormUpdateMode();
            });
        }
    }
    private async Task GuardarOrderUpdate()
    {

        if (txt_operador_id.Text == "" && txt_cust_id.Text == "")
        {
            MessageBox.Show("debe introducir los datos del operador y cliente...");
            return;
        }
        //Modificaciones en el header de la OC.

        Orden orden = new()
        {
            Numero = Convert.ToInt16(txt_numeroOC.Text),
            Fecha = Convert.ToDateTime(txt_fecha_emision.Text),
            Fecha_produccion = Convert.ToDateTime(txt_fecha_produccion.Text),
            Rollid_1 = txt_rollid_1.Text,
            Width_1 = Convert.ToDecimal(txt_width1.Text),
            Lenght_1 = Convert.ToDecimal(txt_length1.Text),
            Util1_Real_Width = Convert.ToDouble(txt_real1_width.Text),
            Util1_real_Lenght = Convert.ToDouble(txt_real1_length.Text),
            Rest1_width = Convert.ToDouble(txt_matrest1_width.Text),
            Rest2_lenght = Convert.ToDouble(txt_matrest1_lenght.Text),
            Product_id = txt_product_id.Text.ToString(),
            Product_name = txt_product_name.Text.ToString(),
            Desperdicio = chk_desperdicio1.Checked,
            Operador_id = new Guid(txt_operador_id.Text),
            Customer_Id = new Guid(txt_cust_id.Text),
            Longitud_Cortar = Convert.ToDouble(txt_long_cortar.Text),
            Cortes_Largo = Convert.ToInt32(txt_vueltas1.Value),
            Cortes_Ancho = Convert.ToInt32(txt_cortes_ancho.Text),
            Cantidad_Rollos = Convert.ToInt32(txt_rollos_cortar1.Text),
            SellOrder = txt_sellOrder.Text == string.Empty ? "0" : txt_sellOrder.Text,
            Ubicacion = txt_ubic.Text == string.Empty ? "n/t" : txt_ubic.Text,
            ConfigVueltas = chk_ConfigVueltas.Checked
        };
        CREATE_CORTES();
        orden.Cortes = Cortes;
        CREATE_DETALLE_ORDEN();
        orden.rollos = Detalle;

        //actualiza el encabezado de la OC.
        await Task.Run(() => Service.Update_Header_Documnet_OC(orden));

        //actualiza la base de datos los items rollos.
        //Service.Update_Items_Orden_Corte(Lista);

    }
    private void SaveDocument()
    {
        if (EditMode == 1)
        {
            GuardarOrdeAddMode();

            //Actualizar el consecutivo de la Orden de Corte den la Base de Datos.
            string UpdateConsecBd = (Convert.ToInt32(txt_numeroOC.Text) + 1).ToString();
            Service.UpdateConsecOC(UpdateConsecBd);

        }
    }
    private void GuardarOrderNew()
    {
        //2.- Crear los objetos (clases) de la Orden de Corte.
        CrearObjetoOrden();

        // 3.- Guardar el documento en la Base de Datos.
        SaveDocument();
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

        //txt_rollos_cortar2.Text = "0";
        txt_ancho_corte.Text = "0";

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
        txt_ubic.ReadOnly = false;
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
    private void Opt_modif_orden_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt16(txt_step.Text) != 2)
        {
            MessageBox.Show("Solo se puede modificar la orden en estado de PRODUCCION...", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

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
        btn_buscar_rollid1.Enabled = true;
        btn_vueltas.Enabled = true;


        //configurar el grid
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


        //cambiar fecha.
        txt_fecha_emision.Enabled = true;
        txt_fecha_produccion.Enabled = true;
        //desperdicio
        chk_desperdicio1.Enabled = true;
        //grid de cortes

        grid_cortes.ReadOnly = false;




        //ICONO DE EDICION
        label_ModoEdition.Visible = true;
        ICON_EDITMODE.Visible = true;

        //operador
        btn_buscar_operador.Enabled = true;

        //cliente
        btn_buscar_customer.Enabled = true;
        txt_sellOrder.ReadOnly = false;

        //botones de corte.
        btn_add_row_corte.Enabled = true;
        btn_delete_row_corte.Enabled = true;

        //longitud a cortar  
        txt_long_cortar.ReadOnly = false;
        txt_vueltas1.Enabled = true;
        txt_ubic.ReadOnly = false;

        btn_generar_rollos.Enabled = true;

        Ds.Tables["DtMaster"]!.AcceptChanges();
        Ds.Tables["DtCortes"]!.AcceptChanges();
        Ds.Tables["DtRollos"]!.AcceptChanges();
        Ds.Tables["DtCustomer"]!.AcceptChanges();
        Ds.Tables["DtOperator"]!.AcceptChanges();
        BsMaster.ResetBindings(false);
        BsDetails.ResetBindings(false);
        BsCortes.ResetBindings(false);

        EditMode = 2;

    }
    private void Bot_cancelar_Click(object sender, EventArgs e)
    {

        //para borrar el documento se eliminan las filas primero y luego la fila master.
        if (BsMaster.Current is DataRowView drvMaster)
        {

            DataRow RowMaster = drvMaster.Row;
            DataRow[] items = RowMaster.GetChildRows(R.PARAMETERS.NAME_RELATION_OC_MASTER_DETAILS);

            //borrar los rollos cortados.
            foreach (var item in items)
            {
                item.Delete();
            }

            //borrar los cortes
            DataRow[] cortes_del = RowMaster.GetChildRows("FK_ENCABEZADO_CORTES");
            foreach (var cor_item in cortes_del)
            {
                cor_item.Delete();
            }

            //se borra la orden de corte en master
            RowMaster.Delete();

        }

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
        btn_buscar_orden.Enabled = true;
        EditMode = 0;
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
    private void CrearObjetoOrden()
    {
        //Actualizar la base de datos
        CREATE_HEADER_ORDEN();
        CREATE_CORTES();
        CREATE_DETALLE_ORDEN();
    }
    #endregion

    #region LIFECYCLE-DOCUMENT
    private void UpdateUIStepIndicator(int step)
    {
        DataRowView FilaActual;
        FilaActual = (DataRowView)BsMaster.Current!;
        FilaActual["step"] = step;
        BsMaster.EndEdit();

        //crear el txt de rollos cortados
        ExportDataService.ExportTxtFormatRollosCortados(BuscarItemsDetailsOrden(), chk_generartxt_rc.Checked, Convert.ToDateTime(txt_fecha_produccion.Text).ToShortDateString(), Convert.ToDateTime(txt_fecha_produccion.Text).ToShortDateString(), true);
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
    private async void Opt_cerrar_orden_Click(object sender, EventArgs e)
    {
        DialogResult resultado = MessageBox.Show("¿Realmente desea Cerrar la Orden de Corte", "Advertencia...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (resultado == DialogResult.Yes)
        {
            Toggleloading(true);
            //se actualiza en la Base de Datos.
            Service.UpdateStatusDocumentOC(5, txt_numeroOC.Text);
            //actualiza la ui del textbox de step-indicator.
            UpdateUIStepIndicator(5);
            //actualizar el control de Step Indicator.
            UpdateStepIndicator();
            //actualizar los inventarios del master.

            await Task.Run(() =>
            {
                ACTUALIZAR_INVENTARIOS_MASTER();
            });
            Toggleloading(false);

        }
    }
    private void Opt_send_production_Click(object sender, EventArgs e)
    {
        StateProductionOC();
    }


    private void Opt_etiquetar_orden_Click(object sender, EventArgs e)
    {
        EtiquetarOrdenCorte();
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
    #endregion

    #region OTHERS FUNCTIONS
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
        CALCULATE_TOTAL_WIDTH_CORTES();
        CALCULATE_MATERIAL_RESTANTE();
        CALCULATE_DATA_CORTES();
        CALCULAR_TOTAL_ROLLOS_CORTAR();
        grid_cortes.Focus();
        grid_cortes.CurrentCell = grid_cortes.Rows[^1].Cells[1];
    }
    private void Toggleloading(bool isLoading)
    {
        panel_loading.Visible = isLoading;
        panel_loading.BringToFront();
    }
    private bool Validar()
    {
        if (!ValidarDocumento()) return false;
        return true;

    }
    private bool ValidarDocumento()
    {
        bool validateDoc;

        //validar el rollid
        if (txt_rollid_1.Text == "0" && txt_width1.Text == "0" && txt_length1.Text == "0")
        {
            MessageBox.Show("debe seleccionar el roll-id del master a montar...");
            validateDoc = false;
            return validateDoc;
        }

        //validar los cortes
        if (!ValidDefintionsCortes())
            return false;

        //validar el operador
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
        if (txt_long_cortar.Text == "0")
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

        if (txt_ubic.Text == "")
        {
            MessageBox.Show("establezca un valor para la ubicación...");
            validateDoc = false;
            return validateDoc;
        }
        return true;
    }
    public DataRow[] BuscarItemsDetailsOrden()
    {
        DataRowView rowMaestro = (DataRowView)BsMaster.Current!;
        return rowMaestro.Row.GetChildRows(R.PARAMETERS.NAME_RELATION_OC_MASTER_DETAILS);
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

        grid_cortes.Focus();
        grid_cortes.CurrentCell = grid_cortes.Rows[^1].Cells[1];


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
    private void Btn_LabelCodeBar_Click(object sender, EventArgs e)
    {

        CREATE_DETALLE_ORDEN();

        string fecha_produccion = Convert.ToDateTime(txt_fecha_produccion.Text).ToShortDateString();

        PrintLabelsRolls PrintLabels = new()
        {
            Rollos = Detalle,
            Orden_Corte = txt_numeroOC.Text,
            Fechapro = fecha_produccion
        };
        PrintLabels.ShowDialog();
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
    private void Bot_imprimir_Click(object sender, EventArgs e)
    {
        ReportService.Reporte_Orden_Corte(txt_numeroOC.Text, this, R.REPORT_NAME.REPORT_OC, R.REPORT_TITLE.REPORT_OC);
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
    private void Bot_exportar_Click(object sender, EventArgs e)
    {
        List<RolloCortado> rollosCortados = CREATE_ROLLOS_CORTADOS();
        ExportDataService.ExportToExcel<RolloCortado>(rollosCortados, "RollosCortados.xlsx");
    }
    private void Btn_generar_txt_Click(object sender, EventArgs e)
    {

        ExportDataService.ExportTxtFormatRollosCortados(BuscarItemsDetailsOrden(), chk_generartxt_rc.Checked, Convert.ToDateTime(txt_fecha_produccion.Text).ToShortDateString(), Convert.ToDateTime(txt_fecha_produccion.Text).ToShortDateString(), true);
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
        txt_ubic.ReadOnly = true;
        chk_desperdicio1.Enabled = false;
        grid_cortes.ReadOnly = true;

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
    #endregion

    #region INVENTARIOS
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

            if (consumo_desper <= 0) return;

            var d = new { rollid = txt_rollid_1.Text, orden = txt_numeroOC.Text, consumo = consumo_desper, fecha = DateTime.Now, desperdicio = true };

            await Service.UpdateDetailsConsumosMasterIniciales(d.rollid, d.orden, d.consumo, d.fecha, d.desperdicio);
        }

        // 3.- actualiza el campo largo_consumido en orden_corte.
        double consumoParcial = txt_real1_length.Text == "" ? 0 : Convert.ToDouble(txt_real1_length.Text);
        string rollid = txt_rollid_1.Text;

        string tipo_m = txt_tipo_master.Text.ToString().ToUpper().Trim();

        string nameTable = tipo_m == "INIC." ? "MasterInic" : "ItemsMateria";

        string ssql = tipo_m == "INIC." ? R.QUERY.PRODUCTION.SQL_QUERY_ACTUALIZAR_INVENTARIO_INICIALES :
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

        //colocar en disponible los rollos cortados.
        Service.RollosCortadosDispobnibles(txt_numeroOC.Text);



    }
    #endregion
    private void Btn_vueltas_Click(object sender, EventArgs e)
    {

        frm_ConfigVueltas frmConfigVueltas = new(Service)
        {
            Numero_Vueltas = Convert.ToInt32(txt_vueltas1.Value),
            Longitud_a_Cortar = Convert.ToDouble(txt_long_cortar.Text),
            OC = txt_numeroOC.Text,
            StatusConfigVueltas = chk_ConfigVueltas.Checked,
            EditMode = this.EditMode
        };

        frmConfigVueltas.ShowDialog();

        //guardar en la base de datos la configuracion de vueltas.
        if (frmConfigVueltas.SaveChenged) 
        {
            //actualizar la ui del grid de vueltas.
            ActualizarUIConfigVueltas(frmConfigVueltas.Vueltas);

            double total_length = frmConfigVueltas.Total_Length_utilizado;

            //actualiza el valor del length ral utilizado despues de configurar las vueltas.
            txt_real1_length.Text = total_length.ToString("F2");

            //Actualizar el estatus de Configuracion de Vueltas.
            chk_ConfigVueltas.Checked = true;

            CALCULATE_TOTAL_WIDTH_CORTES();
            CALCULATE_MATERIAL_RESTANTE();

            //Verifica si el valor del length real utilizado es negativo se coloca en cero.
            double real_restante = Convert.ToDouble(txt_matrest1_lenght.Text);

            if (real_restante < 0)
            {
                txt_matrest1_lenght.Text = "0";
            }
        }
    }
    private void ActualizarUIConfigVueltas(List<ConfigVueltas> ConfigVueltas)
    {
        foreach (var item in ConfigVueltas)
        {
            int vuelta = item.Vuelta_numero;
            double lenght = item.Longitud_Cortar;

            foreach (DataRowView row in BsDetails)
            {
                if (Convert.ToInt32(row["vuelta"]) == vuelta)
                {
                    row["large"] = lenght;
                }

            }
        }
    }


    // Modifica la firma del método para que el parámetro sender sea nullable, coincidiendo con el delegado EventHandler.
    private void BsMaster_PositionChanged(object? sender, EventArgs args)
    {
        

        DataRowView FilaActual = (DataRowView)BsMaster.Current!;

        if (FilaActual == null) return;

        bool DocumentConfigVueltas = false;
        if (FilaActual["ConfigVueltas"] != DBNull.Value && FilaActual["ConfigVueltas"] != null)
            DocumentConfigVueltas = Convert.ToBoolean(FilaActual["ConfigVueltas"]);

        if (DocumentConfigVueltas)
        {
            btn_vueltas.Enabled = true;
        }
        else
        {
            btn_vueltas.Enabled = false;
        }
    }
}