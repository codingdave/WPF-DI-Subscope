namespace WPF_DI_Subscope.Services
{
    public class InstanceCounter : IInstanceCounter
    {
        private int _counter = 0;

        public string Value { get; private set; } = "0";

        private bool _isDisposed;

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
                Value = "Disposed";
            }
        }

        public void Increment()
        {
            if (!_isDisposed)
            {
                _counter++;
                Value = _counter.ToString(); ;
            }
            else
            {
                Value = "ERROR: Object is disposed";
            }
        }
    }
}
