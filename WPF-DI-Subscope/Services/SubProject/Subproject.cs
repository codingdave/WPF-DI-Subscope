using WPF_DI_Subscope.Services;

namespace WPF_DI_Subscope
{
    public class Subproject : ISubproject
    {
        public int ProjectCount { get; }

        public Subproject(IInstanceCounter instanceCounter)
        {
            ProjectCount = instanceCounter.AddProject();
        }
    }
}