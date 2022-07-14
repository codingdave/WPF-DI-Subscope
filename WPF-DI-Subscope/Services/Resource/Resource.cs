using System;

namespace WPF_DI_Subscope.Services.Resource
{
    public class Resource : IResource
    {
        public Resource(IInstanceCounter instanceCounter)
        {
            Count = instanceCounter.AddProject();
        }

        public int Count { get; set; }
    }
}