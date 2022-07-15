using Microsoft.Extensions.DependencyInjection;
using System;

namespace WPF_DI_Subscope.Services
{
    public class SubprojectServiceProvider : ISubprojectServiceProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public SubprojectServiceProvider()
        {
            _serviceProvider = new ServiceCollection()
                .AddTransient<IInstanceCounter, InstanceCounter>()

                .AddScoped<ISubproject, SubprojectScope>()

                .AddScoped<IResourceServiceProvider, ResourceServiceProvider>()
                .AddScoped<IResourceProvider, ResourceProvider>()

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