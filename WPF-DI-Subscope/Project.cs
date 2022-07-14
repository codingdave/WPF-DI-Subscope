using System;

namespace WPF_DI_Subscope
{
    public class Project : IProject
    {
        public int ProjectCount { get; }

        public Project(IInstanceCounter instanceCounter)
        {
            ProjectCount = instanceCounter.AddProject();
        }
    }
}