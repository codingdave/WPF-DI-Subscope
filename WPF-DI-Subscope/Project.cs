using System;

namespace WPF_DI_Subscope
{
    public class Project : IProject
    {
        public Guid Guid { get; } = Guid.NewGuid();
    }
}