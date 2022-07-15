using Microsoft.Extensions.DependencyInjection;
using System;

namespace WPF_DI_Subscope.Services
{
    public class ResourceServiceProvider : IResourceServiceProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public ResourceServiceProvider()
        {
            _serviceProvider = new ServiceCollection()
                .AddTransient<IInstanceCounter, InstanceCounter>()

                .AddScoped<IResourceScope, ResourceScope>()

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