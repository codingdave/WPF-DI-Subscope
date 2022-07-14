using System;

namespace WPF_DI_Subscope
{
    public interface IProject : IDisposable
    {
        int Count { get; }

        void Increment();
    }
}
