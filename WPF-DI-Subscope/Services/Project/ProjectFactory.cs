using Microsoft.Extensions.DependencyInjection;
using System;

namespace WPF_DI_Subscope.Services
{
    internal class ProjectFactory : IProjectFactory
    {
        readonly IProjectServiceProvider _serviceProvider;

        public ProjectFactory(IProjectServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IProject CreateNewProject()
        {
            using var scope = _serviceProvider.CreateScope();
            return scope.ServiceProvider.GetRequiredService<IProject>();
        }
    }
}