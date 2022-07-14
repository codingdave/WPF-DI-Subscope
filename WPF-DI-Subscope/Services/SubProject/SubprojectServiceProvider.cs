﻿using Microsoft.Extensions.DependencyInjection;
using System;

namespace WPF_DI_Subscope.Services.SubProject
{
    internal class SubprojectServiceProvider : ISubprojectServiceProvider
    {
        readonly IServiceProvider _serviceProvider;

        public SubprojectServiceProvider(IInstanceCounter instanceCounter)
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton(instanceCounter)

                .AddScoped<ISubproject, Subproject>()
                .BuildServiceProvider();
        }

        public object? GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }
    }
}