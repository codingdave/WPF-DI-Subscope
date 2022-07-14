using Microsoft.Extensions.DependencyInjection;
using System;
using WPF_DI_Subscope.Services.Resource;
using WPF_DI_Subscope.Services.SubProject;

namespace WPF_DI_Subscope.Services
{
    internal class ProjectServiceProvider : IProjectServiceProvider
    {
        readonly IServiceProvider _serviceProvider;

        public ProjectServiceProvider(IInstanceCounter instanceCounter)
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton(serviceProvider => instanceCounter)

                .AddScoped<IResourceServiceProvider, ResourceServiceProvider>()
                .AddScoped<ISubprojectServiceProvider, SubprojectServiceProvider>()

                .AddScoped<IProject, Project>()

                .BuildServiceProvider();
        }

        public object? GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }
    }
}