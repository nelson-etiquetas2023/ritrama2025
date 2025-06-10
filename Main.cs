using Ritrama2025.Forms;
using System.Drawing;
using System.ComponentModel;


namespace Ritrama2025
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            PropertyGrid propertyGrid = new()
            {
                SelectedObject = new Configuration(),
                Size = new Size(400, 600),
                Dock = DockStyle.Right
            };
            Controls.Add(propertyGrid);
        }

        private void Bot_despacho_Click(object sender, EventArgs e)
        {
            OpenFormSingleInstance<FrmDespacho>("DESPACHO");
        }

        private void Bot_ordencorte_Click(object sender, EventArgs e)
        {
            OpenFormSingleInstance<FrmOrdenCorte>("OC");
        }

        private void Bot_recepciones_Click(object sender, EventArgs e)
        {
            OpenFormSingleInstance<FrmMateriaPrima>("MT");
        }

        private void OpenFormSingleInstance<T>(string nameForm) where T : Form, new()
        {
            var existingForm = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (existingForm != null)
            {
                existingForm.BringToFront();
                if (existingForm.WindowState == FormWindowState.Minimized)
                    existingForm.WindowState = FormWindowState.Normal;
            }
            else
            {
                if (nameForm == "OC")
                {
                    FrmOrdenCorte frmOrdenCorte = new()
                    {
                        MdiParent = this,
                        StartPosition = FormStartPosition.Manual,
                        Location = new Point { X = Location.X + 20, Y = Location.Y + 20 }
                    };
                    frmOrdenCorte.Show();
                }
                if (nameForm == "DESPACHO")
                {
                    FrmDespacho frmdespacho = new()
                    {
                        MdiParent = this,
                        StartPosition = FormStartPosition.Manual,
                        Location = new Point { X = Location.X + 20, Y = Location.Y + 20 }
                    };
                    frmdespacho.Show();
                }
                if (nameForm == "MT")
                {
                    FrmMateriaPrima formMT = new()
                    {
                        MdiParent = this,
                        StartPosition = FormStartPosition.Manual,
                        Location = new Point { X = Location.X + 20, Y = Location.Y + 20 }
                    };
                    formMT.Show();
                }
            }
        }
    }
    public class Configuration
    {
        [Category("Apariencia")]
        [DisplayName("Color de fondo")]
        [Description("Color de fondo de la aplicación.")]
        public Color BackgroundColor { get; set; } = Color.White;

        [Category("Habilitar")]
        [DisplayName("Habilitado")]
        [Description("Habilita o deshabilita la aplicación.")]
        public bool Enabled { get; set; } = true;

        [Category("Consecutivo del Sistema")]
        [DisplayName("Orden de Corte")]
        [Description("Consecutivo de produccion de la Orden de Corte.")]
        public string OrdenCorte { get; set; } = "12507";

        [Category("Consecutivo del Sistema")]
        [DisplayName("Despacho")]
        [Description("Consecutivo de despacho de ventas.")]
        public string Despacho { get; set; } = "67458";

        [Category("Consecutivo del Sistema")]
        [DisplayName("Materia Prima")]
        [Description("Este es el consecutio que se utiliza en la recepcion de materia prima con importaciones")]
        public string ConsecMateriaPrima { get; set; } = "11507";

        [Category("Depuracion")]
        [DisplayName("Tipo Depuracion")]
        [Description("Opciones para la depuracion del Sistema")]
        public DebugMode Debugmode { get; set; } = DebugMode.Basic;

        [Category("Desperdicio")]
        [DisplayName("Width [Inch.]:")]
        [Description("Calculo del desperdicio del width en el master.")]
        public decimal Desperdicio_width { get; set; } = 1;

        [Category("Desperdicio")]
        [DisplayName("Length [Pies]:")]
        [Description("Calculo del desperdicio para length de los master.")]
        public decimal Desperdicio_length { get; set; } = 100;

        [Category("Conexion")]
        [DisplayName("Configuracion de la Conexion")]
        [Description("¨Parametros de Conexion de la base de datos")]
        public ConnectionSettings DatabaseConnection { get; set; } = new ConnectionSettings();


    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ConnectionSettings
    {
        [DisplayName("Servidor")]
        public string Server { get; set; } = "localhost";
        [DisplayName("Puerto")]
        public int Port { get; set; } = 1433;
    }

    public enum DebugMode
    {
        None,
        Basic,
        Debug,
        Release

    }
}