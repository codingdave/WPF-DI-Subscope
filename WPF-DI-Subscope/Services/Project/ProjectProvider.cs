using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.Serialization;
using WPF_DI_Subscope.Services.Resource;
using WPF_DI_Subscope.Services.SubProject;

namespace WPF_DI_Subscope.Services
{
    internal class ProjectProvider : IProjectProvider
    {
        private IServiceProvider _projectServiceProvider;
        private IServiceProvider _subprojectServiceProvider;
        private IServiceProvider _resourceServiceProvider;

        public ProjectProvider(IProjectServiceProvider projectServiceProvider)
        {
            _projectServiceProvider = projectServiceProvider;
            _subprojectServiceProvider = _projectServiceProvider.GetRequiredService<ISubprojectServiceProvider>();
            _resourceServiceProvider = _projectServiceProvider.GetRequiredService<IResourceServiceProvider>();
        }

        public void CreateNewProject()
        {
            _projectServiceProvider = _projectServiceProvider.CreateScope().ServiceProvider;
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
            return (Project, Subproject, Resource);
        }

        IProject Project => _projectServiceProvider.GetRequiredService<IProject>();
        ISubproject Subproject => _subprojectServiceProvider.GetRequiredService<ISubproject>();
        IResource Resource => _resourceServiceProvider.GetRequiredService<IResource>();

        public void IncrementSubprojectCounter()
        {
            Subproject.Increment();
        }

        public void IncrementResourceCounter()
        {
            Resource.Increment();
        }

        public void IncrementProjectCounter()
        {
            Project.Increment();
        }

        public void DisposeProject()
        {
            Project.Dispose();
            Subproject.Dispose();
            Resource.Dispose();
        }

        public void DisposeSubproject()
        {
            Subproject.Dispose();
            Resource.Dispose();
        }

        public void DisposeResource()
        {
            Resource.Dispose();
        }
    }
}