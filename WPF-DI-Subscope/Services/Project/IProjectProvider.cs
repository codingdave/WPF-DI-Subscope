using WPF_DI_Subscope.Services.Resource;

namespace WPF_DI_Subscope
{
    public interface IProjectProvider
    {
        void CreateNewProject();
        void CreateNewSubproject();
        void CreateNewResource();

        (IProject project, ISubproject subproject, IResource resource) GetProjectProvider();

        void DisposeProject();
        void DisposeSubproject();
        void DisposeResource();

        void IncrementSubprojectCounter();
        void IncrementResourceCounter();
        void IncrementProjectCounter();
    }
}