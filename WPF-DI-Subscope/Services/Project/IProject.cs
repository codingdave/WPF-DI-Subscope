using System;

namespace WPF_DI_Subscope
{
    public interface IProject : IDisposable
    {
        string Instance { get; }

        void Increment();
    }
}
