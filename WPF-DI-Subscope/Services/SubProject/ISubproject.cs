﻿namespace WPF_DI_Subscope.Services
{
    public interface ISubproject : IContent
    {
        IResource Resource { get; }

        void CreateNewResource();
    }
}