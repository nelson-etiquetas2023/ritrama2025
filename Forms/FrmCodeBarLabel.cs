using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UniPRT.Sdk.Comm;
using UniPRT.Sdk.Settings;
using Windows.ApplicationModel.AppService;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer.Discovery;

namespace Ritrama2025.Forms
{
    public partial class FrmCodeBarLabel : Form
    {
        public string zplData1 = "\u0010CT~~CD,~CC^~CT~\r\n^XA\r\n~TA000\r\n~JSN\r\n^LT0\r\n^MNW\r\n^MTD\r\n^PON\r\n^PMN\r\n^LH0,0\r\n^JMA\r\n^PR6,6\r\n~SD15\r\n^JUS\r\n^LRN\r\n^CI27\r\n^PA0,1,1,0\r\n^XZ\r\n^XA\r\n^MMT\r\n^PW440\r\n^LL320\r\n^LS0\r\n^FPH,1^FT65,42^A0N,23,23^FH\\^CI28^FDZebraDesigner for Developers^FS^CI27\r\n^FPH,1^FT39,101^A0N,23,23^FH\\^CI28^FDThis example^FS^CI27\r\n^FPH,1^FT39,130^A0N,23,23^FH\\^CI28^FDShow how to ptrint^FS^CI27\r\n^FPH,1^FT39,159^A0N,23,23^FH\\^CI28^FDMultiline using XML^FS^CI27\r\n^FPH,1^FT37,77^A0N,23,23^FH\\^CI28^FDDescription:^FS^CI27\r\n^FT33,250^A0N,23,23^FH\\^CI28^FDTicket No.:^FS^CI27\r\n^FT146,249^A0N,23,23^FH\\^CI28^FDAB45^FS^CI27\r\n^FT33,279^A0N,23,23^FH\\^CI28^FDCurrent Time:^FS^CI27\r\n^FT172,279^A0N,23,23^FH\\^CI28^FD16:12^FS^CI27\r\n^BY1,3,73^FT395,285^BCB,,Y,N,,A\r\n^FDXML2^FS\r\n^PQ1,,,Y\r\n^XZ\r\n";
        public string zplData2 = "\u0010CT~~CD,~CC^~CT~\r\n^XA\r\n~TA000\r\n~JSN\r\n^LT0\r\n^MNW\r\n^MTD\r\n^PON\r\n^PMN\r\n^LH0,0\r\n^JMA\r\n^PR6,6\r\n~SD15\r\n^JUS\r\n^LRN\r\n^CI27\r\n^PA0,1,1,0\r\n^XZ\r\n^XA\r\n^MMT\r\n^PW440\r\n^LL320\r\n^LS0\r\n^FT19,328^BQN,2,9\r\n^FH\\^FDLA,123456789012^FS\r\n^FT86,53^A0N,28,28^FH\\^CI28^FDDEMEROL 500 ML PIZER^FS^CI27\r\n^FO25,19^GFA,225,384,8,:Z64:eJxjYCAR/P///weQYgTSf4A0M5D+B6IbGBj4kGhGJP46EP8AAytIPeMDJrB+hgfy/wtA9O//PypAdP3/D2C+/YIfFhCbKqA0jF8jA6H/yEH5PBDagg9CG/Ch8uXYQWRHB387iD57hh1MvzzHfBjoJoaTZxgPQ/gMjxvA8owHD4D5jDB5KJ+58QBYHkID+c1Q+f8NYPMZwDQQxJAQjDAAAPgARzk=:CABD\r\n^BY1,3,64^FT276,198^BCN,,Y,N\r\n^FH\\^FD>;123456789012^FS\r\n^FT276,125^A0N,23,23^FH\\^CI28^FDLOTE :^FS^CI27\r\n^FT238,261^A0N,23,30^FH\\^CI28^FDVENCIMIENTO:^FS^CI27\r\n^FO13,14^GB408,64,8^FS\r\n^FT243,285^A0N,23,30^FH\\^CI28^FD15-08-2025^FS^CI27\r\n^FO225,234^GB210,62,8^FS\r\n^PQ1,,,Y\r\n^XZ";
        public string zplData3 = "\u0010CT~~CD,~CC^~CT~\r\n^XA\r\n~TA000\r\n~JSN\r\n^LT0\r\n^MNW\r\n^MTD\r\n^PON\r\n^PMN\r\n^LH0,0\r\n^JMA\r\n^PR6,6\r\n~SD15\r\n^JUS\r\n^LRN\r\n^CI27\r\n^PA0,1,1,0\r\n^XZ\r\n^XA\r\n^MMT\r\n^PW440\r\n^LL320\r\n^LS0\r\n^BY4,3,81^FT16,256^BCN,,Y,N\r\n^FH\\^FD>;123456789012^FS\r\n^FO8,152^GB411,0,8^FS\r\n^FT12,39^A0N,28,28^FH\\^CI28^FDOC: 4581^FS^CI27\r\n^FT127,39^A0N,28,28^FH\\^CI28^FDROLLOS: 40^FS^CI27\r\n^FT12,71^A0N,28,28^FH\\^CI28^FDFECHA: 14-06-25^FS^CI27\r\n^FT10,102^A0N,28,28^FH\\^CI28^FDPRODUCT ID: 065020^FS^CI27\r\n^FT10,121^A0N,17,30^FH\\^CI28^FDPRODUCT: RI LABEL 3D YELLOW^FS^CI27\r\n^FT337,93^BXN,5,200,0,0,1,_,1\r\n^FH\\^FD123456789012^FS\r\n^PQ1,,,Y\r\n^XZ";

        public FrmCodeBarLabel()
        {
            InitializeComponent();
        }

        private void FrmCodeBarLabel_Load(object sender, EventArgs e)
        {

        }

        private void Btn_buscar_printer_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Clear();
                foreach (DiscoveredPrinterDriver printer in UsbDiscoverer.GetZebraDriverPrinters())
                {
                    textBox1.Text += $"{printer.PrinterName}";
                }
                foreach (DiscoveredUsbPrinter usbPrinter in UsbDiscoverer.GetZebraUsbPrinters(new ZebraPrinterFilter()))
                {
                    textBox2.Text += usbPrinter.ToString();
                }
            }
            catch (ConnectionException ex)
            {
                MessageBox.Show($"Errror discovering local printers: {ex.Message}");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (rad_label1.Checked)
            {
                SendZplOverUsb(textBox1.Text, zplData1);
            }
            if (rad_label2.Checked)
            {
                SendZplOverUsb(textBox1.Text, zplData2);
            }
            if (rad_label3.Checked)
            {
                SendZplOverUsb(textBox1.Text, zplData3);
            }
        }

        [GeneratedRegex(@"\^PQ\d+")]
        private static partial Regex PqRegex();

        private void SendZplOverUsb(string usbDriverName, string zplData)
        {
            Connection thePrinterConn = null!;
            try
            {
                thePrinterConn = ConnectionBuilder.Build($"USB:{usbDriverName}");
                thePrinterConn.Open();

                string zplFinal;

                if (zplData.Contains("^PQ"))
                {
                    zplFinal = PqRegex().Replace(zplData, "^PQ" + numero_copias.Value);
                }
                else
                {
                    int idx = zplData.IndexOf("^XZ", StringComparison.OrdinalIgnoreCase);
                    if (idx >= 0)
                        zplFinal = zplData.Insert(idx, "^PQ" + numero_copias.Value);
                    else
                        zplFinal = zplData + "^PQ" + numero_copias.Value;
                }

                thePrinterConn.Write(Encoding.UTF8.GetBytes(zplFinal));
            }
            catch (ConnectionException ex)
            {
                MessageBox.Show($"Error connecting to printer: {ex.Message}");
            }
            finally
            {
                thePrinterConn?.Close();
            }
        }



        #region TscPrinters
        private static void MainSettingsTscPrinters()
        {
            IComm   ptrComm;
            ptrComm = new UniPRT.Sdk.Comm.TcpConnection("192.168.1.50", UniPRT.Sdk.Comm.TcpConnection.DEFAULT_MGMT_PORT);
            ptrComm.Open();
            Console.WriteLine(Environment.NewLine + "Reading some settings..." + Environment.NewLine);
            ReadSomeSettingsTscPrinters(ptrComm);
        }

        private static void ReadSomeSettingsTscPrinters(IComm ptrComm)
        {
            try
            {
                if (null != ptrComm)
                {
                    if (!ptrComm.Connected)
                    {
                        MessageBox.Show("Error: no connection");
                        return;
                    }
                    SettingsReadWrite mysetting = new(ptrComm);
                    // Read individual settings if needed
                    Console.WriteLine($"LCD Units: '{mysetting.GetValue("LCD.LabelUnits")}'");
                    Console.WriteLine($"Printer Resolution : '{mysetting.GetValue("Printer.Head.DPI-d")}'");
                    Console.WriteLine($"LCD Language: '{mysetting.GetValue("LCD.Languaje")}'");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err}");
                throw;
            }
        }

        #endregion

        #region CodigoCommon
        private async void PreviewLabel(string zpl)
        {
            if (string.IsNullOrWhiteSpace(zpl))
            {
                MessageBox.Show("Ingrese contenido ZPL para previsualizar.");
                return;
            }


            try
            {
                Image? etiqueta = await Task.Run(() => ObtenerImagenZplDesdeLabelary(zpl));

                if (etiqueta != null)
                {
                    previewLabels.Image = etiqueta;
                }
                else
                {
                    MessageBox.Show("Error al obtener la vista previa: ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar vista previa:" + ex.Message);

            }
        }

        private static async Task<Image?> ObtenerImagenZplDesdeLabelary(string zpl)
        {
            if (string.IsNullOrWhiteSpace(zpl))
            {
                MessageBox.Show("El ZPL está vacío.");
                return null;
            }

            using var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, "http://api.labelary.com/v1/printers/8dpmm/labels/4x6/0/")
            {
                Content = new StringContent(zpl, Encoding.UTF8, "text/plain")
            };

            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("image/png"));

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();
                return Image.FromStream(stream);
            }
            else
            {
                string detalle = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Error {response.StatusCode}: {detalle}", "Labelary");
                return null;
            }
        }
        #endregion


        private async void Btn_PreviewLabels_Click(object sender, EventArgs e)
        {
            string zplfile = "^XA^FO50,50^ADN,36,20^FDHola Mundo!^FS^XZ";

            var task = Task.Run(() => ObtenerImagenZplDesdeLabelary(zplfile));

            var img = await task;



            if (img != null)
            {
                previewLabels.Image = img;
            }
        }
    }
}

