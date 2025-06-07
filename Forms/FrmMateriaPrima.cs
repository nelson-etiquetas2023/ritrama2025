using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ritrama2025.Forms
{
    public partial class FrmMateriaPrima : Form
    {
        public FrmMateriaPrima()
        {
            InitializeComponent();
        }

        private void FrmMateriaPrima_Load(object sender, EventArgs e)
        {
            //Configurar las columnas del detalle de los productos.
            ADD_COLUMN_GRID("product_id", 70, "Product Id.", "product_id", GridItems);
            ADD_COLUMN_GRID("product_name", 200, "Product Name.", "product_name", GridItems);
            ADD_COLUMN_GRID("product_Type", 70, "Tipo", "product_type", GridItems);
            ADD_COLUMN_GRID("width", 80, "Width [Inch.]", "width", GridItems);
            ADD_COLUMN_GRID("length", 80, "Length [Pies]", "length", GridItems);
            ADD_COLUMN_GRID("msi", 80, "Msi", "msi", GridItems);
            ADD_COLUMN_GRID("rollid", 70, "Roll-Id.", "rollid", GridItems);
            ADD_COLUMN_GRID("ubic", 70, "Ubica.", "ucib", GridItems);
            ADD_COLUMN_GRID("splice", 65, "Splice", "splice", GridItems);
            ADD_COLUMN_GRID("core", 65, "Core", "core", GridItems);
            ADD_COLUMN_GRID("cantidad", 65, "Cantidad Pedido", "cantidad", GridItems);
            ADD_COLUMN_GRID("cant_real", 65, "Cantidad Real", "cant_real", GridItems);
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
    }
}
