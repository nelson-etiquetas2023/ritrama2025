using Microsoft.Data.SqlClient;
using Ritrama2025.Services;
using System.ComponentModel;
using System.Data;

namespace Ritrama2025.Forms.Otros
{
    public partial class Frm_AddNew : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TitleForm { get; set; } = null!;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTable Dt { get; set; } = null!;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NombreEntidad { get; set; } = null!;
        public Frm_AddNew()
        {
            InitializeComponent();

        }
        CommonService service = new();
        private void Frm_AddNew_Load(object sender, EventArgs e)
        {
            Titulo.Text = TitleForm;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (NombreEntidad == "Transporte")
                {
                    int Consec = Dt.Rows.Count + 1;
                    DataRow dr = Dt.NewRow();
                    dr["transport_id"] = Consec.ToString();
                    dr["transport_name"] = txt_name.Text;
                    Dt.Rows.Add(dr);
                    //Guardar en Base de Datos.
                    service.SaveTransportEntity(Consec.ToString(), txt_name.Text);
                    this.Close();
                }
                if (NombreEntidad == "Chofer")
                {
                    int Consec = Dt.Rows.Count + 1;
                    DataRow dr = Dt.NewRow();
                    dr["chofer_id"] = Consec.ToString();
                    dr["chofer_name"] = txt_name.Text;
                    Dt.Rows.Add(dr);
                    //Guardar en Base de Datos.
                    service.SaveChoferEntity(Consec.ToString(), txt_name.Text);
                    this.Close();
                }
                if (NombreEntidad == "Camion")
                {
                    int Consec = Dt.Rows.Count + 1;
                    DataRow dr = Dt.NewRow();
                    dr["placas_id"] = Consec.ToString();
                    dr["camion_name"] = txt_name.Text;
                    Dt.Rows.Add(dr);
                    //Guardar en Base de Datos.
                    service.SaveCamionEntity(Consec.ToString(), txt_name.Text);
                    this.Close();
                }


            }
            catch (SqlException Ex)
            {
                MessageBox.Show("Error al crear la entidad de transporte" + Ex);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
