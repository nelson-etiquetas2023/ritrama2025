using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ritrama2025.Forms;
using Ritrama2025.Helpers;
using Ritrama2025.Services.CommonData;
using Ritrama2025.Services.CommonService;
using Ritrama2025.Services.DespachoService.DespachoService;
using Ritrama2025.Services.ExportData;
using Ritrama2025.Services.InventarioService;
using Ritrama2025.Services.MateriaPrima;
using Ritrama2025.Services.ProduccionService;
using Ritrama2025.Services.ProductsService;
using Ritrama2025.Services.ReportsService.ReportsService;
using Ritrama2025.Services.ServiceLocator;

namespace Ritrama2025
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            //Configuracion de la injeccion dE dependencias.

            var builder = new HostBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((context, service) =>
                {
                    IConfiguration configuration = context.Configuration;
                    service.AddSingleton<IConfiguration>(configuration);

                    //Configuracion de servicios Standard de la App.
                    service.AddTransient<IServiceCommonData, ServiceDataCommon>();
                    service.AddTransient<IServiceMateriaPrima, ServiceMateriaPrima>();
                    service.AddTransient<IProduccionService, ProduccionService>();
                    service.AddTransient<IDespachoService, DespachoService>();
                    service.AddTransient<IReportsService, ReportsService>();
                    service.AddTransient<ICommonService, CommonService>();
                    service.AddTransient<IExportDataService, ExportDataService>();
                    service.AddTransient<IProductsService, ProductsService>();
                    service.AddTransient<IInventarioService, InventarioService>();

                    service.AddTransient<FormManager>();
                    //injecccion de dependencias de los formularios.
                    service.AddTransient<Main>();
                    service.AddTransient<FrmMateriaPrima>();
                    service.AddTransient<FrmDespacho>();
                    service.AddTransient<FrmCodeBarLabel>();
                    service.AddTransient<FrmOrdenCorte>();
                    service.AddTransient<FrmProductos>();
                    service.AddTransient<Frm_Inventarios>();
                });


            using var host = builder.Build();

            ServiceLocator.Init(host.Services);

            using var scope = host.Services.CreateScope();
            var main = scope.ServiceProvider.GetRequiredService<Main>();

            Application.Run(main);
        }
    }
}