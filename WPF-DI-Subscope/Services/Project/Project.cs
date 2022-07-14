using System;

namespace WPF_DI_Subscope.Services
{
    public class Project : IProject
    {
        private IInstanceCounter _instanceCounter;

        public int Count => _instanceCounter.Count;

        public Project(IInstanceCounter instanceCounter)
        {
            _instanceCounter = instanceCounter;
        }

        public void Increment()
        {
            _instanceCounter.Increment();
        }
    }
}