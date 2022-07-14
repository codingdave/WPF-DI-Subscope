namespace WPF_DI_Subscope.Services
{
    public class InstanceCounter : IInstanceCounter
    {
        public InstanceCounter()
        {

        }
        
        public int Count { get; private set; }

        public void Increment()
        {
            Count++;
        }
    }
}
