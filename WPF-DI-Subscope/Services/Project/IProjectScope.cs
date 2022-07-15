namespace WPF_DI_Subscope.Services
{
    public interface IProjectScope : IContent
    {
        ISubproject Subproject { get; }

        void CreateNewSubproject();
    }
}