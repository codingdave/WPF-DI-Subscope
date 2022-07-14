﻿namespace WPF_DI_Subscope.Services
{
    public interface IProject : IContent
    {
        ISubproject Subproject { get; }

        void CreateNewSubproject();
    }
}