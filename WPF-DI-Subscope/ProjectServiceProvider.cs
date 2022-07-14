using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace WPF_DI_Subscope
{
    internal class ProjectServiceProvider : IProjectServiceProvider
    {
        readonly IServiceProvider _serviceProvider;

        public ProjectServiceProvider(IInstanceCounter instanceCounter)
        {
            _serviceProvider = new ServiceCollection()
                .AddScoped<IProject, Project>()
                .AddScoped(serviceProvider => instanceCounter)
                .BuildServiceProvider();
        }

        public object? GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }
    }
}