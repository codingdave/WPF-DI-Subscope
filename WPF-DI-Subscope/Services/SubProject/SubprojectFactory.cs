using Microsoft.Extensions.DependencyInjection;

namespace WPF_DI_Subscope.Services.SubProject
{
    internal class SubprojectFactory : ISubprojectFactory
    {
        readonly ISubprojectServiceProvider _serviceProvider;

        public SubprojectFactory(ISubprojectServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ISubproject CreateNewSubproject()
        {
            using var scope = _serviceProvider.CreateScope();
            return scope.ServiceProvider.GetRequiredService<ISubproject>();
        }
    }
}