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

        public int Count => _instanceCounter.Count;

        public void Increment()
        {
            _instanceCounter.Increment();
        }
    }
}