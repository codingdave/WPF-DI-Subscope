using System;

namespace WPF_DI_Subscope.Services
{
    public class Project : IProject
    {
        public int Count { get; }

        public Project(IInstanceCounter instanceCounter)
        {
            Count = instanceCounter.AddProject();
        }
    }
}