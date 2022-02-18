using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RainyManager.Misc;
using RainyManager.Services;
using RainyManager.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace RainyManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly IHost host;
        private const string configPath = "AppConfiguration.json";

        public App()
        {
            string appConfigData = null;

            if(File.Exists(configPath))
                appConfigData = File.ReadAllText(configPath);

            host = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {

                    services.AddSingleton<IAppSettingsManager>(provider =>
                    {
                        return new AppSettingsManager(appConfigData, configPath );
                    });

                    services.AddSingleton<IModDownloadService, ModDownloadService>();

                    services.AddSingleton<IControllerService, ControllerService>();

                    services.AddSingleton<IGeneralHelperService, GeneralHelperService>();

                    services.AddSingleton<INotificationService, NotificationService>();

                    services.AddSingleton<IThundersoreAPIService, ThundersoreAPIService>();

                    Assembly.GetEntryAssembly().GetTypesAssignableFrom<IBaseView, BaseView>().ForEach((t) =>
                    {
                        services.AddSingleton(typeof(IBaseView), t);
                    });

                    services.AddSingleton<MainWindow>();
                }).Build();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = host.Services.GetService<MainWindow>();
            IControllerService? controllerService = host.Services.GetService<IControllerService>();
            controllerService.InitializeViews(
                host.Services.GetServices<IBaseView>()
            );

            host.Services.GetService<IModDownloadService>().InitializeModService();

            mainWindow.Closed += (s, e) => {
                ShutItDown();
            };

            mainWindow.Show();
        }

        private void ShutItDown()
        {
            using (host)
            {
                host.StopAsync();
            }

            Current.Shutdown();
        }


    }
}
