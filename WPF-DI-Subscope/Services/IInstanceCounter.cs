using System;

namespace WPF_DI_Subscope.Services
{
    public interface IInstanceCounter: IDisposable
    {
        void Increment();
        string Value { get; }
    }
}
