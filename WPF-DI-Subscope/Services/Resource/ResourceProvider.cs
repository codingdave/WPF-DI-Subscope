using Microsoft.Extensions.DependencyInjection;
using System;

namespace WPF_DI_Subscope.Services
{
    public class ResourceProvider : IResourceProvider
    {
        private IServiceProvider _resourceServiceProvider;
        private IServiceScope _scope;

        public IResourceScope Resource => _scope.ServiceProvider.GetRequiredService<IResourceScope>();

        public ResourceProvider(IResourceServiceProvider resourceServiceProvider)
        {
            _resourceServiceProvider = resourceServiceProvider;
            _scope = _resourceServiceProvider.CreateScope();
        }

        public void CreateScope()
        {
            Dispose();
            _scope = _resourceServiceProvider.CreateScope();
        }

        public void Dispose()
        {
            _scope?.Dispose();
        }
    }
}