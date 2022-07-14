namespace WPF_DI_Subscope.Services
{
    public class InstanceCounter : IInstanceCounter
    {
        private int _project;

        public int AddProject()
        {
            return ++_project;
        }
    }
}
