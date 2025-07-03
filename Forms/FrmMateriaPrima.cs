using ClosedXML.Excel;
using Ritrama2025.Forms.Seleccion;
using Ritrama2025.Models;
using Ritrama2025.Services.MateriaPrima;
using System.Data;
using System.Diagnostics;
using Ritrama2025.Forms.Otros;



namespace Ritrama2025.Forms
{
    public partial class FrmMateriaPrima : Form
    {
        public readonly IServiceMateriaPrima Services;
        public DataSet Ds = new();
        readonly BindingSource Bs = [];
        readonly BindingSource BsDetalle = [];
        private DataRowView ParentRow = null!;
        private DataRowView ChildsRows = null!;
        string EditMode = "READ";

        public FrmMateriaPrima(IServiceMateriaPrima Services)
        {
            InitializeComponent();
            this.Services = Services;
        }

        private void FrmMateriaPrima_Load(object sender, EventArgs e)
        {
            LoadDataAsync();
            BindDataSource();
            BindingControls();
            RefreshDocument();
        }
        private void RefreshDocument()
        {
            label_counter_rows.Text = $"Registros: {Bs.Count}";
            Bs.Sort = "numero DESC";
            string basePath = AppContext.BaseDirectory;
            string ruta = Path.Combine(basePath, "Images");

            string estado = !chk_DocumentClose.Checked ? "abierto" : "cerrado";
            if (chk_anulado.Checked) estado = "anulado";







            switch (estado)
            {
                case "abierto":
                    Pic_Document.Image = Image.FromFile(ruta + @"\open_document.png");
                    break;
                case "cerrado":
                    Pic_Document.Image = Image.FromFile(ruta + @"\close_document.png");
                    break;
                case "anulado":
                    Pic_Document.Image = Image.FromFile(ruta + @"\anulado_documento.png");
                    break;
            }
        }
        private void BindDataSource()
        {
            //Configuracion del BindingSource.
            Bs.DataSource = Ds;
            Bs.DataMember = "DtMateria";
            //Bs.Sort = "numero DESC";
            //Bindingsource para el detalle de los productos.
            BsDetalle.DataSource = Bs;
            BsDetalle.DataMember = "FK_MASTER_DETAILS";
            GridItems.AutoGenerateColumns = false;
            ADD_COLUMN_GRID("product_id", 70, "Product Id.", "product_id", GridItems);
            ADD_COLUMN_GRID("product_name", 200, "Product Name.", "product_name", GridItems);
            ADD_COLUMN_GRID("product_type", 70, "Tipo", "type", GridItems);
            ADD_COLUMN_GRID("width", 75, "Width [Inch.]", "width", GridItems);
            ADD_COLUMN_GRID("length", 75, "Length [Pies]", "length", GridItems);
            ADD_COLUMN_GRID("msi", 60, "Msi", "msi", GridItems);
            ADD_COLUMN_GRID("rollid", 70, "Roll-Id.", "rollid", GridItems);
            ADD_COLUMN_GRID("splice", 65, "Splice", "splice", GridItems);
            ADD_COLUMN_GRID("core", 65, "Core", "core", GridItems);
            ADD_COLUMN_GRID("ubicacion", 70, "Ubica.", "ubicacion", GridItems);
            ADD_COLUMN_GRID("cant_pedido", 65, "Cantidad Pedido", "cant_pedido", GridItems);
            ADD_COLUMN_GRID("cant_real", 65, "Cantidad Real", "cant_real", GridItems);
            GridItems.DataSource = BsDetalle;

        }
        private void LoadDataAsync()
        {

            //carga los datos de la base dfe datos.
            var task = Task.Run(async () =>
            {
                return await Services.LoadData();
            });
            Ds = task.Result;
        }

        private void BindingControls()
        {
            //trabajar con los enlaces a datos.
            txt_numeroOrden.DataBindings.Add("Text", Bs, "numero");
            txt_OrdenCompra.DataBindings.Add("Text", Bs, "orden_compra");
            txt_prov_Id.DataBindings.Add("Text", Bs, "proveedor_id");
            txt_nombre_prov.DataBindings.Add("Text", Bs, "proveedor_name");
            txt_fecha_produccion.DataBindings.Add("Text", Bs, "fecha_pro");
            txt_fecha_recepcion.DataBindings.Add("Text", Bs, "fecha_recepcion");
            txt_person_name.DataBindings.Add("Text", Bs, "persona_respons");
            txt_transport_id.DataBindings.Add("Text", Bs, "transport_id");
            txt_transport_name.DataBindings.Add("Text", Bs, "transport_name");
            txt_guia.DataBindings.Add("Text", Bs, "guia_import");
            txt_lote.DataBindings.Add("Text", Bs, "lote");
            txt_embarque.DataBindings.Add("Text", Bs, "doc_embarque");
            txt_total_cantidad.DataBindings.Add("Text", Bs, "total_cantidad");
            txt_notas.DataBindings.Add("Text", Bs, "notas");

            txt_person_id.DataBindings.Add("Text", Bs, "person_id");
            chk_DocumentClose.DataBindings.Add("Checked", Bs, "CloseDocument");
            chk_anulado.DataBindings.Add("Checked", Bs, "anulado");

        }
        private void StyleGridColumns()
        {
            GridItems.AutoGenerateColumns = false;
            //Configurar las columnas del detalle de los productos.
            ADD_COLUMN_GRID("product_id", 70, "Product Id.", "product_id", GridItems);
            ADD_COLUMN_GRID("product_name", 200, "Product Name.", "product_name", GridItems);
            GridItems.DataSource = BsDetalle;
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

        private void Btn_siguiente_Click(object sender, EventArgs e)
        {
            Bs.Position--;
            RefreshDocument();
        }

        private void Btn_anterior_Click(object sender, EventArgs e)
        {
            Bs.Position++;
            RefreshDocument();
        }

        private void Btn_ultimo_Click(object sender, EventArgs e)
        {
            Bs.Position = 0;
            RefreshDocument();
        }

        private void Btn_primero_Click(object sender, EventArgs e)
        {
            Bs.Position = Bs.Count - 1;
            RefreshDocument();
        }

        private void Btn_create_Click(object sender, EventArgs e)
        {
            EditMode = "ADDNEW";
            Bs.Sort = "";
            chk_anulado.DataBindings.Clear();
            chk_DocumentClose.DataBindings.Clear();
            chk_DocumentClose.Checked = false;
            ParentRow = (DataRowView)Bs.AddNew();
            ParentRow.BeginEdit();
            ParentRow["numero"] = Services.LoadConsecOrden("CMP");
            ParentRow["total_cantidad"] = 0;
            ParentRow["CloseDocument"] = false;
            ParentRow.EndEdit();
            AbrirFormulario();
            string basePath = AppContext.BaseDirectory;
            string ruta = Path.Combine(basePath, "Images");
            Pic_Document.Image = Image.FromFile(ruta + @"\add_document.png");


        }
        private void AbrirFormulario()
        {
            txt_OrdenCompra.ReadOnly = false;
            btn_ProvBuscar.Enabled = true;
            btn_TransportBuscar.Enabled = true;
            btn_RecepBuscar.Enabled = true;
            txt_fecha_produccion.Enabled = true;
            txt_fecha_recepcion.Enabled = true;
            txt_guia.ReadOnly = false;
            txt_lote.ReadOnly = false;
            txt_embarque.ReadOnly = false;
            txt_notas.ReadOnly = false;
            btn_addRows.Enabled = true;
            btn_deleteRows.Enabled = true;
            btn_save.Enabled = true;
            btn_cancel.Enabled = true;
            btn_siguiente.Enabled = false;
            btn_anterior.Enabled = false;
            btn_primero.Enabled = false;
            btn_ultimo.Enabled = false;
            btn_create.Enabled = false;
            txt_notas.BackColor = Color.White;
            txt_notas.ReadOnly = false;
            btn_LoadRows.Enabled = true;
            btn_template.Enabled = true;
            btn_CloseDoc.Enabled = false;
            btn_AnularDoc.Enabled = false;
            btn_OrdenBuscar.Enabled = false;
            btn_printDoc.Enabled = false;
            btn_ExportDoc.Enabled = false;
            btn_SearchDoc.Enabled = false;
        }

        private void Btn_ProvBuscar_Click(object sender, EventArgs e)
        {
            FrmSeleccion SelVendor = new()
            {
                DtItems = Ds.Tables["DtProvider"]!,
                Titulo = "Proveedor"
            };
            SelVendor.ShowDialog();
            txt_prov_Id.Text = SelVendor.Id;
            txt_nombre_prov.Text = SelVendor.Description;
        }

        private void Btn_TransportBuscar_Click(object sender, EventArgs e)
        {

            FrmSeleccion SelTransport = new()
            {
                DtItems = Ds.Tables["DtTransport"]!,
                Titulo = "Transporte"
            };
            SelTransport.ShowDialog();
            txt_transport_id.Text = SelTransport.Id;
            txt_transport_name.Text = SelTransport.Description;
        }

        private void Btn_RecepBuscar_Click(object sender, EventArgs e)
        {
            FrmSeleccion SelPerson = new()
            {
                DtItems = Ds.Tables["DtPerson"]!,
                Titulo = "Persona"
            };
            SelPerson.ShowDialog();
            txt_person_id.Text = SelPerson.Id;
            txt_person_name.Text = SelPerson.Description;
        }

        private void Btn_addRows_Click(object sender, EventArgs e)
        {
            FrmProductsInsert frmInsertRows = new()
            {
                DtItems = Ds.Tables["DtProducts"]!,
                Titulo = "Producto"
            };
            frmInsertRows.ShowDialog();
            //Insertar el row en el GridItems.
            if (frmInsertRows.Producto != null)
            {
                ChildsRows = (DataRowView)BsDetalle.AddNew();
                ChildsRows.BeginEdit();
                ChildsRows["numero"] = txt_numeroOrden.Text;
                ChildsRows["product_id"] = frmInsertRows.Producto.Product_Id;
                ChildsRows["product_name"] = frmInsertRows.Producto.Product_Name;
                ChildsRows["type"] = frmInsertRows.Producto.Product_Type;
                ChildsRows["width"] = frmInsertRows.Producto.Width;
                ChildsRows["length"] = frmInsertRows.Producto.Length;
                ChildsRows["msi"] = frmInsertRows.Producto.Msi;
                ChildsRows["rollid"] = frmInsertRows.Producto.Rollid;
                ChildsRows["splice"] = frmInsertRows.Producto.Splice;
                ChildsRows["core"] = frmInsertRows.Producto.Core;
                ChildsRows["ubicacion"] = frmInsertRows.Producto.Ubic;
                ChildsRows["cant_pedido"] = frmInsertRows.Producto.Cant;
                ChildsRows["cant_real"] = 0;



                ChildsRows.Row.SetParentRow(((DataRowView)Bs.Current).Row, Ds.Relations["FK_MASTER_DETAILS"]);
                ChildsRows.EndEdit();
                ContarFilas();

            }
        }

        private void ContarFilas()
        {
            int filas = GridItems.Rows.Count;
            txt_total_cantidad.Text = filas.ToString();
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            if (EditMode == "ADDNEW")
            {
                SAVE_NEW();
            }
            else if (EditMode == "UPDATE")
            {
                SAVE_UPDATE();
            }
        }

        private void SAVE_NEW()
        {
            EditMode = "EDIT";
            Services.GuardarOrden(CREATE_ORDEN_OBJECT());
            int ProxConsec = Convert.ToInt16(txt_numeroOrden.Text) + 1;
            Services.UpdateConsecOrden(ProxConsec.ToString());
            btn_primero.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_anterior.Enabled = true;
            btn_save.Enabled = false;
            btn_cancel.Enabled = false;
            btn_create.Enabled = true;
            btn_addRows.Enabled = false;
            btn_deleteRows.Enabled = false;
            btn_template.Enabled = false;
            btn_LoadRows.Enabled = false;
            btn_CloseDoc.Enabled = true;
            btn_AnularDoc.Enabled = true;
            btn_SearchDoc.Enabled = true;
            btn_printDoc.Enabled = true;
            btn_ExportDoc.Enabled = true;
            RefreshDocument();
        }
        private void SAVE_UPDATE()
        {

        }

        private OrdenMP CREATE_ORDEN_OBJECT()
        {
            //Header.
            OrdenMP Orden = new()
            {
                Numero = txt_numeroOrden.Text,
                Fecha_Recepcion = Convert.ToDateTime(txt_fecha_recepcion.Text),
                Fecha_Produccion = Convert.ToDateTime(txt_fecha_produccion.Text),
                Orden_Compra = txt_OrdenCompra.Text,
                Proveedor_id = Guid.Parse(txt_prov_Id.Text),
                Proveedor_name = txt_nombre_prov.Text,
                Transport_id = Guid.Parse(txt_transport_id.Text),
                Transport_name = txt_transport_name.Text,
                Guia = txt_guia.Text,
                Lote = txt_lote.Text,
                Numero_Embarque = txt_embarque.Text,
                Person_Id = Guid.Parse(txt_person_id.Text),
                Person_Name = txt_person_name.Text,
                CloseDocument = false,
                Notas = txt_notas.Text + Environment.NewLine + "Documento de Materia Prima Creado: " + Environment.NewLine + DateTime.Now,
                Renglones = Convert.ToInt32(txt_total_cantidad.Text),


            };
            //Items.
            foreach (DataGridViewRow Item in GridItems.Rows)
            {

                var ProductId = Item.Cells["product_id"].Value;
                var ProductName = Item.Cells["product_name"].Value;
                var Product_Type = Item.Cells["product_type"].Value;
                var WidthMaster = Convert.ToDouble(Item.Cells["width"].Value);
                var LengthMaster = Convert.ToDouble(Item.Cells["length"].Value);
                var MsiMaster = Convert.ToDouble(Item.Cells["msi"].Value);
                var RollId = Item.Cells["rollid"].Value.ToString()!;
                var Splice = Convert.ToInt16(Item.Cells["splice"].Value);
                var Core = Convert.ToDouble(Item.Cells["core"].Value);
                var Ubicacion = Item.Cells["ubicacion"].Value.ToString()!;
                var Cantidad_Pedido = Convert.ToInt32(Item.Cells["cant_pedido"].Value);
                var Cantidad_Real = Convert.ToInt32(Item.Cells["cant_real"].Value);
                Orden.Items.Add(new OrdenDetailsMP
                {
                    Numero = txt_numeroOrden.Text,
                    Product_Id = ProductId.ToString()!,
                    Product_Name = ProductName.ToString()!,
                    Product_Type = Product_Type.ToString()!,
                    Width = WidthMaster,
                    Length = LengthMaster,
                    Msi = MsiMaster,
                    RollId = RollId,
                    Splice = Splice,
                    Core = Core,
                    Ubicacion = Ubicacion,
                    Cantidad_Pedido = Cantidad_Pedido,
                    Cantidad_Real = Cantidad_Real
                });
            }

            return Orden;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DataRowView FilaActual;
            FilaActual = (DataRowView)Bs.Current;
            FilaActual.Row.Delete();
            Bs.EndEdit();
            Bs.Position = Bs.Count;
            // Cerrar el formulario.
            btn_primero.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_anterior.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_create.Enabled = true;
            btn_save.Enabled = false;
            btn_cancel.Enabled = false;
            txt_fecha_produccion.Enabled = false;
            txt_fecha_recepcion.Enabled = false;
            txt_OrdenCompra.ReadOnly = true;
            txt_guia.ReadOnly = true;
            txt_lote.ReadOnly = true;
            txt_embarque.ReadOnly = true;
            btn_ProvBuscar.Enabled = false;
            btn_TransportBuscar.Enabled = false;
            btn_RecepBuscar.Enabled = false;
            GridItems.ReadOnly = true;
            RefreshDocument();
        }

        private void btn_template_Click(object sender, EventArgs e)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("TemplateMateriaPrima");
            string filePath = Path.Combine(Environment.CurrentDirectory, "Template");
            var col1 = worksheet.Column(1);
            col1.Style.NumberFormat.Format = "@";
            col1.Width = 20; // Ajustar el ancho de la columna
            var col2 = worksheet.Column(2);
            col2.Width = 20; // Ajustar el ancho de la columna
            worksheet.Cell(1, 1).Value = "Product. Id.";
            worksheet.Cell(1, 2).Value = "Product Name";
            worksheet.Cell(1, 3).Value = "Tipo";
            worksheet.Column(3).Width = 20;
            worksheet.Cell(1, 4).Value = "Width";
            worksheet.Cell(1, 5).Value = "Length";
            worksheet.Cell(1, 6).Value = "Msi";
            worksheet.Cell(1, 7).Value = "Core";
            worksheet.Cell(1, 8).Value = "Slipce";
            worksheet.Cell(1, 9).Value = "Roll-Id";
            worksheet.Columns().AdjustToContents();
            workbook.SaveAs(filePath + ".xlsx");
            var psi = new ProcessStartInfo
            {
                FileName = filePath + ".xlsx",      // Abre con la app por defecto (.xlsx → Excel)
                UseShellExecute = true     // Necesario en .NET Core/5+ para usar la asociación de ficheros
            };
            try
            {
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir el archivo automáticamente: {ex.Message}");
            }
        }

        private void btn_LoadRows_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "Template.xlsx");
            using var workbook = new XLWorkbook(filePath);
            var worksheet = workbook.Worksheet(1);
            //Empiezo en la fila 2 por los encabezados.
            var filas = worksheet.Rows().Skip(1);
            foreach (var fila in filas)
            {
                if (fila.Cell(1).Value.ToString() == string.Empty) continue; //Si la celda esta vacia, no la agrego.
                ChildsRows = (DataRowView)BsDetalle.AddNew();
                ChildsRows.BeginEdit();
                ChildsRows["numero"] = txt_numeroOrden.Text;
                ChildsRows["product_id"] = fila.Cell(1).Value.ToString()!;
                ChildsRows["product_name"] = fila.Cell(2).Value.ToString()!;
                ChildsRows["type"] = fila.Cell(3).Value.ToString()!;
                ChildsRows["width"] = fila.Cell(4).GetValue<double>();
                ChildsRows["length"] = fila.Cell(5).GetValue<double>();
                ChildsRows["msi"] = fila.Cell(6).GetValue<double>();
                ChildsRows["core"] = fila.Cell(7).GetValue<double>();
                ChildsRows["splice"] = fila.Cell(8).GetValue<int>();
                ChildsRows["rollid"] = fila.Cell(9).Value.ToString()!;
                ChildsRows["ubicacion"] = "SU";
                ChildsRows["cant_pedido"] = 1;
                ChildsRows["cant_real"] = 0;
                ChildsRows.Row.SetParentRow(((DataRowView)Bs.Current).Row, Ds.Relations["FK_MASTER_DETAILS"]);
                ChildsRows.EndEdit();
            }
            if (GridItems.Rows.Count > 0)
            {
                GridItems.ClearSelection(); // Limpia selección previa
                GridItems.Rows[0].Selected = true; // Selecciona la primera fila
                GridItems.CurrentCell = GridItems.Rows[0].Cells[0]; // Mueve el foco
                ContarFilas();
            }
        }

        private void btn_OrdenBuscar_Click(object sender, EventArgs e)
        {
            Frm_oneparameter frmbuscar = new()
            {
                StartPosition = StartPosition = FormStartPosition.Manual,
                Location = new Point(this.Location.X + 300, this.Location.Y + 150)
            };
            frmbuscar.ShowDialog();
            if (frmbuscar.Parameter != null)
            {
                int busqueda = Bs.Find("numero", frmbuscar.Parameter);
                if (busqueda > 0)
                {
                    Bs.Position = busqueda;
                    RefreshDocument();
                }
                else
                {
                    MessageBox.Show("No se encontro el numero del documento...", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void btn_CloseDoc_Click(object sender, EventArgs e)
        {
            CerrarDocumentoOrder();
        }

        private void CerrarDocumentoOrder()
        {

            if (chk_DocumentClose.Checked)
            {
                MessageBox.Show("El Documento ya se encuentra cerrado.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Deseas Cerrar este Documento (S/N)???", "Confrmar Cierre",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Services.CloseOrder(txt_numeroOrden.Text);
                var doc = (DataRowView)Bs.Current;
                doc.BeginEdit();
                doc["CloseDocument"] = true;
                doc.EndEdit();
                doc.Row.AcceptChanges();
                RefreshDocument();
                //Actualizo los logs del documento en el campo notas
                string user = "-> Npino - Departamento de Sistema";
                string dataClose = $"Documento cerrado por: " + user + Environment.NewLine +
                                  "Fecha de Cierre: " + DateTime.Now + Environment.NewLine;

                Services.UpDateLogsNotes(txt_numeroOrden.Text, dataClose);

            }
            else if (result == DialogResult.No)
            {
                //enviar mensaje al log de windows
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void btn_AnularDoc_Click(object sender, EventArgs e)
        {
            if (chk_anulado.Checked)
            {
                MessageBox.Show("El Documento ya esta anulado...", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Deseas Anular este Documento (S/N)???", "Confrmar Cierre",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Services.AnularOrden(txt_numeroOrden.Text);
                var doc = (DataRowView)Bs.Current;
                doc.BeginEdit();
                doc["Anulado"] = true;
                doc.EndEdit();
                doc.Row.AcceptChanges();
                RefreshDocument();
                //Actualizo los logs del documento en el campo notas
                string user = "-> Npino - Departamento de Sistema";
                string dataClose = $"Documento Anulado por: " + user + Environment.NewLine +
                                  "Fecha de en que el documento se anulo: " + DateTime.Now + Environment.NewLine;

                Services.UpDateLogsNotes(txt_numeroOrden.Text, dataClose);

            }

        }
        private void chk_anulado_Click(object sender, EventArgs e)
        {
            // Cancelar cambio manualmente
            chk_anulado.Checked = !chk_anulado.Checked;
        }

        private void chk_anulado_KeyDown(object sender, KeyEventArgs e)
        {
            // Prevenir cambio con teclado
            e.Handled = true;
        }

        private void chk_DocumentClose_Click(object sender, EventArgs e)
        {
            // Cancelar cambio manualmente
            chk_DocumentClose.Checked = !chk_DocumentClose.Checked;
        }

        private void chk_DocumentClose_KeyDown(object sender, KeyEventArgs e)
        {
            // Prevenir cambio con teclado
            e.Handled = true;
        }
    }
}
