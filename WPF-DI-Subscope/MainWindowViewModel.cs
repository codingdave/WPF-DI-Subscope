using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Runtime.Serialization;
using System.Windows.Input;
using WPF_DI_Subscope.Services.Resource;

namespace WPF_DI_Subscope
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private IProjectFactory _projectFactory;
        private ObjectIDGenerator _objectIdGenerator = new ObjectIDGenerator();

        [ObservableProperty]
        [AlsoNotifyChangeFor(nameof(Subproject))]
        [AlsoNotifyChangeFor(nameof(Resource))]
        private IProject _project;

        [ObservableProperty]
        [AlsoNotifyChangeFor(nameof(Resource))]
        private ISubproject _subproject;

        [ObservableProperty]
        private IResource _resource;

        [ObservableProperty]
        private string _resourceId;

        [ObservableProperty]
        private string _subprojectId;

        [ObservableProperty]
        private string _projectId;

        public MainWindowViewModel(IProjectFactory projectFactory)
        {
            _projectFactory = projectFactory;

            NewProject();

            _resourceId = _objectIdGenerator.GetId(new object(), out _).ToString();
            _subprojectId = _objectIdGenerator.GetId(new object(), out _).ToString();
            _projectId = _objectIdGenerator.GetId(new object(), out _).ToString();

            NewProjectCommand = new RelayCommand(NewProject);
            NewSubprojectCommand = new RelayCommand(NewSubproject);
            NewResourceCommand = new RelayCommand(NewResource);

            IncrementProjectCommand = new RelayCommand(IncrementProject);
            IncrementSubprojectCommand = new RelayCommand(IncrementSubproject);
            IncrementResourceCommand = new RelayCommand(IncrementResource);

            DisposeProjectCommand = new RelayCommand(DisposeProject);
            DisposeSubprojectCommand = new RelayCommand(DisposeSubproject);
            DisposeResourceCommand = new RelayCommand(DisposeResource);

            PropertyChanged += MainWindowViewModel_PropertyChanged;
        }

        public void NewProject()
        {
            _projectFactory.CreateNewProject();
            (Project, Subproject, Resource) = _projectFactory.GetProjectProvider();
        }

        public void NewSubproject()
        {
            _projectFactory.CreateNewSubproject();
            (Project, Subproject, Resource) = _projectFactory.GetProjectProvider();
        }

        public void NewResource()
        {
            _projectFactory.CreateNewResource();
            (Project, Subproject, Resource) = _projectFactory.GetProjectProvider();
        }

        private void DisposeResource()
        {
            Resource.Dispose();
            (Project, Subproject, Resource) = _projectFactory.GetProjectProvider();
        }

        private void DisposeSubproject()
        {
            Subproject.Dispose();
            (Project, Subproject, Resource) = _projectFactory.GetProjectProvider();
        }

        private void DisposeProject()
        {
            Project.Dispose();
            (Project, Subproject, Resource) = _projectFactory.GetProjectProvider();
        }

        private void IncrementResource()
        {
            _projectFactory.IncrementResourceCounter();
            (Project, Subproject, Resource) = _projectFactory.GetProjectProvider();
        }

        private void IncrementSubproject()
        {
            _projectFactory.IncrementSubprojectCounter();
            (Project, Subproject, Resource) = _projectFactory.GetProjectProvider();
        }

        private void IncrementProject()
        {
            _projectFactory.IncrementProjectCounter(); 
            (Project, Subproject, Resource) = _projectFactory.GetProjectProvider();
        }

        private void MainWindowViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Project):
                ProjectId = _objectIdGenerator.GetId(Project, out _).ToString();
                break;
                case nameof(Subproject):
                SubprojectId = _objectIdGenerator.GetId(Subproject, out _).ToString();
                break;
                case nameof(Resource):
                ResourceId = _objectIdGenerator.GetId(Resource, out _).ToString();
                break;
            }
        }

        public ICommand NewProjectCommand { get; }
        public ICommand NewResourceCommand { get; }
        public ICommand NewSubprojectCommand { get; }

        public ICommand IncrementProjectCommand { get; }
        public ICommand IncrementResourceCommand { get; }
        public ICommand IncrementSubprojectCommand { get; }

        public ICommand DisposeProjectCommand { get; }
        public ICommand DisposeResourceCommand { get; }
        public ICommand DisposeSubprojectCommand { get; }      
    }
}