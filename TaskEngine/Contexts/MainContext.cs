using System;
using TaskEngine.Controllers;
using TaskEngine.Writers;

namespace TaskEngine.Contexts
{
    public class MainContext
    {
        public TaskGeneratorContext TaskGeneratorsContext { get; }
        public TaskWritersContext TaskWritersContext { get; }
        public TaskControllersContext TaskControllersContext { get; }

        public MainContext(ISetWriter setWriter, Random random, IViewContext viewContext)
        {
            TaskWritersContext = new TaskWritersContext(setWriter);
            TaskGeneratorsContext = new TaskGeneratorContext(random);

            TaskControllersContext = new TaskControllersContext(TaskGeneratorsContext, TaskWritersContext, viewContext);
        }
    }
}