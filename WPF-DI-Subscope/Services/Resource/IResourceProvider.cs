namespace WPF_DI_Subscope.Services
{
    public interface IResourceProvider : IProvider
    {
        IResourceScope Resource { get; }
    }
}