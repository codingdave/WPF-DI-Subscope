using System;

namespace WPF_DI_Subscope
{
    public interface ISubproject : IDisposable
    {
        int Count { get; }

        void Increment();
    }
}