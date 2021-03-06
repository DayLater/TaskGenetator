﻿using System.Collections.Generic;
using TaskEngine.Models.Tasks.Texts;

namespace TaskEngine.Writers.DocWriters
{
    public interface IDocWriter
    {
        string TitleText { get; set; }
        FontSettings TitleFont { get; } 
        FontSettings TextFont { get; }
        void Write(string filename, IEnumerable<ITextTask> textTasks, int variantNumber);
    }
}