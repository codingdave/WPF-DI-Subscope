namespace WPF_DI_Subscope.Services
{
    public interface ISubprojectProvider : IProvider
    {
        ISubproject Subproject { get; }
    }
}