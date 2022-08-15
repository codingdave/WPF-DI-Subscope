using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Globalization;
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
        [NotifyPropertyChangedFor(nameof(SubprojectScope))]
        [NotifyPropertyChangedFor(nameof(ResourceScope))]
        private IProjectScope _projectScope;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ResourceScope))]
        private ISubproject _subprojectScope;

        [ObservableProperty]
        private IResourceScope _resourceScope;

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

        private void UpdateProperties()
        {
            // always assign in this order since the items depend on each other
            ResourceScope = _projectProvider.ProjectScope.Subproject.Resource;
            SubprojectScope = _projectProvider.ProjectScope.Subproject;
            ProjectScope = _projectProvider.ProjectScope;
        }

        public void NewProject()
        {
            _projectProvider.CreateScope();
            UpdateProperties();
        }

        public void NewSubproject()
        {
            _projectProvider.ProjectScope.CreateNewSubproject();
            UpdateProperties();
        }

        public void NewResource()
        {
            SubprojectScope.CreateNewResource();
            UpdateProperties();
        }

        private void DisposeResource()
        {
            ResourceScope.Dispose();
            OnPropertyChanged(nameof(ResourceScope));
        }

        private void DisposeSubproject()
        {
            SubprojectScope.Dispose();
            OnPropertyChanged(nameof(SubprojectScope));
            OnPropertyChanged(nameof(ResourceScope));
        }

        private void DisposeProject()
        {
            ProjectScope.Dispose();
            OnPropertyChanged(nameof(ProjectScope));
            OnPropertyChanged(nameof(SubprojectScope));
            OnPropertyChanged(nameof(ResourceScope));
        }

        private void IncrementResource()
        {
            ResourceScope.Increment();
            OnPropertyChanged(nameof(ResourceScope));
        }

        private void IncrementSubproject()
        {
            SubprojectScope.Increment();
            OnPropertyChanged(nameof(SubprojectScope));
            OnPropertyChanged(nameof(ResourceScope));
        }

        private void IncrementProject()
        {
            ProjectScope.Increment();
            OnPropertyChanged(nameof(ProjectScope));
            OnPropertyChanged(nameof(SubprojectScope));
            OnPropertyChanged(nameof(ResourceScope));
        }

        private void MainWindowViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(ProjectScope):
                    ProjectId = _projctIdGenerator.GetId(ProjectScope, out _).ToString(CultureInfo.InvariantCulture);
                    break;
                case nameof(SubprojectScope):
                    SubprojectId = _subprojectIdGenerator.GetId(SubprojectScope, out _).ToString(CultureInfo.InvariantCulture);
                    break;
                case nameof(ResourceScope):
                    ResourceId = _resourceIdGenerator.GetId(ResourceScope, out _).ToString(CultureInfo.InvariantCulture);
                    break;
            }
        }
    }
}