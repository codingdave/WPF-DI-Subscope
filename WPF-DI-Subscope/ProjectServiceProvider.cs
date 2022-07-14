using Microsoft.Extensions.DependencyInjection;
using System;

namespace WPF_DI_Subscope
{
    internal class ProjectServiceProvider : IProjectServiceProvider
    {
        IServiceProvider _serviceProvider;

        public ProjectServiceProvider()
        {
            _serviceProvider = new ServiceCollection()
                .AddScoped<IProject, Project>()
                .BuildServiceProvider();
        }

        public object? GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }
    }
}