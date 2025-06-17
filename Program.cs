using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ritrama2025.Forms;
using Ritrama2025.Helpers;
using Ritrama2025.Services;
using Ritrama2025.Services.CommonData;
using Ritrama2025.Services.MateriaPrima;
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

            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) => {
                    config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((context, service) =>
                {
                    IConfiguration configuration = context.Configuration;
                    //Configuracion de servicios Standard de la App.
                    service.AddScoped<IServiceCommonData, ServiceDataCommon>();
                    service.AddScoped<IServiceMateriaPrima, ServiceMateriaPrima>();
                    service.AddScoped<IProduccionService, ProduccionService>();
                    service.AddScoped<IDespachoService, DespachoService>();
                    service.AddScoped<IReportsService, ReportsService>();
                    service.AddSingleton<FormManager>();
                    //injecccion de dependencias de los formularios.
                    service.AddSingleton<Main>();
                    service.AddTransient<FrmMateriaPrima>();
                    service.AddTransient<FrmDespacho>();
                    service.AddTransient<FrmCodeBarLabel>();
                    service.AddTransient<FrmOrdenCorte>();
                }).Build();

            ServiceLocator.Init(host.Services);
            Application.Run(ServiceLocator.Get<Main>());
        }
    }
}