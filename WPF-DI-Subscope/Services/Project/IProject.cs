using System;

namespace WPF_DI_Subscope
{
    public interface IProject
    {
        int Count { get; }

        void Increment();
    }
}
