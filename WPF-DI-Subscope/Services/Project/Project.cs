using System;

namespace WPF_DI_Subscope.Services
{
    public class Project : IProject
    {
        private IInstanceCounter _instanceCounter;

        public string Instance => _instanceCounter.Value;

        public Project(IInstanceCounter instanceCounter)
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