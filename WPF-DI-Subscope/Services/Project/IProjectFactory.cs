using WPF_DI_Subscope.Services.Resource;

namespace WPF_DI_Subscope
{
    public interface IProjectFactory
    {
        void CreateNewProject();
        void CreateNewSubproject();
        void CreateNewResource();

        (IProject, ISubproject, IResource) GetProjectProvider();
        void IncrementSubprojectCounter();
        void IncrementResourceCounter();
        void IncrementProjectCounter();
    }
}