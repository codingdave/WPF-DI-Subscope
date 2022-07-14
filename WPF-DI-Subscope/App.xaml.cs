using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using WPF_DI_Subscope.Services;

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
                    .AddSingleton<IProjectServiceProvider, ProjectServiceProvider>()
                    .AddSingleton<IProjectProvider, ProjectProvider>()

                    .AddSingleton<MainWindowViewModel>()
                    .AddSingleton<MainWindow>()
                ).Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _host.Start();
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        protected async override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            await _host.StopAsync();
        }
    }
}
