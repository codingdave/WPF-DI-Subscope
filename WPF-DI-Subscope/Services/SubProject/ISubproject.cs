using System;

namespace WPF_DI_Subscope
{
    public interface ISubproject : IDisposable
    {
        string Instance { get; }

        void Increment();
    }
}