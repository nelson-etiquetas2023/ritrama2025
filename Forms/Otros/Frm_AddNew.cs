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
        readonly CommonService service = new();
        private void Frm_AddNew_Load(object sender, EventArgs e)
        {
            Titulo.Text = TitleForm;
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (NombreEntidad == "Transporte")
                {
                    Guid ConsecGuid = Guid.NewGuid();
                    string Consecutivo = ConsecGuid.ToString();

                    DataRow dr = Dt.NewRow();
                    dr["transport_id"] = Consecutivo.ToString();
                    dr["transport_name"] = txt_name.Text.ToUpper();
                    Dt.Rows.Add(dr);
                    //Guardar en Base de Datos.
                    service.SaveTransportEntity(Consecutivo.ToString(), txt_name.Text.ToUpper());
                    this.Close();
                }
                if (NombreEntidad == "Chofer")
                {
                    Guid ConsecGuid = Guid.NewGuid();
                    string Consecutivo = ConsecGuid.ToString();
                    DataRow dr = Dt.NewRow();
                    dr["chofer_id"] = Consecutivo.ToString();
                    dr["chofer_name"] = txt_name.Text.ToUpper();
                    Dt.Rows.Add(dr);
                    //Guardar en Base de Datos.
                    service.SaveChoferEntity(Consecutivo.ToString(), txt_name.Text.ToUpper());
                    this.Close();
                }
                if (NombreEntidad == "Camion")
                {
                    Guid ConsecGuid = Guid.NewGuid();
                    string Consecutivo = ConsecGuid.ToString();
                    DataRow dr = Dt.NewRow();
                    dr["placas_id"] = Consecutivo.ToString();
                    dr["camion_name"] = txt_name.Text.ToUpper();
                    Dt.Rows.Add(dr);
                    //Guardar en Base de Datos.
                    service.SaveCamionEntity(Consecutivo.ToString(), txt_name.Text.ToUpper());
                    this.Close();
                }
            }
            catch (SqlException Ex)
            {
                MessageBox.Show("Error al crear la entidad de transporte" + Ex);
            }
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
