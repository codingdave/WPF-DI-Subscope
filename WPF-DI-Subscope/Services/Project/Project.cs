namespace WPF_DI_Subscope.Services
{
    public class Project : IProject
    {
        private IInstanceCounter _instanceCounter;

        public string Data => _instanceCounter.Value;

        public ISubproject Subproject => _subprojectProvider.Subproject;

        private ISubprojectProvider _subprojectProvider;

        public Project(
            ISubprojectProvider subprojectProvider,
            IInstanceCounter instanceCounter)
        {
            _subprojectProvider = subprojectProvider;
            _instanceCounter = instanceCounter;
        }

        public void Increment()
        {
            _instanceCounter.Increment();
        }

        public void Dispose()
        {
            _instanceCounter.Dispose();
            Subproject.Dispose();
        }

        public void CreateNewSubproject()
        {
            _subprojectProvider.CreateScope();
        }
    }
}