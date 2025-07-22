using Microsoft.Data.SqlClient;
using Ritrama2025.Services.ServiceLocator;
using Ritrama2025.Services.CommonService;
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

        private readonly ICommonService servicio;

        private static readonly Dictionary<string, (string Idcolumn, string NameColumn, Action<string, string> SaveAction)> entidades;

        static Frm_AddNew()
        {
            var servicioStatic = ServiceLocator.Get<ICommonService>();
            entidades = new()
                {
                    { "Transporte", ("transport_id", "transport_name", servicioStatic.SaveTransportEntity) },
                    { "Chofer", ("chofer_id", "chofer_name", servicioStatic.SaveChoferEntity) },
                    { "Camion", ("placas_id", "camion_name", servicioStatic.SaveCamionEntity) },
                    { "Persona", ("person_id", "person_name", servicioStatic.SavePersonEntity) },
                    { "Proveedor", ("proveedor_id", "proveedor_name", servicioStatic.SaveProvaiderEntity) },
                    { "operadores", ("operador_id", "nombre", servicioStatic.SaveOperatorEntity) },
                    { "clientes", ("customer_id", "customer_name", servicioStatic.SaveCustomerEntity) }
                };
        }

        public Frm_AddNew()
        {
            InitializeComponent();
            servicio = ServiceLocator.Get<ICommonService>();
        }

        private void Frm_AddNew_Load(object sender, EventArgs e)
        {
            Titulo.Text = TitleForm;
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (entidades.TryGetValue(NombreEntidad, out var entidad))
                {
                    Guid ConsecGuid = Guid.NewGuid();
                    string Consecutivo = ConsecGuid.ToString();
                    DataRow dr = Dt.NewRow();
                    dr[entidad.Idcolumn] = Consecutivo.ToString();
                    dr[entidad.NameColumn] = txt_name.Text.ToUpper();
                    Dt.Rows.Add(dr);
                    entidad.SaveAction(Consecutivo.ToString(), txt_name.Text.ToUpper());
                    this.Close();
                }
            }
            catch (SqlException Ex)
            {
                MessageBox.Show("Error al crear las entidades..." + Ex);
            }
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
