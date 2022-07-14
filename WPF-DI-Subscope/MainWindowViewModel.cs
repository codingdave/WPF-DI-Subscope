using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Windows.Input;

namespace WPF_DI_Subscope
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private IProjectFactory _projectFactory;
        private ISubprojectFactory _subprojectFactory;
        private ObjectIDGenerator _objectIdGenerator = new ObjectIDGenerator();

        [ObservableProperty]
        private IProject _project;

        [ObservableProperty]
        private ISubproject _subproject;

        public MainWindowViewModel(
            IProjectFactory projectFactory, 
            ISubprojectFactory subprojectFactory)
        {
            _projectFactory = projectFactory;
            _subprojectFactory = subprojectFactory;

            _project = projectFactory.CreateNewProject();
            _subproject = subprojectFactory.CreateNewSubproject();

            _resourceId = _objectIdGenerator.GetId(new object(), out _).ToString();
            _subprojectId = _objectIdGenerator.GetId(new object(), out _).ToString();
            _projectId = _objectIdGenerator.GetId(new object(), out _).ToString();

            NewProjectCommand = new RelayCommand(NewProject);
            NewSubprojectCommand = new RelayCommand(NewSubproject);
            NewResourceCommand = new RelayCommand(NewResource);
        }

        public ICommand NewProjectCommand { get; }
        public void NewProject()
        {
            Project = _projectFactory.CreateNewProject();
            ProjectId = _objectIdGenerator.GetId(Project, out _).ToString();
        }
        public void NewSubproject()
        {
            Subproject = _subprojectFactory.CreateNewSubproject();
            SubprojectId = _objectIdGenerator.GetId(Subproject, out _).ToString();
        }
        public void NewResource() { throw new NotImplementedException(); }

        [ObservableProperty]
        private string _resourceId;

        [ObservableProperty]
        private string _subprojectId;

        [ObservableProperty]
        private string _projectId;

        public ICommand NewResourceCommand { get; }

        public ICommand NewSubprojectCommand { get; }
    }
}