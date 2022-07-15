namespace WPF_DI_Subscope.Services
{
    public interface ISubproject : IContent
    {
        IResourceScope Resource { get; }

        void CreateNewResource();
    }
}