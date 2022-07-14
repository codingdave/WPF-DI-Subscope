using System;

namespace WPF_DI_Subscope.Services.Resource
{
    public class Resource : IResource
    {
        private IInstanceCounter _instanceCounter;

        public Resource(IInstanceCounter instanceCounter)
        {
            _instanceCounter = instanceCounter;
        }

        public string Instance => _instanceCounter.Value;

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