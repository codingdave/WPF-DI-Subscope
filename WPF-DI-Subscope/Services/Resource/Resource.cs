namespace WPF_DI_Subscope.Services
{
    public class Resource : IResource
    {
        private IInstanceCounter _instanceCounter;

        public string Data => _instanceCounter.Value;

        public Resource(IInstanceCounter instanceCounter)
        {
            _instanceCounter = instanceCounter;
        }

        public void Increment()
        {
            _instanceCounter.Increment();
        }

        public void Dispose()
        {
            _instanceCounter.Dispose();
        }
    }
}