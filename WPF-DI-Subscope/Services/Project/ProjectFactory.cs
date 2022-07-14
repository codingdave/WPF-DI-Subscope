using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.Serialization;
using WPF_DI_Subscope.Services.Resource;
using WPF_DI_Subscope.Services.SubProject;

namespace WPF_DI_Subscope.Services
{
    internal class ProjectFactory : IProjectFactory
    {
        private readonly IProjectServiceProvider _projectServiceProvider;
        private IServiceProvider _subprojectServiceProvider;
        private IServiceProvider _resourceServiceProvider;


        private IServiceScope _projectScope;

        public ProjectFactory(IProjectServiceProvider projectServiceProvider)
        {
            _projectServiceProvider = projectServiceProvider;
            _subprojectServiceProvider = _projectServiceProvider.GetRequiredService<ISubprojectServiceProvider>();
            _resourceServiceProvider = _projectServiceProvider.GetRequiredService<IResourceServiceProvider>();
            CreateNewProject();
            CreateNewSubproject();
            CreateNewResource();
        }

        public void CreateNewProject()
        {
            _projectScope = _projectServiceProvider.CreateScope();
            CreateNewSubproject();
            CreateNewResource();
        }

        public void CreateNewSubproject()
        {
            _subprojectServiceProvider = _subprojectServiceProvider.CreateScope().ServiceProvider;
            CreateNewResource();
        }

        public void CreateNewResource()
        {
            _resourceServiceProvider = _resourceServiceProvider.CreateScope().ServiceProvider;
        }

        public (IProject, ISubproject, IResource) GetProjectProvider()
        {
            return (
                _projectScope.ServiceProvider.GetRequiredService<IProject>(),
                _subprojectServiceProvider.GetRequiredService<ISubproject>(),
                _resourceServiceProvider.GetRequiredService<IResource>()
                );
        }
    }

}