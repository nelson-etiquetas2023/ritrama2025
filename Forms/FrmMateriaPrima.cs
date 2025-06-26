using Ritrama2025.Forms.Seleccion;
using Ritrama2025.Models;
using Ritrama2025.Services.MateriaPrima;
using System;
using System.Data;


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
            ADD_COLUMN_GRID("msi", 75, "Msi", "msi", GridItems);
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
            txt_data_document.DataBindings.Add("Text", Bs, "fecha_hora_close");
            txt_notas.DataBindings.Add("Text", Bs, "notas");
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
            Bs.Position++;
        }

        private void Btn_anterior_Click(object sender, EventArgs e)
        {
            Bs.Position--;
        }

        private void Btn_ultimo_Click(object sender, EventArgs e)
        {
            Bs.Position = Bs.Count - 1;
        }

        private void Btn_primero_Click(object sender, EventArgs e)
        {
            Bs.Position = 0;
        }

        private void Btn_create_Click(object sender, EventArgs e)
        {
            chk_anulado.DataBindings.Clear();
            ParentRow = (DataRowView)Bs.AddNew();
            ParentRow.BeginEdit();
            ParentRow["numero"] = 1004;
            ParentRow["total_cantidad"] = 0;
            ParentRow.EndEdit();
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
            }


        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
           Services.GuardarOrden(CREATE_ORDEN_OBJECT());
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
                Notas = txt_notas.Text,
                Renglones = Convert.ToInt32(txt_total_cantidad.Text)
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
    }
}
