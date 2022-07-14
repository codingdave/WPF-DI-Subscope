using Microsoft.Extensions.DependencyInjection;
using System;

namespace WPF_DI_Subscope.Services.SubProject
{
    internal class SubprojectServiceProvider : ISubprojectServiceProvider
    {
        readonly IServiceProvider _serviceProvider;

        public SubprojectServiceProvider()
        {
            _serviceProvider = new ServiceCollection()
                .AddTransient<IInstanceCounter, InstanceCounter>()

                .AddScoped<ISubproject, Subproject>()
                .BuildServiceProvider();
        }

        public object? GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }
    }
}