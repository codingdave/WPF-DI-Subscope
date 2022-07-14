namespace WPF_DI_Subscope.Services
{
    public interface IInstanceCounter
    {
        void Increment();
        int Count { get; }
    }
}
