using System;

namespace WPF_DI_Subscope.Services
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