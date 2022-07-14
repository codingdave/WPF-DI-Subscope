using Microsoft.Extensions.DependencyInjection;
using System;

namespace WPF_DI_Subscope.Services
{
    public class SubprojectProvider : ISubprojectProvider
    {
        private IServiceProvider _subprojectServiceProvider;
        private IServiceScope _scope;

        public ISubproject Subproject => _scope.ServiceProvider.GetRequiredService<ISubproject>();

        public SubprojectProvider(ISubprojectServiceProvider subprojectServiceProvider)
        {
            _subprojectServiceProvider = subprojectServiceProvider;
            CreateScope();
        }

        public void CreateScope()
        {
            Dispose();
            _scope = _subprojectServiceProvider.CreateScope();
        }

        public void Dispose()
        {
            _scope?.Dispose();
        }
    }
}