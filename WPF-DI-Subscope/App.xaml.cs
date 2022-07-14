using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_DI_Subscope
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().
                ConfigureServices(services =>
                services
                .AddSingleton<IInstanceCounter, InstanceCounter>()

                .AddSingleton<IProjectServiceProvider, ProjectServiceProvider>()
                .AddSingleton<IProjectFactory, ProjectFactory>()

                .AddSingleton<MainWindowViewModel>()
                .AddSingleton<MainWindow>(services =>
                {
                    return new MainWindow()
                    {
                        DataContext = services.GetRequiredService<MainWindowViewModel>()
                    };
                })
                ).Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _host.Start();
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            _host.StopAsync();
        }
    }
}
