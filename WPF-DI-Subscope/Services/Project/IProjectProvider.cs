namespace WPF_DI_Subscope.Services
{
    public interface IProjectProvider : IProvider
    {
        IProjectScope ProjectScope { get; }
    }
}