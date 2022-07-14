namespace WPF_DI_Subscope.Services
{
    public interface IContent
    {
        string Data { get; }

        void Dispose();

        void Increment();
    }
}