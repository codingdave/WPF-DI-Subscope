namespace WPF_DI_Subscope
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
