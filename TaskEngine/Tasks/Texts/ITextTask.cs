﻿namespace TaskEngine.Tasks.Texts
{
    public interface ITextTask
    {
        string Task { get; }
        string Answer { get; }
    }
}