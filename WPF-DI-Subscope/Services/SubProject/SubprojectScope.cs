namespace WPF_DI_Subscope.Services
{
    public class SubprojectScope : ISubproject
    {
        private IInstanceCounter _instanceCounter;

        public string Data => _instanceCounter.Value;

        public IResourceScope Resource => _resourceProvider.Resource;

        private IResourceProvider _resourceProvider;

        public SubprojectScope(
            IResourceProvider resourceProvider,
            IInstanceCounter instanceCounter)
        {
            _resourceProvider = resourceProvider;
            _instanceCounter = instanceCounter;
        }

        public void Increment()
        {
            _instanceCounter.Increment();
        }

        public void Dispose()
        {
            _instanceCounter.Dispose();
            Resource.Dispose();
        }

        public void CreateNewResource()
        {
            _resourceProvider.CreateScope();
        }
    }
}