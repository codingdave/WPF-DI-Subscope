using System;

public class Project : IProject
{
    public Guid Guid { get; } = Guid.NewGuid();
}