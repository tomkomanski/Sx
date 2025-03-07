using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Sx.ApplicationServices;
using Sx.ConfigurationServices;
using Sx.ConnectorServices;
using Sx.DataServices;

namespace Sx.Host
{
    public partial class App : Application
    {
        private readonly IServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection serviceCollection = new();
            ConfigureServices(serviceCollection);
            this.serviceProvider = serviceCollection.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow mainWindow = this.serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IApplicationSx, ApplicationSx>();
            services.AddSingleton<IConnectorApiClient, ConnectorApiClient>();
            services.AddSingleton<IConfigurationSx, ConfigurationSx>();
            services.AddSingleton<IDataNbp, DataNbp>();
            services.AddSingleton<MainWindow>();
        }
    }
}