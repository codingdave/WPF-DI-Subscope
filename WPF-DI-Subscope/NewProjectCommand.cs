using MVVMEssentials.Commands;

public class NewProjectCommand : CommandBase
{
    private readonly MainWindowViewModel _mainWindowViewModel;
    private IProjectFactory _projectFactory;

    public NewProjectCommand(MainWindowViewModel mainWindowViewModel, IProjectFactory projectFactory)
    {
        _mainWindowViewModel = mainWindowViewModel;
        _projectFactory = projectFactory;
    }

    public override void Execute(object parameter)
    {
        _mainWindowViewModel.Project = _projectFactory.CreateNewProject();
    }
}