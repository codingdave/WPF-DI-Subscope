using WPF_DI_Subscope.Services;

namespace WPF_DI_Subscope
{
    public class Subproject : ISubproject
    {
        public int Count { get; }

        public Subproject(IInstanceCounter instanceCounter)
        {
            Count = instanceCounter.AddProject();
        }
    }
}