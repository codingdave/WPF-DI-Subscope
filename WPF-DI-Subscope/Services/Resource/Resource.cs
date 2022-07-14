using System;

namespace WPF_DI_Subscope.Services.Resource
{
    public class Resource : IResource
    {
        public Resource()
        {
            Value = DateTime.Now.ToString();
        }
        
        public string Value { get; set; }
    }
}