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
        private IProjectProvider _projectProvider;
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
        private string _resourceId = "None";

        [ObservableProperty]
        private string _subprojectId = "None";

        [ObservableProperty]
        private string _projectId = "None";

        public MainWindowViewModel(IProjectProvider projectFactory)
        {
            _projectProvider = projectFactory;

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

            NewProject();
        }

        public void NewProject()
        {
            _projectProvider.CreateNewProject();
            UpdateProperties();
        }

        void UpdateProperties()
        {
            var (project, subproject, resource) = _projectProvider.GetProjectProvider();
            // always assign in this order to keep the order of the ObjectId counter consistent
            Resource = resource;
            Subproject = subproject;
            Project = project;
        }

        public void NewSubproject()
        {
            _projectProvider.CreateNewSubproject();
            UpdateProperties();
        }

        public void NewResource()
        {
            _projectProvider.CreateNewResource();
            UpdateProperties();
        }

        private void DisposeResource()
        {
            _projectProvider.DisposeResource();
            OnPropertyChanged(nameof(Resource));
        }

        private void DisposeSubproject()
        {
            _projectProvider.DisposeSubproject();
            OnPropertyChanged(nameof(Subproject));
            OnPropertyChanged(nameof(Resource));
        }

        private void DisposeProject()
        {
            _projectProvider.DisposeProject();
            OnPropertyChanged(nameof(Project));
            OnPropertyChanged(nameof(Subproject));
            OnPropertyChanged(nameof(Resource));
        }

        private void IncrementResource()
        {
            _projectProvider.IncrementResourceCounter();
            OnPropertyChanged(nameof(Resource));
        }

        private void IncrementSubproject()
        {
            _projectProvider.IncrementSubprojectCounter();
            OnPropertyChanged(nameof(Subproject));
            OnPropertyChanged(nameof(Resource));
        }

        private void IncrementProject()
        {
            _projectProvider.IncrementProjectCounter();
            OnPropertyChanged(nameof(Project));
            OnPropertyChanged(nameof(Subproject));
            OnPropertyChanged(nameof(Resource));
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