﻿using System;
using TaskEngine.Writers;

namespace TaskEngine.Contexts
{
    public class MainContext
    {
        public TaskGeneratorContext TaskGeneratorsContext { get; }
        public TaskWritersContext TaskWritersContext { get; }
        public TaskPresentersContext TaskPresentersContext { get; }

        public MainContext(ISetWriter setWriter, Random random, IViewContext viewContext)
        {
            TaskWritersContext = new TaskWritersContext(setWriter);
            TaskGeneratorsContext = new TaskGeneratorContext(random);

            TaskPresentersContext = new TaskPresentersContext(TaskGeneratorsContext, TaskWritersContext, viewContext);
        }
    }
}