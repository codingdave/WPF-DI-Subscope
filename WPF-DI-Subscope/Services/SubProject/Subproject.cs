using WPF_DI_Subscope.Services;

namespace WPF_DI_Subscope
{
    public class Subproject : ISubproject
    {
        private IInstanceCounter? _instanceCounter;

        public int Count => _instanceCounter!.Count;

        public Subproject(IInstanceCounter instanceCounter)
        {
            _instanceCounter = instanceCounter;
        }

        public void Increment()
        {
            _instanceCounter!.Increment();
        }

        public void Dispose()
        {
            _instanceCounter = null;
        }
    }
}