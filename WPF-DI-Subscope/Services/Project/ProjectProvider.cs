using Microsoft.Extensions.DependencyInjection;

namespace WPF_DI_Subscope.Services
{
    public class ProjectProvider : IProjectProvider
    {
        private IProjectServiceProvider _projectServiceProvider;
        private IServiceScope _scope;

        public IProjectScope ProjectScope => _scope.ServiceProvider.GetRequiredService<IProjectScope>();

        public ProjectProvider(IProjectServiceProvider projectServiceProvider)
        {
            _projectServiceProvider = projectServiceProvider;
            _scope = _projectServiceProvider.CreateScope();
        }

        public void CreateScope()
        {
            Dispose();
            _scope = _projectServiceProvider.CreateScope();
        }

        public void Dispose()
        {
            _scope?.Dispose();
        }
    }
}