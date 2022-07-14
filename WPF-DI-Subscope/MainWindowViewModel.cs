using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Runtime.Serialization;
using System.Windows.Input;
using WPF_DI_Subscope.Services;

namespace WPF_DI_Subscope
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private IProjectProvider _projectProvider;
        private ObjectIDGenerator _projctIdGenerator = new();
        private ObjectIDGenerator _subprojectIdGenerator = new();
        private ObjectIDGenerator _resourceIdGenerator = new();

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
        private string _resourceId = "None";

        [ObservableProperty]
        private string _subprojectId = "None";

        [ObservableProperty]
        private string _projectId = "None";

        public ICommand NewProjectCommand { get; }
        public ICommand NewResourceCommand { get; }
        public ICommand NewSubprojectCommand { get; }

        public ICommand IncrementProjectCommand { get; }
        public ICommand IncrementResourceCommand { get; }
        public ICommand IncrementSubprojectCommand { get; }

        public ICommand DisposeProjectCommand { get; }
        public ICommand DisposeResourceCommand { get; }
        public ICommand DisposeSubprojectCommand { get; }

        public MainWindowViewModel(IProjectProvider projectProvider)
        {
            _projectProvider = projectProvider;

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

            UpdateProperties();
        }

        void UpdateProperties()
        {
            // always assign in this order since the items depend on each other
            Resource = _projectProvider.Project.Subproject.Resource;
            Subproject = _projectProvider.Project.Subproject;
            Project = _projectProvider.Project;
        }

        public void NewProject()
        {
            _projectProvider.CreateScope();
            UpdateProperties();
        }

        public void NewSubproject()
        {
            _projectProvider.Project.CreateNewSubproject();
            UpdateProperties();
        }

        public void NewResource()
        {
            Subproject.CreateNewResource();
            UpdateProperties();
        }

        private void DisposeResource()
        {
            Resource.Dispose();
            OnPropertyChanged(nameof(Resource));
        }

        private void DisposeSubproject()
        {
            Subproject.Dispose();
            OnPropertyChanged(nameof(Subproject));
            OnPropertyChanged(nameof(Resource));
        }

        private void DisposeProject()
        {
            Project.Dispose();
            OnPropertyChanged(nameof(Project));
            OnPropertyChanged(nameof(Subproject));
            OnPropertyChanged(nameof(Resource));
        }

        private void IncrementResource()
        {
            Resource.Increment();
            OnPropertyChanged(nameof(Resource));
        }

        private void IncrementSubproject()
        {
            Subproject.Increment();
            OnPropertyChanged(nameof(Subproject));
            OnPropertyChanged(nameof(Resource));
        }

        private void IncrementProject()
        {
            Project.Increment();
            OnPropertyChanged(nameof(Project));
            OnPropertyChanged(nameof(Subproject));
            OnPropertyChanged(nameof(Resource));
        }

        private void MainWindowViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Project):
                ProjectId = _projctIdGenerator.GetId(Project, out _).ToString();
                break;
                case nameof(Subproject):
                SubprojectId = _subprojectIdGenerator.GetId(Subproject, out _).ToString();
                break;
                case nameof(Resource):
                ResourceId = _resourceIdGenerator.GetId(Resource, out _).ToString();
                break;
            }
        }
    }
}