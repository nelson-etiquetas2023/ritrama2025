using Ritrama2025.Forms.Otros;
using Ritrama2025.LabelSdk;
using Ritrama2025.Models;
using Ritrama2025.Services.CommonService;
using Ritrama2025.Services.ExportData;
using Ritrama2025.Services.InventarioService;
using Ritrama2025.Services.ProduccionService;
using Ritrama2025.Services.ReportsService.ReportsService;
using System.Data;
using System.Diagnostics;
using System.Drawing.Printing;

namespace Ritrama2025.Forms;

public partial class Frm_Inventarios : Form
{
    IInventarioService InventarioService { get; set; }
    IProduccionService ProduccionService { get; set; }
    IExportDataService ExportDataService { get; set; }
    IReportsService ReportService { get; set; }
    private DataTable? DtMaster { get; set; }
    private DataTable? DtRollosCortados { get; set; }
    private DataView Dv { get; set; } = new();
    private DataView DvRollos { get; set; } = new();
    List<int> IndexSelects { get; set; } = new();

    public Frm_Inventarios(IInventarioService inventarioService, IProduccionService produccionService, IExportDataService exportDataService, IReportsService reportService)
    {
        InventarioService = inventarioService;
        ProduccionService = produccionService;
        ExportDataService = exportDataService;
        ReportService = reportService;
        InitializeComponent();
        panel_loading.BackColor = System.Drawing.Color.FromArgb(160, System.Drawing.Color.LightGray);
        TabPages_Inventario.DrawMode = TabDrawMode.OwnerDrawFixed;
        TabPages_Inventario.DrawItem += TabControl1_DrawItem!;
        TabPages_Inventario.SizeMode = TabSizeMode.Fixed;
        TabPages_Inventario.ItemSize = new Size(140, 25);
    }

    private void Frm_Inventarios_Load(object sender, EventArgs e)
    {
        DefColumnsSheetExcel();
        BindingMasterGrid();
        DefColumnsGridRollosCortados();

        ComboPrinters.Items.Clear();
        foreach (string impresora in PrinterSettings.InstalledPrinters)
        {
            ComboPrinters.Items.Add(impresora);
        }



    }
    private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
    {
        TabPage page = TabPages_Inventario.TabPages[e.Index];
        Rectangle tabRect = e.Bounds;
        
        // Determinar si la pestaña está seleccionada
        bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

        // Fuente: negrita si está seleccionada, normal si no
        System.Drawing.Font? font = isSelected ? new System.Drawing.Font(e.Font!, FontStyle.Bold) : e.Font;

        // Fondo
        e.Graphics.FillRectangle(SystemBrushes.Control, tabRect);

        // Dibuja la imagen (si tiene)
        int iconOffset = 0;
        if (page.ImageIndex >= 0 && TabPages_Inventario.ImageList != null)
        {
            Image img = TabPages_Inventario.ImageList.Images[page.ImageIndex];
            int imgY = tabRect.Top + (tabRect.Height - img.Height) / 2;
            e.Graphics.DrawImage(img, tabRect.Left + 5, imgY);
            iconOffset = img.Width + 8;
        }

        // Dibuja el texto
        TextRenderer.DrawText(
            e.Graphics,
            page.Text,
            font,
            new Point(tabRect.Left + iconOffset + 5, tabRect.Top + 5),
            isSelected ? System.Drawing.Color.Black : System.Drawing.Color.Gray
        );
    }



    private void Toggleloading(bool isLoading)
    {
        panel_loading.Visible = isLoading;
        panel_loading.BringToFront();
        bot_buscar_cor.Enabled = !isLoading;
    }

    private List<Roll_Details> CreateListaRollosCortados()
    {
        List<Roll_Details> lista = [];
        for (int i = 0; i <= GridRollosCortados.Rows.Count - 1; i++)
        {
            Roll_Details rollo = new()
            {
                ItemNo = i + 1,
                Product_id = GridRollosCortados.Rows[i].Cells["product_id"].Value?.ToString() ?? string.Empty,
                Product_name = GridRollosCortados.Rows[i].Cells["product_name"].Value?.ToString() ?? string.Empty,
                Unique_code = GridRollosCortados.Rows[i].Cells["unique_code"].Value?.ToString() ?? string.Empty,
                Width = Convert.ToDecimal(GridRollosCortados.Rows[i].Cells["width"].Value),
                Large = Convert.ToDecimal(GridRollosCortados.Rows[i].Cells["lenght"].Value),
                Msi = Convert.ToDecimal(GridRollosCortados.Rows[i].Cells["msi"].Value),
                Roll_id = GridRollosCortados.Rows[i].Cells["roll_id"].Value?.ToString() ?? string.Empty,
                Numero_Orden = GridRollosCortados.Rows[i].Cells["numero"].Value?.ToString() ?? string.Empty,
                Splice = Convert.ToInt16(GridRollosCortados.Rows[i].Cells["splice"].Value),
                Status = GridRollosCortados.Rows[i].Cells["status"].Value?.ToString() ?? string.Empty,
                Ubic = GridRollosCortados.Rows[i].Cells["ubic"].Value?.ToString() ?? string.Empty,
                Code_Person = GridRollosCortados.Rows[i].Cells["code_person"].Value?.ToString() ?? string.Empty,
            };
            lista.Add(rollo);
        }
        return lista;
    }

    private List<ProductMAP> CreateListaMasterRolls()
    {
        List<ProductMAP> lista = [];
        for (int i = 0; i <= GridMaster.Rows.Count - 1; i++)
        {
            ProductMAP master = new()
            {
                ItemNo = i + 1,
                Product_Id = GridMaster.Rows[i].Cells["product_id"].Value?.ToString() ?? string.Empty,
                Product_Name = GridMaster.Rows[i].Cells["product_name"].Value?.ToString() ?? string.Empty,
                Rollid = GridMaster.Rows[i].Cells["roll_id"].Value?.ToString() ?? string.Empty,
                Width = Convert.ToDouble(GridMaster.Rows[i].Cells["width"].Value),
                Length = Convert.ToDouble(GridMaster.Rows[i].Cells["length"].Value),
                Length_Consumido = Convert.ToDouble(GridMaster.Rows[i].Cells["length_consumido"].Value),
                Length_Restante = Convert.ToDouble(GridMaster.Rows[i].Cells["length_restante"].Value),
                Estado = GridMaster.Rows[i].Cells["estado"].Value?.ToString() ?? string.Empty,
                //Msi = Convert.ToDouble(GridMaster.Rows[i].Cells["msi"].Value),
                Ubic = GridMaster.Rows[i].Cells["ubic"].Value?.ToString() ?? string.Empty,
                Cant = 1, // Assuming each row represents one roll
                Recepcion = GridMaster.Rows[i].Cells["fecha"].Value?.ToString() ?? string.Empty,
                Fecha_Fabricacion = Convert.ToDateTime(GridMaster.Rows[i].Cells["fecha_pro"].Value),
                Fecha_Llegada = DateTime.Now, // Assuming current date for arrival
            };
            lista.Add(master);
        }
        return lista;
    }
    private void DefColumnsGridRollosCortados()
    {
        GridRollosCortados.AutoGenerateColumns = false;
        CommonService.ADD_COLUMN_GRID("product_id", 60, "Prod. Id", "product_id", GridRollosCortados);
        CommonService.ADD_COLUMN_GRID("product_name", 250, "Product Name", "product_name", GridRollosCortados);
        CommonService.ADD_COLUMN_GRID("unique_code", 60, "Unique Code", "unique_code", GridRollosCortados);
        CommonService.ADD_COLUMN_GRID("width", 60, "Width [Inch.]", "width", GridRollosCortados);
        CommonService.ADD_COLUMN_GRID("lenght", 60, "Lenght [Pies]", "large", GridRollosCortados);
        CommonService.ADD_COLUMN_GRID("msi", 60, "Msi", "msi", GridRollosCortados);
        CommonService.ADD_COLUMN_GRID("splice", 60, "Splice", "splice", GridRollosCortados);
        CommonService.ADD_COLUMN_GRID("roll_id", 80, "Roll-Id", "roll_id", GridRollosCortados);
        CommonService.ADD_COLUMN_GRID("code_person", 60, "Code Person.", "code_person", GridRollosCortados);
        CommonService.ADD_COLUMN_GRID("numero", 60, "Orden Corte", "numero", GridRollosCortados);
        CommonService.ADD_COLUMN_GRID("status", 60, "Status", "status", GridRollosCortados);
        CommonService.ADD_COLUMN_GRID("ubic", 80, "Ubicacion", "ubic", GridRollosCortados);
        CommonService.ADD_COLUMN_GRID("fecha", 80, "Creacion", "fecha", GridRollosCortados);
        CommonService.ADD_COLUMN_GRID("despacho", 80, "Doc. Despacho", "despacho", GridRollosCortados);
        CommonService.ADD_COLUMN_GRID("fecha_despacho", 80, "Fecha Despacho", "fecha_desPACHO", GridRollosCortados);
        CommonService.ADD_COLUMN_GRID("disponible", 80, "Disponible", "disponible", GridRollosCortados);
        //agregar la columna de images para el disponible del producto.
        DataGridViewImageColumn colEstado = new()
        {
            Name = "colEstado",
            HeaderText = "...",
            ImageLayout = DataGridViewImageCellLayout.Zoom,
            DisplayIndex = 0,
            Width = 16
        };
        GridRollosCortados.Columns.Add(colEstado);
    }
    private void BindingMasterGrid()
    {
        GridMaster.AutoGenerateColumns = false;
        CommonService.ADD_COLUMN_GRID("product_id", 80, "Prod. Id", "part_number", GridMaster);
        CommonService.ADD_COLUMN_GRID("product_name", 250, "Product Name", "product_name", GridMaster);
        CommonService.ADD_COLUMN_GRID("roll_id", 100, "Rollid", "roll_id", GridMaster);
        CommonService.ADD_COLUMN_GRID("width", 80, "Width", "width", GridMaster);
        CommonService.ADD_COLUMN_GRID("length", 80, "Length", "lenght", GridMaster);
        CommonService.ADD_COLUMN_GRID("length_consumido", 80, "Consumido", "largo_consumido", GridMaster);
        CommonService.ADD_COLUMN_GRID("length_restante", 80, "Restante", "largo_restante", GridMaster);
        CommonService.ADD_COLUMN_GRID("estado", 80, "Estado", "estado", GridMaster);
        CommonService.ADD_COLUMN_GRID("msi", 80, "Msi", "msi", GridMaster);
        CommonService.ADD_COLUMN_GRID("core", 80, "Core", "core", GridMaster);
        CommonService.ADD_COLUMN_GRID("fecha_pro", 100, "Produccion", "fecha_pro", GridMaster);
        CommonService.ADD_COLUMN_GRID("fecha_reg", 100, "Llegada", "fecha_reg", GridMaster);
        CommonService.ADD_COLUMN_GRID("splice", 80, "Splice", "splice", GridMaster);
        CommonService.ADD_COLUMN_GRID("ubic", 80, "Ubic. ", "ubicacion", GridMaster);
        CommonService.ADD_COLUMN_GRID("tipo_mov", 80, "Tipo", "tipo_mov", GridMaster);
        //Columna Check para seleccionar las filas a imprimnir.

        DataGridViewCheckBoxColumn colSelPrint = new()
        {
            HeaderText = "Sel.",
            ReadOnly = false,
            DisplayIndex = 0,
            Width = 30,
            Name = "colSelPrint"
        };
        GridMaster.Columns.Add(colSelPrint);


    }
    private async void Btn_reload_Click(object sender, EventArgs e)
    {
        string activeTabtext = TabPages_Inventario.SelectedTab!.Text;
        if (activeTabtext == "Master")
        {
            Toggleloading(true);
            try
            {
                DtMaster = await Task.Run(() => InventarioService.LoadMasterInventario());
                Dv = DtMaster!.DefaultView;
                GridMaster.DataSource = Dv;
                ContarRegistros();
                GridMaster.ReadOnly = false;
                // Bloquear todas las columnas por defecto
                foreach (DataGridViewColumn col in GridMaster.Columns)
                {
                    if (col.Name != "colSelPrint") col.ReadOnly = true;

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Toggleloading(false);
            }
        }
        if (activeTabtext == "Rollos Cortados")
        {
            Toggleloading(true);
            Application.DoEvents();
            await Task.Delay(500);

            try
            {

                DtRollosCortados = await Task.Run(() => InventarioService.LoadRolloCortadoInventaerio());
                DvRollos = DtRollosCortados!.DefaultView;
                GridRollosCortados.DataSource = DvRollos;
                ContarRegistrosRollos();


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Toggleloading(false);
            }
        }
        if (activeTabtext == "Hojas")
        {
            Toggleloading(true);
            Application.DoEvents();
            await Task.Delay(500);
            Toggleloading(false);
        }
    }
    private void ContarRegistros()
    {
        COUNT_ROWS.Text = Dv.Count.ToString() + " Registros Encontrados." ?? "0 Registros Encontrados";
    }
    private void ContarRegistrosRollos()
    {
        COUNTER_ROLLOS.Text = DvRollos.Count.ToString() + " Registros Encontrados." ?? "0 Registros Encontrados";
    }
    private void DefColumnsSheetExcel()
    {
        //llenar la lista de las columnas.
        var columnas = new List<ColumnaType>()
        {
            new() { Description = "Product Id   ", Index = 1, TipoValor = "string  " },
            new() { Description = "Product Name ", Index = 2, TipoValor = "string  " },
            new() { Description = "Width        ", Index = 3, TipoValor = "decimal " },
            new() { Description = "Length       ", Index = 4, TipoValor = "decimal " },
            new() { Description = "Msi          ", Index = 5, TipoValor = "decimal " }
        };
        ListColumns.DataSource = columnas;
        ListColumns.DisplayMember = "InfoParaDisplay";
        ListColumns.ValueMember = "Index";
    }
    private void Btn_load_sheet_Click(object sender, EventArgs e)
    {
        //validacion del tipo de producto
        if (!rad_master.Checked && !rad_graphics.Checked)
        {
            MessageBox.Show("Debe escoger el tipo de producto primero...");
            return;
        }
        //open dialog para seleccionar el archivo de excel
        OpenFileDialog dialog = new()
        {
            Filter = "Excel Files|*.xls;*.xlsx;*.xlsm",
            Title = "Select an Excel File"
        };
        dialog.ShowDialog();

        string filePath = dialog.FileName;
        string fileName = Path.GetFileName(filePath);

        txt_file_name.Text = fileName;
        txt_file_path.Text = filePath;
    }
    private void Btn_import_excel_Click(object sender, EventArgs e)
    {
        Frm_Imports importData = new(this.InventarioService)
        {
            FileName = txt_file_name.Text,
            PathFileName = txt_file_path.Text
        };
        importData.ShowDialog();
    }

    private void Btn_buscar_Click(object sender, EventArgs e)
    {
        if (rad_rollid.Checked)
        {
            Dv.RowFilter = "roll_id like '%" + txt_buscar.Text + "%'";
        }
        if (rad_productid.Checked)
        {
            Dv.RowFilter = "part_number like '%" + txt_buscar.Text + "%'";
        }
        if (rad_product_name.Checked)
        {
            Dv.RowFilter = "product_name like '%" + txt_buscar.Text + "%'";
        }
        if (rad_ubication.Checked)
        {
            Dv.RowFilter = "ubicacion like '%" + txt_buscar.Text + "%'";
        }
        ContarRegistros();
    }
    private void Btn_limpiar_filtros_Click(object sender, EventArgs e)
    {
        txt_buscar.Text = string.Empty;
        Dv.RowFilter = string.Empty;
        ContarRegistros();
    }

    private void Btn_DetailsConsumos_Click(object sender, EventArgs e)
    {
        Frm_DetailsConsumos frmDetails = new(ProduccionService)
        {
            Rollid = GridMaster.CurrentRow?.Cells["roll_id"].Value?.ToString() ?? string.Empty,
            Productid = GridMaster.CurrentRow?.Cells["product_id"].Value?.ToString() ?? string.Empty,
            Product_Name = GridMaster.CurrentRow?.Cells["product_name"].Value?.ToString() ?? string.Empty,
            Width_t = GridMaster.CurrentRow?.Cells["width"].Value!.ToString() ?? string.Empty,
            Length = GridMaster.CurrentRow?.Cells["length"].Value!.ToString() ?? string.Empty,
        };
        frmDetails.ShowDialog();
    }

    private async void Bot_Excel_Click(object sender, EventArgs e)
    {

        string activeTabtext = TabPages_Inventario.SelectedTab!.Text;

        if (activeTabtext == "Master")
        {
            if (GridMaster.Rows.Count == 0)
            {
                MessageBox.Show("Cargue los datos primero...");
                return;
            }
            Toggleloading(true);
            List<ProductMAP> listaMasterRolls = CreateListaMasterRolls();
            await Task.Run(() =>
            {
                ExportDataService.ExportToExcel<ProductMAP>(listaMasterRolls, "InventarioMaster.xlsx");
            });
            Toggleloading(false);
        }

        if (activeTabtext == "Rollos Cortados")
        {
            if (GridRollosCortados.Rows.Count == 0)
            {
                MessageBox.Show("Cargue los datos primero...");
                return;
            }
            Toggleloading(true);
            List<Roll_Details> listaRollosCortados = CreateListaRollosCortados();
            await Task.Run(() =>
            {
                ExportDataService.ExportToExcel<Roll_Details>(listaRollosCortados, "Inventario_RollosCortados.xlsx");
            });
            Toggleloading(false);
        }
    }

    private void Bot_Txt_Click(object sender, EventArgs e)
    {

        string activeTabtext = TabPages_Inventario.SelectedTab!.Text;

        if (activeTabtext == "Master")
        {
            if (GridMaster.Rows.Count == 0)
            {
                MessageBox.Show("Cargue los datos primero...");
                return;
            }
            Toggleloading(true);
            DataRow[] listaMasters = [.. Dv.ToTable().AsEnumerable().Where(r => r.RowState != DataRowState.Deleted)];

            ExportFileTextFormat(listaMasters);
            Toggleloading(false);
        }

        if (activeTabtext == "Rollos Cortados")
        {
            if (GridRollosCortados.Rows.Count == 0)
            {
                MessageBox.Show("Cargue los datos primero...");
                return;
            }
            Toggleloading(true);
            DataRow[] ListaRollos = [.. DvRollos.ToTable().AsEnumerable().Where(r => r.RowState != DataRowState.Deleted)];

            ExportFileTextFormat_Rollo_Cortado(ListaRollos);
            Toggleloading(false);
        }



    }

    private static bool ExportFileTextFormat_Rollo_Cortado(DataRow[] listaCortados)
    {
        try
        {
            var folderPath = Path.Combine(Application.StartupPath, "Archivos");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var filePath = Path.Combine(folderPath, "IRolloCortado.txt");
            using (StreamWriter sr = new(filePath))
            {
                foreach (DataRow item in listaCortados)
                {
                    string product_id = item["product_id"].ToString()!.Trim();
                    string product_name = item["product_name"].ToString()!.Trim();
                    string unique_code = item["unique_code"].ToString()!.Trim();
                    string width = item["width"].ToString()!.Trim();
                    string length = item["large"].ToString()!.Trim();
                    string splice = item["splice"].ToString()!.Trim();
                    string rollid = item["roll_id"].ToString()!.Trim();
                    string code_per = item["code_person"].ToString()!.Trim();
                    string orden = item["numero"].ToString()!.Trim();
                    string status = item["status"].ToString()!.Trim();
                    string ubic = item["ubic"].ToString()!.Trim();
                    string fecha_crea = item["fecha"].ToString()!.Trim();
                    string despacho = item["despacho"].ToString()!.Trim();
                    string fecha_des = item["fecha_despacho"].ToString()!.Trim();

                    string linea = $"{product_id},{product_name},{unique_code},{width},{length},{splice},{rollid},{code_per},{orden},{status},{ubic},{fecha_crea},{despacho},{fecha_des}";

                    sr.WriteLine(linea);
                }
            }
            //abri el archivo con el programa predeterminado.
            var psi = new ProcessStartInfo
            {
                FileName = filePath,
                UseShellExecute = true
            };
            Process.Start(psi);
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al crear el inventario de rollo cortados...: " + ex.Message);
            return false;
        }
    }

    private static bool ExportFileTextFormat(DataRow[] listaMasters)
    {
        try
        {
            var folderPath = Path.Combine(Application.StartupPath, "Archivos");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var filePath = Path.Combine(folderPath, "Imaster.txt");
            using (StreamWriter sr = new(filePath))
            {
                foreach (DataRow item in listaMasters)
                {
                    string product_id = item["part_number"].ToString()!.Trim();
                    string product_name = item["product_name"].ToString()!.Trim();
                    string rollid = item["roll_id"].ToString()!.Trim();
                    string width = item["width"].ToString()!.Trim();
                    string lenght = item["lenght"].ToString()!.Trim();
                    string length_Consumido = item["largo_consumido"].ToString()!.Trim();
                    string length_Restante = item["largo_restante"].ToString()!.Trim();
                    string estado = item["estado"].ToString()!.Trim();
                    string fec_produc = item["fecha_pro"].ToString()!.Trim();
                    string fec_ingreso = item["fecha_recep"].ToString()!.Trim();
                    string splice = item["splice"].ToString()!.Trim();
                    string ubic = item["ubicacion"].ToString()!.Trim();
                    string tipo_mov = item["tipo_mov"].ToString()!.Trim();

                    string linea = $"{product_id},{product_name},{rollid},{width},{lenght},{length_Consumido}," +
                        $"{length_Restante},{estado},{fec_produc},{fec_ingreso},{splice},{ubic},{tipo_mov}";

                    sr.WriteLine(linea);
                }
            }
            //abri el archivo con el programa predeterminado.
            var psi = new ProcessStartInfo
            {
                FileName = filePath,
                UseShellExecute = true
            };
            Process.Start(psi);
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al crear el inventario de masters...: " + ex.Message);
            return false;
        }
    }

    private void GridMaster_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (this.GridMaster.Columns[e.ColumnIndex].Name == "estado")
        {
            try
            {
                string estado = Convert.ToString(e.Value)!;
                if (estado == "Agotado")
                {
                    e.CellStyle.BackColor = System.Drawing.Color.Red;
                    e.CellStyle.ForeColor = System.Drawing.Color.White;
                }
                if (estado == "Completo")
                {
                    e.CellStyle.BackColor = System.Drawing.Color.Green;
                    e.CellStyle.ForeColor = System.Drawing.Color.White;
                }
                if (estado == "Parcialmente Consumido")
                {
                    e.CellStyle.BackColor = System.Drawing.Color.Orange;
                    e.CellStyle.ForeColor = System.Drawing.Color.White;
                }
            }
            catch (Exception)
            {
                e.CellStyle.BackColor = System.Drawing.Color.White;
                throw;
            }
        }
    }

    private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void TabPage1_Click(object sender, EventArgs e)
    {

    }


    private void Rollos_Click(object sender, EventArgs e)
    {

    }

    private void Txt_buscar_TextChanged(object sender, EventArgs e)
    {

    }

    private void Bot_buscar_cor_Click(object sender, EventArgs e)
    {
        if (rad_rollid_cor.Checked)
        {
            DvRollos.RowFilter = "roll_id like '%" + txt_buscar_cor.Text + "%'";
        }
        if (rad_productid_cor.Checked)
        {
            DvRollos.RowFilter = "product_id like '%" + txt_buscar_cor.Text + "%'";
        }
        if (rad_productname_cor.Checked)
        {
            DvRollos.RowFilter = "product_name like '%" + txt_buscar_cor.Text + "%'";
        }
        if (rad_ubic_cor.Checked)
        {
            DvRollos.RowFilter = "ubic like '%" + txt_buscar_cor.Text + "%'";
        }
        if (rad_codeunique_cor.Checked)
        {
            DvRollos.RowFilter = "unique_code like '%" + txt_buscar_cor.Text + "%'";
        }
        if (rad_codeperson_cor.Checked)
        {
            DvRollos.RowFilter = "code_person like '%" + txt_buscar_cor.Text + "%'";
        }
        if (rad_ordencorte_cor.Checked)
        {
            DvRollos.RowFilter = "CONVERT(numero, 'System.String') LIKE '%" + txt_buscar_cor.Text + "%'";
        }

        ContarRegistrosRollos();

    }

    private void Bto_limpiar_cor_Click(object sender, EventArgs e)
    {
        txt_buscar_cor.Text = string.Empty;
        GridRollosCortados.DataSource = "";
        ContarRegistrosRollos();
    }

    private void PictureBox3_Click(object sender, EventArgs e)
    {

    }

    private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }

    private void Bot_Reports_Click(object sender, EventArgs e)
    {
        string activeTabtext = TabPages_Inventario.SelectedTab!.Text;

        if (activeTabtext == "Master")
        {
            if (GridMaster.Rows.Count == 0)
            {
                MessageBox.Show("Cargue los datos primero...");
                return;
            }

            try
            {
                ReportService.Reporte_InventarioMaster(this, "Inventario de Master", "Report_Inventario_Master.rdlc");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        if (activeTabtext == "Rollos Cortados")
        {
            if (GridRollosCortados.Rows.Count == 0)
            {
                MessageBox.Show("Cargue los datos primero...");
                return;
            }
            ReportService.Reporte_InventarioRollosCortados(this, "Inventario de Rollos Cortados", "Report_Inventarios_RollosCortados.rdlc");
        }

    }

    private void GridRollosCortados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        //obtener el valor de la columna disponible.

        if (GridRollosCortados.Columns[e.ColumnIndex].Name == "colEstado")
        {
            //obtener el valor de la columna disponible.
            bool dispo = Convert.ToBoolean(GridRollosCortados.Rows[e.RowIndex].Cells["disponible"].Value);

            if (dispo)
            {
                var row = GridRollosCortados.Rows[e.RowIndex];
                //row.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                //row.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                e.Value = Properties.Resources.products_dispo;

            }
            else
            {
                var row = GridRollosCortados.Rows[e.RowIndex];
                //row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                //row.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                e.Value = Properties.Resources.products_nodispo;
            }
        }
    }


    private void Bot_printLabel_Click(object sender, EventArgs e)
    {
        if (ComboPrinters.SelectedItem == null)
        {
            MessageBox.Show("seleccione una impresora primero...");
            return;
        }


        foreach (DataGridViewRow fila in GridMaster.Rows)
        {
            bool RowSelect = Convert.ToBoolean(fila.Cells["colSelPrint"].Value);
            int FilaIndex = fila.Index;

            if (RowSelect)
            {
                string template = @"^XA^POR
                ^FO700,100^A0R,60,60^FDFEDRIGONNI^FS
                ^FO680,150^A0R,30,30^FDMateria Prima Master^FS

                ^FO750,650^A0R,30,20^FDPRODUCT ID^FS
                ^FO750,1000^A0R,30,20^FDROLL ID^FS

                ^FO700,650^A0R,50,50^FD{product_id}^FS
                ^FO700,1000^A0R,40,40^FD{rollid}^FS

                ^FO680,50^GB1,1200,3,1^FS
                ^FO680,500^GB200,3,1^FS
                ^FO680,950^GB200,3,1^FS

                ^FO635,50^A0R,30,20^FDPRODUCTO^FS
                ^FO635,1000^A0R,30,20^FDFECHA^FS

                ^FO580,50^A0R,50,60^FD{product_name}^FS
                ^FO580,1000^A0R,40,40^FD{fecha}^FS
  
                ^FO550,50^GB1,1200,3,1^FS
                ^FO550,950^GB130,3,1^FS
            
                ^FO510,50^A0R,30,20^FDWIDTH (Inch):^FS
                ^FO510,350^A0R,30,20^FDLENGTH-RESTANTE (Pies):^FS
                ^FO510,650^A0R,30,20^FDMSI:^FS
                ^FO510,1000^A0R,30,20^FDSPLICE:^FS

                ^FO440,50^A0R,60,60^FD{width}^FS
                ^FO440,320^A0R,60,60^FD{lenght}^FS
                ^FO440,650^A0R,60,60^FD{msi}^FS
                ^FO440,1000^A0R,60,60^FD{splice}^FS

                ^FO420,50^GB1,1200,3,1^FS
                ^FO420,300^GB130,3,1^FS
                ^FO420,600^GB130,3,1^FS
                ^FO420,950^GB130,3,1^FS

                ^FO380,50^A0R,30,20^FDLENGTH-ORIGINAL:^FS
                ^FO380,280^A0R,30,20^FD^FS
                ^FO380,650^A0R,30,20^FD^FS
                ^FO380,1000^A0R,30,20^FD^FS

                ^FO300,50^A0R,60,60^FD{lenght_original}^FS
                ^FO300,280^A0R,60,60^FD{customer_id}^FS
                ^FO300,650^A0R,60,60^FD{orden}^FS
                ^FO300,1000^A0R,60,60^FD{roll_number}^FS

                ^FO280,50^GB1,1200,3,1^FS            
                ^FO280,600^GB140,3,1^FS
                ^FO280,950^GB140,3,1^FS
            
                ^FO200,50^A0R,30,20^FDPRODUCT ID:^FS
                ^FO200,570^A0R,30,20^FDROLL-ID:^FS
            
                ^BY4,4,100

                ^FO80,200^BCR,150,Y,N,N
                ^FD{product_id}^FS
                ^FO80,690^BCR,150,Y,N,N
                ^FD{rollid}^FS
                ^FO50,540^GB235,3,1^FS^XZ";

                string product_id = fila.Cells["product_id"].Value?.ToString()!;
                string productName = fila.Cells["product_name"].Value?.ToString()!.Substring(0, 28)!;
                string rollid = fila.Cells["roll_id"].Value?.ToString()!;
                string width = fila.Cells["width"].Value?.ToString()!;
                string length = fila.Cells["length_restante"].Value?.ToString()!;
                string length_original = fila.Cells["length"].Value?.ToString()!;

                string msi = fila.Cells["msi"].Value?.ToString()!;
                string splice = fila.Cells["splice"].Value?.ToString()!;
                string status = "";
                string code_person = "";
                string roll_number = "";
                string unique_code = "";

                DateTime Fechapro = DateTime.Now;

                var values = new Dictionary<string, string>
                {
                    { "product_id", product_id },
                    { "product_name", productName },
                    { "rollid", rollid },
                    { "fecha", Fechapro.ToShortDateString() },
                    { "width", width },
                    { "lenght", length  },
                    { "lenght_original", length_original },
                    { "msi", msi },
                    { "splice", splice  },
                    { "status", status  },
                    { "customer_id", code_person },
                    { "orden", ""},
                    { "roll_number", roll_number },
                    { "unique_code", unique_code },
                    { "Codigo", product_id }
                };

                string? printerSelection = ComboPrinters.SelectedItem?.ToString();

                bool ok = ZebraTemplateEngine.Print(printerSelection!, template, values, StandardLabelSizes.Size_4x6_203dpi);

            }



        }





    }

    private void GridRollosCortados_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void GridMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void btn_delete_master_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewRow fila in GridMaster.Rows)
        {
            bool RowSelect = Convert.ToBoolean(fila.Cells["colSelPrint"].Value);
            bool estadoCompleto = fila.Cells["estado"].Value?.ToString()!.ToUpper() == "COMPLETO" ? true : false;

            if (RowSelect)
            {
                if (estadoCompleto)
                {
                    string rollid = fila.Cells["roll_id"].Value?.ToString()!;
                    InventarioService.BorrarMasterDB(rollid);
                }
                else
                {
                    MessageBox.Show("Solo se pueden eliminar los master que esten en estado COMPLETO...");
                }

            }
        }

        MessageBox.Show("Proceso terminado...");
    }

    private void label13_Click(object sender, EventArgs e)
    {

    }
}
public class ColumnaType
{
    public string Description { get; set; } = null!;
    public int Index { get; set; }
    public string TipoValor { get; set; } = null!;

    public string InfoParaDisplay
    {
        get
        {
            // PadRight alinea el texto agregando espacios a la derecha.
            // Ajusta el número (25) según el ancho que necesites para la primera columna.
            return $"{Description}{TipoValor}{Index}";
        }
    }
    public void LoadPrinters()
    {
        

        
    }

}


