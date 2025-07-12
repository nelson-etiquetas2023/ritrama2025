using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Reporting.WinForms;
using Ritrama2025.Forms.Otros;
using System.Data;
using System.Drawing.Printing;

namespace Ritrama2025.Services.ReportsService.ReportsService
{
    public class ReportsService : IReportsService
    {
        public IConfiguration Config { get; }
        public string StringConnex { get; set; } = "";
        public string MessageError { get; set; } = "";

        public ReportsService(IConfiguration Config)
        {
            this.Config = Config;
            if (Config != null)
            {
                var ambiente = Config["Ambiente"] ?? R.ENVIRONMET.DESARROLLO;
                StringConnex = Config.GetSection(R.ENVIRONMET.NAME_KEY_CONNECTION)[ambiente]!;
            }
        }

        public void Reporte_Orden_MatPrima(string Orden,Form Form,string ReportName,string TitleReport) 
        {
            DataTable dt = new();
            try
            {
                using (SqlConnection conn = new(StringConnex))
                {
                    SqlCommand comando = new()
                    {
                        Connection = conn,
                        CommandType = CommandType.Text,
                        CommandText = "select a.numero,fecha_recepcion,fecha_pro,orden_compra,persona_respons,guia_import,doc_embarque,closeDocument," +
                        "lote,c.proveedor_name,d.transport_name,total_cantidad,b.product_id,e.product_name,b.width,b.length,b.msi,b.rollid,b.splice,b.ubicacion,b.type,b.core,B.cant_pedido,b.cant_real,a.notas from OrdenMateria a left join itemsMateria b on a.numero=b.numero " +
                            "left join provider c on a.proveedor_id = c.proveedor_id LEFT JOIN transporte d ON a.transport_id = d.transport_id LEFT JOIN producto e ON b.product_id = e.product_id where a.numero=@p1"
                    };
                    conn.Open();
                    comando.Parameters.Add(new SqlParameter("@p1", SqlDbType.NVarChar) { Value = Orden });
                    comando.ExecuteNonQuery();

                    SqlDataAdapter da = new(comando);
                    da.Fill(dt);
                }
                try
                {
                    ReportsViewer report = new()
                    {
                        Text = TitleReport,
                        Width = 1130,
                        Height = 780,
                        MdiParent = Form.MdiParent,
                        StartPosition = FormStartPosition.CenterScreen

                    };
                    report.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    report.reportViewer1.LocalReport.ReportPath = GetPathApplication(ReportName, R.PATH_REPORTS.REPORTS_DESPACHO);
                    //configuracion de la pagina.
                    //PageSettings pageSettings = new()
                    //{
                    //    PaperSize = new PaperSize("Letter", 1100, 850), //A4-carta.
                    //    Landscape = true,
                    //    Margins = new Margins(0, 0, 0, 0),
                    //};
                    //report.reportViewer1.SetPageSettings(pageSettings);
                    //parametros del reporte.
                    ReportParameter param = new ReportParameter("Orden_MatPrima", Orden);

                    //Configura el origen de los datos.

                    ReportDataSource rds = new("DsImportacion", dt);
                    report.reportViewer1.LocalReport.DataSources.Clear();
                    report.reportViewer1.LocalReport.DataSources.Add(rds);


                    report.reportViewer1.LocalReport.SetParameters(param);
                    report.reportViewer1.RefreshReport();
                    report.Show();
                }
                catch (ReportViewerException ex)
                {
                    MessageBox.Show("Error al cargar el reporte de orden recepcion materia prima. codigo error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte de la orden de corte...codigo error: " + ex.Message);
            }
        }

        public void Reporte_Orden_Corte(string numeroOC,Form form,string ReportName,string TitleReport) 
        {
            DataTable dt = new();
            try
            {
                //Catga de los datos
                
                using (SqlConnection conn = new(StringConnex))
                {
                    SqlCommand comando = new()
                    {
                        Connection = conn,
                        CommandType = CommandType.Text,
                        CommandText = "select a.numero,a.fecha,a.fecha_produccion,a.product_id,c.product_name,b.unique_code,b.roll_number,b.splice,b.width,b.large,b.msi,b.roll_id,b.code_person,b.status,d.nombre as operador,e.customer_name from orden_corte a " + 
                        "left join rolls_details b on a.numero = b.numero " +
                        "left join producto c on a.product_id = c.product_id left join operadores d on a.operador_id = d.operador_id left join customer e on a.customer_id = e.customer_id where a.numero=@numero_oc"
                    };
                    conn.Open();
                    comando.Parameters.Add(new SqlParameter("@numero_oc", SqlDbType.NVarChar) { Value = numeroOC });
                    comando.ExecuteNonQuery();
                 
                    SqlDataAdapter da = new(comando);
                    da.Fill(dt);
                }
                //Creacion del reporte.
                try
                {
                    ReportsViewer report = new()
                    {
                        Text = TitleReport,
                        Width = 1130,
                        Height = 780,
                        MdiParent = form.MdiParent,
                        StartPosition = FormStartPosition.CenterScreen
                        
                    };
                    report.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    report.reportViewer1.LocalReport.ReportPath = GetPathApplication(ReportName,R.PATH_REPORTS.REPORTS_DESPACHO);
                    //configuracion de la pagina.
                    //PageSettings pageSettings = new()
                    //{
                    //    PaperSize = new PaperSize("Letter", 1100, 850), //A4-carta.
                    //    Landscape = true,
                    //    Margins = new Margins(0,0,0,0),
                    //};
                    //report.reportViewer1.SetPageSettings(pageSettings);
                    //parametros del reporte.
                    ReportParameter param = new ReportParameter("numero_oc", numeroOC);
                    
                    //Configura el origen de los datos.

                    ReportDataSource rds = new("DsOrdenCorte", dt);
                    report.reportViewer1.LocalReport.DataSources.Clear();
                    report.reportViewer1.LocalReport.DataSources.Add(rds);


                    report.reportViewer1.LocalReport.SetParameters(param);
                    report.reportViewer1.RefreshReport();
                    report.Show();
                }
                catch (ReportViewerException ex)
                {
                    MessageBox.Show("Error al cargar el reporte. codigo error: " + ex.Message);   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte de la orden de corte...codigo error: " + ex.Message);
            }
        }
        public void ReporteConduce_conPrecio(string conduce, Form form,string ReportName,string TitleReport)
        {
            DataSet ds = new();
            using (SqlConnection conn = new(StringConnex))
            {
                SqlCommand comando = new()
                {
                    Connection = conn,
                    CommandText = "select a.numero,a.fecha,a.customer_id,b.Customer_Name,a.person_contact,a.vendor_id,c.vendor_name,a.packing," +
                      "a.orden_trabajo,a.orden_compra,a.subtotal,a.porc_itbis,a.itbis,a.total$rd as " + "TotalMontoDoc,a.transport_id,a.transporte,a.chofer_id,a.chofer,a.placas_id,a.camion,a.tipo_venta," + "a.reserva,a.impuesto,a.status,a.total_cantidad,a.total_msi,a.total_pie,a.total_kilos,a.total_kilos_netos_palet,a.total_kilos_brutos_palet,d.product_id,e.Product_Name,e.Product_Descrip,e.ratio,e.precio," + "d.cant,d.unid_id,f.UNID_NAME,d.width,d.lenght,d.msi,d.total_pie_lin,d.ratio,d.kilo_rollo,d.kilo_total," +
                      "d.precio,d.total_renglon,d.code_person,d.m2 from despacho a left join Customer b on " + "a.customer_id=b.Customer_ID left join vendedor c on a.vendor_id=c.vendor_id left join item_despacho d on a.numero = d.numero left join producto e on d.product_id = e.Product_ID left join unidad f on f.UNID_ID = d.unid_id where a.numero=@p1",
                    CommandType = CommandType.Text
                };
                SqlParameter p1 = new("@p1", SqlDbType.VarChar)
                {
                    Value = conduce
                };
                comando.Parameters.Add(p1);
                conn.Open();
                SqlDataAdapter da = new(comando);
                da.Fill(ds, "dt");
                //Creacion del reporte

            }
            ReportsViewer reports = new()
            {
                Text = TitleReport,
                Width = 1130,
                Height = 780,
                MdiParent = form.MdiParent,
            };
            reports.reportViewer1.ProcessingMode = ProcessingMode.Local;
            reports.reportViewer1.LocalReport.ReportPath = GetPathApplication(ReportName,R.PATH_REPORTS.REPORTS_DESPACHO);
            //creo un objeto del tipo PageSettings para configurar la pagina a imprimir.
            PageSettings pageSettings = new()
            {
                PaperSize = new PaperSize("Letter", 1100, 850), // A4 size in hundredths of millimeters
                Landscape = true,
                Margins = new Margins(0, 0, 0, 0)
            };
            reports.reportViewer1.SetPageSettings(pageSettings);
            //trabajo con los parametros del reporte.
            ReportParameter[] param = [new ReportParameter("numero_conduce", conduce)];
            reports.reportViewer1.LocalReport.DataSources.Clear();
            reports.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ds.Tables["dt"]));
            reports.reportViewer1.LocalReport.SetParameters(param);
            reports.reportViewer1.RefreshReport();
            reports.Show();
        }
        public void ReporteCondece_sinPrecio(string conduce, Form form, string ReportName, string TitleReport)
        {
            ReporteConduce_conPrecio(conduce, form, ReportName, TitleReport);
        }
        public void Reporte_PackingList(string conduce, Form form)
        {
            DataSet ds = new();
            using SqlConnection conn = new(StringConnex);
            //Conexion a la base de datos.
            SqlCommand comando = new()
            {
                Connection = conn,
                CommandText = "SELECT a.conduce,a.product_id,b.product_name,a.unique_code,a.roll_number,a.width,a.lenght,a.msi,a.splice,a.roll_id,a.cant_despacho,a.tipo,no_paleta,c.fecha,c.customer_id,d.customer_name FROM rcdespacho a LEFT JOIN producto b ON a.product_id = b.product_id LEFT JOIN despacho c ON a.conduce=c.numero LEFT JOIN customer d ON c.customer_id=d.customer_id WHERE conduce=@p1",
                CommandType = CommandType.Text
            };
            SqlParameter p1 = new("@p1", SqlDbType.VarChar)
            {
                Value = conduce
            };
            comando.Parameters.Add(p1);
            conn.Open();
            SqlDataAdapter da = new(comando);
            da.Fill(ds, "dt");
            //creacion del reporte.
            ReportsViewer reports = new()
            {
                Text = "REPORTE DE PACKING-LIST.",
                Width = 1130,
                Height = 780,
                MdiParent = form.MdiParent,
            };
            string ReportName = "Picking-List.rdlc";
            reports.reportViewer1.ProcessingMode = ProcessingMode.Local;
            reports.reportViewer1.LocalReport.ReportPath = GetPathApplication(ReportName, R.PATH_REPORTS.REPORTS_DESPACHO);
            //creo un objeto del tipo PageSettings para configurar la pagina a imprimir.
            PageSettings pageSettings = new()
            {
                PaperSize = new PaperSize("Letter", 1100, 850), // A4 size in hundredths of millimeters
                Landscape = true,
                Margins = new Margins(0, 0, 0, 0)
            };
            reports.reportViewer1.SetPageSettings(pageSettings);
            //trabajo con los parametros del reporte.
            ReportParameter[] param = [new ReportParameter("numero_conduce", conduce)];
            reports.reportViewer1.LocalReport.DataSources.Clear();
            reports.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsRollos", ds.Tables["dt"]));
            reports.reportViewer1.LocalReport.SetParameters(param);
            reports.reportViewer1.RefreshReport();
            reports.Show();
        }
        public void Reporte_DetallePaleta(string conduce,Form form)
        {
            // Conexion a la base de datos.
            DataSet ds = new();
            using SqlConnection conn = new(StringConnex);
            SqlCommand comando = new()
            {
                Connection = conn,
                CommandText = "SELECT a.numero,a.number_palet,a.medida,a.contenido,a.kilo_neto,a.kilo_bruto,"+          "b.customer_id,c.Customer_Name,b.fecha FROM Paleta AS a LEFT OUTER JOIN despacho AS b " +
                  "ON a.numero = b.numero LEFT OUTER JOIN Customer AS c ON b.customer_id = c.Customer_ID " +
                  "WHERE(a.numero = @p1)",
                CommandType = CommandType.Text
            };
            SqlParameter p1 = new("@p1", SqlDbType.VarChar)
            {
                Value = conduce
            };
            comando.Parameters.Add(p1);
            conn.Open();
            SqlDataAdapter da = new(comando);
            da.Fill(ds, "dt");
            ReportsViewer reports = new()
            {
                Text = "REPORTE DETALLE DE PALETA",
                Width = 1130,
                Height = 780,
                MdiParent = form.MdiParent,
            };
            string ReportName = "RptDetalle-Paleta.rdlc";
            reports.reportViewer1.ProcessingMode = ProcessingMode.Local;
            reports.reportViewer1.LocalReport.ReportPath = GetPathApplication(ReportName, R.PATH_REPORTS.REPORTS_DESPACHO);
            //creo un objeto del tipo PageSettings para configurar la pagina a imprimir.
            PageSettings pageSettings = new()
            {
                PaperSize = new PaperSize("Letter", 1100, 850), // A4 size in hundredths of millimeters
                Landscape = true,
                Margins = new Margins(0, 0, 0, 0)
            };
            reports.reportViewer1.SetPageSettings(pageSettings);
            //trabajo con los parametros del reporte.
            ReportParameter[] param = [new ReportParameter("numero_conduce", conduce)];
            reports.reportViewer1.LocalReport.DataSources.Clear();
            reports.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsPaleta", ds.Tables["dt"]));
            reports.reportViewer1.LocalReport.SetParameters(param);
            reports.reportViewer1.RefreshReport();
            reports.Show();
        }
        private static string GetPathApplication(string ReportName,string folderNameReport) 
        {
            string AppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string ReportsFolder = Path.Combine(AppDirectory, folderNameReport);
            if (!Directory.Exists(ReportsFolder)) 
            {
                Directory.CreateDirectory(ReportsFolder);
            }
            string ReportPath = Path.Combine(ReportsFolder, ReportName);
            return ReportPath;
        }
    }
}
