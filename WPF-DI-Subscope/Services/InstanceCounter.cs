namespace WPF_DI_Subscope.Services
{
    public class InstanceCounter : IInstanceCounter
    {
        private int _counter = 0;

        public string Value
        {
            get => _value;
            private set
            {
                if (!_isDisposed)
                {
                    _value = value;
                }
                else
                {
                    _value = "ERROR: Object is disposed";
                }
            }
        }
        private bool _isDisposed;
        private string _value = "0";

        public void Dispose()
        {
            Value = "Disposed";
            _isDisposed = true;
        }

        public void Increment()
        {
            _counter++;
            Value = _counter.ToString();
        }
    }
}