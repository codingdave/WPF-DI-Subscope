namespace WPF_DI_Subscope.Services
{
    public interface IProvider
    {
        void CreateScope();
        void Dispose();
    }
}