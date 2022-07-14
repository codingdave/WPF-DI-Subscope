using System;

namespace WPF_DI_Subscope.Services.Resource
{
    public interface IResource : IDisposable
    {
        string Instance { get; }

        void Increment();
    }
}