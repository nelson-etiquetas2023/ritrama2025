using Ritrama2025.LabelSdk;
using Ritrama2025.Models;
using System.ComponentModel;

namespace Ritrama2025.Forms.Otros
{
    public partial class PrintLabelsRolls : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<RolloCortado> Rollos { get; set; } = new();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Fechapro { get; set; } = string.Empty;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Orden_Corte { get; set; } = string.Empty;
        public PrintLabelsRolls()
        {
            InitializeComponent();
        }

        private void PrintLabelsRolls_Load(object sender, EventArgs e)
        {
            txt_numero_etiq.Text = Rollos.Count().ToString();
            txt_desde.Text = "1";
            txt_hasta.Text = Rollos.Count().ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int label_init = Convert.ToInt32(txt_desde.Text);
            int label_end = Convert.ToInt32(txt_hasta.Text);

            for (int i = label_init; i<=label_end; i++) 
            {
                string template = @"^XA^POR
                ^FO700,100^A0R,60,60^FDFEDRIGONNI^FS
                ^FO750,650^A0R,30,20^FDPRODUCT ID^FS
                ^FO750,1000^A0R,30,20^FDROLL ID^FS

                ^FO700,650^A0R,50,50^FD{product_id}^FS
                ^FO700,1000^A0R,40,40^FD{rollid}^FS

                ^FO680,50^GB1,1200,3,1^FS
                ^FO680,500^GB200,3,1^FS
                ^FO680,950^GB200,3,1^FS

                ^FO635,50^A0R,30,20^FDPRODUCTO^FS
                ^FO635,1000^A0R,30,20^FDFECHA^FS

                ^FO580,50^A0R,50,60^FD{product_name}^FS
                ^FO580,1000^A0R,40,40^FD{fecha}^FS
  
                ^FO550,50^GB1,1200,3,1^FS
                ^FO550,950^GB130,3,1^FS
            
                ^FO510,50^A0R,30,20^FDWIDTH (Inch):^FS
                ^FO510,350^A0R,30,20^FDLENGTH (Pies):^FS
                ^FO510,650^A0R,30,20^FDMSI:^FS
                ^FO510,1000^A0R,30,20^FDSPLICE:^FS

                ^FO440,50^A0R,60,60^FD{width}^FS
                ^FO440,350^A0R,60,60^FD{lenght}^FS
                ^FO440,650^A0R,60,60^FD{msi}^FS
                ^FO440,1000^A0R,60,60^FD{splice}^FS

                ^FO420,50^GB1,1200,3,1^FS
                ^FO420,300^GB130,3,1^FS
                ^FO420,600^GB130,3,1^FS
                ^FO420,950^GB130,3,1^FS

                ^FO380,50^A0R,30,20^FDSTATUS:^FS
                ^FO380,280^A0R,30,20^FDCUSTOMER ID:^FS
                ^FO380,650^A0R,30,20^FDORDEN CORTE:^FS
                ^FO380,1000^A0R,30,20^FDROLL NUMBER:^FS

                ^FO300,50^A0R,60,60^FD{status}^FS
                ^FO300,280^A0R,60,60^FD{customer_id}^FS
                ^FO300,650^A0R,60,60^FD{orden}^FS
                ^FO300,1000^A0R,60,60^FD{roll_number}^FS

                ^FO280,50^GB1,1200,3,1^FS            
                ^FO280,250^GB140,3,1^FS
                ^FO280,600^GB140,3,1^FS
                ^FO280,950^GB140,3,1^FS
            
                ^FO200,50^A0R,30,20^FDPRODUCT ID:^FS
                ^FO200,610^A0R,30,20^FDUNIQUE CODE:^FS
            
                ^BY4,4,100

                ^FO80,200^BCR,150,Y,N,N
                ^FD{product_id}^FS
                ^FO80,760^BCR,150,Y,N,N
                ^FD{unique_code}^FS
                ^FO50,600^GB235,3,1^FS^XZ";

                string product_id = Rollos[i - 1].Product_Id.Trim();
                string productName = Rollos[i - 1].Product_Name;
                string rollid = Rollos[i - 1].Roll_Id;
                string width = Rollos[i - 1].Width.ToString("F3") ;
                string length = Rollos[i - 1].Length.ToString("F3");
                string msi = Rollos[i - 1].Msi.ToString("F3");
                string splice = Rollos[i - 1].Splice.ToString();
                string status = Rollos[i - 1].Status.ToString().Substring(0, 4);
                string code_person = Rollos[i - 1].Code_Person.ToString();
                string roll_number = Rollos[i - 1].RollNumber.ToString();
                string unique_code = Rollos[i - 1].UniqueCode.ToString().Trim();

                var values = new Dictionary<string, string>
                {
                    { "product_id", product_id },
                    { "product_name", productName },
                    { "rollid", rollid },
                    { "fecha", Fechapro.ToString() },
                    { "width", width },
                    { "lenght", length  },
                    { "msi", msi },
                    { "splice", splice  },
                    { "status", status  },
                    { "customer_id", code_person },
                    { "orden", Orden_Corte },
                    { "roll_number", roll_number },
                    { "unique_code", unique_code },
                    { "Codigo", product_id }
                };

                bool ok = ZebraTemplateEngine.Print("ZDesigner ZT410-203dpi ZPL", template, values, StandardLabelSizes.Size_4x6_203dpi);
            }
            
        }
    }
}
