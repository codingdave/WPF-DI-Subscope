using Microsoft.Extensions.DependencyInjection;
using System;
using WPF_DI_Subscope.Services.Resource;
using WPF_DI_Subscope.Services.SubProject;

namespace WPF_DI_Subscope.Services
{
    internal class ProjectServiceProvider : IProjectServiceProvider
    {
        readonly IServiceProvider _serviceProvider;

        public ProjectServiceProvider()
        {
            _serviceProvider = new ServiceCollection()
                .AddTransient<IInstanceCounter, InstanceCounter>()

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