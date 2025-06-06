using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ritrama2025.Forms.Otros
{
    public partial class Frm_oneparameter : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Parameter { get; set; } = null!;
        public Frm_oneparameter()
        {
            InitializeComponent();
        }

        private void Frm_oneparameter_Load(object sender, EventArgs e)
        {

        }

        private void Btn_aceptar_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }
        private void GuardarDatos() 
        {
            this.Parameter = txt_buscar.Text;
            this.Close();

        }

        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                GuardarDatos();
            }
        }
    }
}
