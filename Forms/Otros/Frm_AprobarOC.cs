using Ritrama2025.Models;
using Ritrama2025.Services;
using System.ComponentModel;

namespace Ritrama2025.Forms.Otros
{
    public partial class Frm_AprobarOC : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NumeroOC { get; set; } = null!;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TypeAction { get; set; } = null!;
        //readonly CommonService servicio = new();
        public Frm_AprobarOC()
        {
            InitializeComponent();
        }
        private void Frm_AprobarOC_Load(object sender, EventArgs e)
        {
            if (TypeAction == "WRITE")
            {
                label_datetime.Text = "Fecha y Hora de Aprobacion del Documento: " + DateTime.Now.ToString();
            }
            else 
            {
                txt_comentarios.ReadOnly = true;
                txt_OrdenServicio.ReadOnly = true;
                txt_OrdenTrabajo.ReadOnly = true;
                txt_person.ReadOnly = true;
                bot_cancel.Enabled = false;
                bot_documentCheck.Enabled = false;
                chk_closeOrden.Enabled = false;
                //DocumentCheckOC doc = servicio.DocumentCheckReadOC(NumeroOC);
                //txt_comentarios.Text = doc.Observaciones;
                //txt_person.Text = doc.PersonCheck;
                //txt_OrdenServicio.Text = doc.Orden_Servicio;
                //txt_OrdenTrabajo.Text = doc.Orden_Trabajo;
                //label_datetime.Text = "Este Documento se Aprtobo: " + doc.FechaCheck.ToString();
            }

            
        }

        private void Bot_documentCheck_Click(object sender, EventArgs e)
        {
            if (txt_person.Text == string.Empty) 
            {
                MessageBox.Show("Debe introducir la persona que autizo la orden de corte.");
                return;
            }
            if (txt_OrdenServicio.Text == string.Empty)
            {
                MessageBox.Show("Debe introducir la orden de servicio.");
                return;
            }
            if (txt_OrdenTrabajo.Text == string.Empty)
            {
                MessageBox.Show("Debe introducir la orden de trabajo.");
                return;
            }
            DocumentCheckOC document = new()
            {
                OrdenCorte = NumeroOC,
                PersonCheck = txt_person.Text,
                Orden_Trabajo = txt_OrdenTrabajo.Text,
                Orden_Servicio = txt_OrdenServicio.Text,
                Observaciones = txt_comentarios.Text,
                FechaCheck = DateTime.Now
            };
            //servicio.DocumentCheckWriteOC(document);
            this.Close();
        }
    }
}
