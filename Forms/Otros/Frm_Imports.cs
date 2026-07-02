using ClosedXML.Excel;
using Microsoft.Data.SqlClient;
using Ritrama2025.Models;
using Ritrama2025.Services.InventarioService;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace Ritrama2025.Forms.Otros
{
    public partial class Frm_Imports : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FileName { get; set; } = null!;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PathFileName { get; set; } = null!;

        private IInventarioService InventarioService { get; set; }
        readonly List<ProductMAP> lista = [];

        List<Product> ListaProductsNotFound = new();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StringBuilder ErrorsImporExcel { get; set; } = new();

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

        private void Btn_load_data_Click(object sender, EventArgs e)
        {
            Grid_Items.DataSource = "";
            LoadData();
            chk_saveproductsnotfound.Enabled = true;
            btn_accion.Enabled = true;
        }

        private void LoadData()
        {
            lista.Clear();
            string filePath = PathFileName;
            //string fileName = FileName;
            //leer la hoja de excel.
            try
            {
                using var workbook = new XLWorkbook(filePath);
                var worksheet = workbook.Worksheet(1);
                //Empiezo en la fila 2 por los encabezados.
                var filas = worksheet.Rows().Skip(1);
                // recorro filas donde esta la data de la hoja.
                //crear el validador de excel.
                var validator = new ExcelValidator();
                int itemno = 1;
                //1.- validaciones de las columnas
                foreach (var item in filas)
                {
                    ProductMAP producto = new()
                    {
                        ItemNo = itemno++,
                        Product_Id = item.Cell(1).Value.ToString(),
                        Product_Name = item.Cell(2).Value.ToString(),
                        Rollid = item.Cell(3).Value.ToString(),
                        Width = validator.TryGetDouble(item.Cell(4), worksheet),
                        Length = validator.TryGetDouble(item.Cell(5), worksheet),
                        Splice = validator.TryGetInt(item.Cell(6), worksheet),
                        Fecha_Produccion = validator.TryGetDateTime(item.Cell(7), worksheet),
                        Factura = item.Cell(8).Value.ToString(),
                        Ubic = item.Cell(9).Value.ToString(),
                        Fecha_Llegada = validator.TryGetDateTime(item.Cell(10), worksheet),
                        Paleta = item.Cell(11).Value.ToString(),
                    };
                    lista.Add(producto);
                    txt_log_notifications.Text = validator.Errores.ToString();
                }
                Grid_Items.DataSource = lista;
                //2.- validar productos que no existen en la base de datos
                if (chk_valid_products.Checked)
                {
                    ProductsNotFoundDB();
                }
                //NUMERO DE ERRORES    
                int numeroDeLineas = (validator.Errores.ToString().Split(Environment.NewLine).Length) - 1;
                txt_errors.Text = numeroDeLineas.ToString();
                MessageBox.Show("Se Cargo los datos con Exito...!");
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show("Error al tratar de abrir la hoja de excel, " +
                    "si esta abierta por favor cierrela y vuelva a intentarlo...[error code:] " + ex.Message);
            }
            txt_number_rows.Text = Grid_Items.Rows.Count.ToString();
        }

        private void SaveProductsNotDFoundDB()
        {
            //recorrer la lista de productos no encotrados.
            foreach (var item in ListaProductsNotFound)
            {
                var producto = new Product
                {
                    Product_id = item.Product_id,
                    Product_Name = item.Product_Name,
                    Product_Description = item.Product_Name,
                    Master = true,
                    Anulado = false,
                    Hoja = false,
                    Graphics = false,
                    RolloCortado = false,
                };
                try
                {
                    InventarioService.InsertProduct(producto);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al guardar el producto en la base de datos, [error code:] " + ex.Message);
                }

                //notificar que se creo el producto.
                txt_log_notifications.Text = $"Se creo el producto {producto.Product_id} " +
                    $"- {producto.Product_Name} en la base de datos." + Environment.NewLine;

                MessageBox.Show("Se actualizaron los productos del sistema...");
            }
        }

        private void Btn_saveDatabase_Click(object sender, EventArgs e)
        {
            int errors = int.Parse(txt_errors.Text);

            if (errors > 0)
            {
                MessageBox.Show("No se pueden Guardar los datos mientra la hoja de excel tenga errores en los datos...");
                return;

            }
            //Guardar en Base de Datos.
            InventarioService.SaveMasterInitialDB(lista);
        }
        private void ProductsNotFoundDB()
        {
            string messageProduct = "";

            foreach (var item in lista)
            {
                //verifico si existe en la base de datos.
                if (!InventarioService.ValidProductid(item.Product_Id))
                {
                    messageProduct = "-> PRODUCTO NO EXISTE: " + " [ " + item.Product_Id + " - "
                    + item.Product_Name + " ] " + Environment.NewLine;

                    //crear la notificacion.
                    txt_log_notifications.Text += messageProduct;

                    //Agrego a una lista de productos no encontrados.
                    ListaProductsNotFound.Add(new Product
                    {
                        Product_id = item.Product_Id,
                        Product_Name = item.Product_Name,
                    });
                }
            }
        }
        public class ExcelValidator
        {
            public StringBuilder Errores { get; private set; } = new();

            public void NotificarProductoNoexiste(string message)
            {
                Errores.AppendLine(message);
            }

            public double TryGetDouble(IXLCell cell, IXLWorksheet hoja)
            {
                string valor = cell.GetString().Trim();
                string celdaRef = cell.Address.ToString()!;
                int fila = cell.Address.RowNumber;
                int columna = cell.Address.ColumnNumber;
                string nombreColumnma = hoja.Cell(1, columna).GetString().Trim();

                if (double.TryParse(valor, NumberStyles.Any, CultureInfo.InvariantCulture, out var resultado))
                    return resultado;

                Errores.AppendLine($"Error en la columna: {nombreColumnma}, un valor tipo DOUBLE -> Celda: {celdaRef}, (Fila {fila}, Columna {columna}): '{valor}' no es un numero decimal -> valor por defecto 0.0");

                return 0.0;
            }

            public int TryGetInt(IXLCell cell, IXLWorksheet hoja)
            {
                string valor = cell.GetString().Trim();
                string celdaRef = cell.Address.ToString()!;
                int fila = cell.Address.RowNumber;
                int columna = cell.Address.ColumnNumber;
                string nombreColumnma = hoja.Cell(1, columna).GetString().Trim();

                if (int.TryParse(valor, out var resultado))
                    return resultado;

                Errores.AppendLine($"Error en la columna: {nombreColumnma}, un valor tipo INT -> Celda: {celdaRef}, (Fila {fila}, Columna {columna}): '{valor}' no es un numero entero -> valor por defecto 0");

                return 0;

            }

            public DateTime TryGetDateTime(IXLCell cell, IXLWorksheet hoja)
            {
                string valor = cell.GetString().Trim();
                string celdaRef = cell.Address.ToString()!;
                int fila = cell.Address.RowNumber;
                int columna = cell.Address.ColumnNumber;
                string nombreColumnma = hoja.Cell(1, columna).GetString().Trim();

                if (DateTime.TryParse(valor, out var resultado))
                    return resultado;

                Errores.AppendLine($"Error en la columna: {nombreColumnma}, un valor tipo DATETIME -> Celda: {celdaRef}, (Fila {fila}, Columna {columna}): '{valor}' no es una fecha valida -> valor por defecto DateTime.MinValue");

                return DateTime.MinValue;
            }
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
            ADD_COLUMN_GRID("fecha_fabricacion", 70, "Fecha Produccion", "fecha_produccion", Grid_Items);
            ADD_COLUMN_GRID("recep", 70, "Recepcion", "factura", Grid_Items);
            ADD_COLUMN_GRID("ubic", 70, "Ubicacion", "ubic", Grid_Items);
            ADD_COLUMN_GRID("fecha_llegada", 70, "Fecha Llegada", "fecha_llegada", Grid_Items);
            ADD_COLUMN_GRID("paleta", 70, "Paleta", "paleta", Grid_Items);
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

        private void btn_accion_Click(object sender, EventArgs e)
        {
            //Guardar los productos no encontrados en la base de datos.
            if (chk_saveproductsnotfound.Checked)
            {
                SaveProductsNotDFoundDB();
            }
        }
    }
}
