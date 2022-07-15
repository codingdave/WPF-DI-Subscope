using Microsoft.Extensions.DependencyInjection;
using System;

namespace WPF_DI_Subscope.Services
{
    public class ProjectServiceProvider : IProjectServiceProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public ProjectServiceProvider()
        {
            _serviceProvider = new ServiceCollection()
                .AddTransient<IInstanceCounter, InstanceCounter>()

                .AddScoped<IProjectScope, ProjectScope>()

                .AddScoped<ISubprojectServiceProvider, SubprojectServiceProvider>()
                .AddScoped<ISubprojectProvider, SubprojectProvider>()

                .BuildServiceProvider();
        }

        public void Dispose()
        {
        }

        public object? GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }
    }
}