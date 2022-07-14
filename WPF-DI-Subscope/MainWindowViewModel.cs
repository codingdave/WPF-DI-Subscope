using MVVMEssentials.ViewModels;
using System.Windows.Input;

public class MainWindowViewModel : ViewModelBase
{
    private IProject _project;
    public IProject Project
    {
        get => _project;
        set
        {
            if (_project != value)
            {
                _project = value;
                OnPropertyChanged(nameof(Project));
            }
        }
    }

    public MainWindowViewModel(IProjectFactory projectFactory)
    {
        _project = projectFactory.CreateNewProject();
        NewProjectCommand = new NewProjectCommand(this, projectFactory);
    }

    public ICommand NewProjectCommand { get; private set; }
}
