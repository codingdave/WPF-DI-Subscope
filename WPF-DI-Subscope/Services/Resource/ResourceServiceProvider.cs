using Microsoft.Extensions.DependencyInjection;
using System;

namespace WPF_DI_Subscope.Services.Resource
{
    public class ResourceServiceProvider : IResourceServiceProvider
    {
        readonly IServiceProvider _serviceProvider;

        public ResourceServiceProvider(IInstanceCounter instanceCounter)
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton(instanceCounter)

                .AddScoped<IResource, Resource>()

                .BuildServiceProvider();
        }

        public object? GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }
    }

}