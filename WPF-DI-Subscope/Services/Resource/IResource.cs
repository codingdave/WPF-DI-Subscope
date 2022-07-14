using System;

namespace WPF_DI_Subscope.Services.Resource
{
    public interface IResource : IDisposable
    {
        int Count { get; }

        void Increment();
    }
}