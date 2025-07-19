using System.ComponentModel;
using ClosedXML.Excel;
using Ritrama2025.Models;
using Ritrama2025.Services.InventarioService;

namespace Ritrama2025.Forms.Otros
{
    public partial class Frm_Imports : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FileName { get; set; } = null!;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PathFileName { get; set; } = null!;
        private IInventarioService InventarioService { get; set; }
        List<ProductMAP> lista = new();

        public Frm_Imports(IInventarioService inventarioService)
        {
            InventarioService = inventarioService;
            InitializeComponent();
        }

        private void Frm_Imports_Load(object sender, EventArgs e)
        {
            DefineColumnsGrid();
            txt_fileName.Text = FileName;
            txt_filePath.Text = PathFileName;
            txt_number_rows.Text = "0";
            txt_warning.Text = "0";
        }
        private void DefineColumnsGrid()
        {
            Grid_Items.AutoGenerateColumns = false;
            ADD_COLUMN_GRID("item", 30, "It.", "itemNo", Grid_Items);
            ADD_COLUMN_GRID("product_id", 50, "Product Id.", "product_id", Grid_Items);
            ADD_COLUMN_GRID("product_name", 300, "Product Name", "product_name", Grid_Items);
            ADD_COLUMN_GRID("rollid", 70, "Roll-Id", "rollid", Grid_Items);
            ADD_COLUMN_GRID("width", 70, "Width [Inch.]", "Width", Grid_Items);
            ADD_COLUMN_GRID("lenght", 70, "Length [Pies.]", "length", Grid_Items);
            ADD_COLUMN_GRID("splice", 70, "Splice", "splice", Grid_Items);
            ADD_COLUMN_GRID("ubic", 70, "Ubicacion", "ubic", Grid_Items);
            ADD_COLUMN_GRID("paleta", 70, "Paleta", "paleta", Grid_Items);
            ADD_COLUMN_GRID("recep", 70, "Recepcion", "recepcion", Grid_Items);
            ADD_COLUMN_GRID("fecha_fabricacion", 70, "Fecha Fabricacion", "fecha_fabricacion", Grid_Items);
            ADD_COLUMN_GRID("fecha_llegada", 70, "Fecha Llegada", "fecha_llegada", Grid_Items);


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

        private void btn_load_data_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        private void LoadData() 
        {
            string filePath = PathFileName;
            string fileName = FileName;
            //leer la hoja de excel.
            try
            {
                using var workbook = new XLWorkbook(filePath);
                var worksheet = workbook.Worksheet(1);
                //Empiezo en la fila 2 por los encabezados.
                var filas = worksheet.Rows().Skip(1);
                // recorro filas donde esta la data de la hoja.

                int itemno = 1;
                foreach (var item in filas)
                {
                    ProductMAP producto = new()
                    {
                        ItemNo = itemno++,
                        Product_Id = item.Cell(1).Value.ToString(),
                        Product_Name = item.Cell(2).Value.ToString(),
                        Rollid = item.Cell(3).Value.ToString(),
                        Width = item.Cell(4).GetDouble(),
                        Length = item.Cell(5).GetDouble(),
                        Splice = (int)item.Cell(6).Value,
                        Ubic = item.Cell(9).Value.ToString(),
                        Paleta = item.Cell(11).Value.ToString(),
                        Recepcion = item.Cell(8).Value.ToString(),
                    };
                    lista.Add(producto);
                }
                Grid_Items.DataSource = lista;
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show("Error al tratar de abrir la hoja de excel, si esta abierta por favor cierrela y vuelva a intentarlo...[error code:] " + ex.Message);
                throw;
            }
            txt_number_rows.Text = Grid_Items.Rows.Count.ToString();
        }

        private void btn_saveDatabase_Click(object sender, EventArgs e)
        {
            //Guardar en Base de Datos.
            InventarioService.SaveMasterInitialDB(lista);
            //Registrar Productos no registrados.
            ProductsNotFoundDB();
        }
        private void ProductsNotFoundDB() 
        {
            if (chk_product_NoFound.Checked)
            {
                foreach (var item in lista)
                {
                    if (!InventarioService.ValidProductid(item.Product_Id))
                    {
                        var producto = new Product
                        {
                            Product_id = item.Product_Id,
                            Product_Name = item.Product_Name,
                            Product_Description = item.Product_Name,
                            Master = true,
                            Anulado = false,
                            Hoja = false,
                            Graphics = false,
                            RolloCortado = false,
                        };
                        //No esta en productos, lo agrego.
                        InventarioService.InsertProduct(producto);
                    }
                }
                MessageBox.Show("Se actualizó los productos no registrados... ");
            }
        }
    }
}
