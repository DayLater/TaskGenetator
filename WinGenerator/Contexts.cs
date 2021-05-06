using System;
using TaskEngine.Contexts;
using TaskEngine.Factories;
using TaskEngine.Writers;
using TaskEngine.Writers.TaskWriters;
using WinGenerator.Views;

namespace WinGenerator
{
    public class Contexts
    {
        public TaskGeneratorFactory TaskGeneratorsFactory { get; }
        public PresentersContext PresentersContext { get; }
        public IViewContext ViewContext { get; }
        public ExamplesContext ExamplesContext { get; } = new ExamplesContext();
        public UserContext UserContext { get; } = new UserContext();

        public Contexts(ISetWriter setWriter, Random random)
        {
            var taskWriter = new TaskWriter(setWriter, random);
            TaskGeneratorsFactory = new TaskGeneratorFactory(random, setWriter);

            foreach (var generator in TaskGeneratorsFactory.TaskGenerators)
            {
                var task = generator.Generate();
                var example = taskWriter.WriteAll(task);
                ExamplesContext.Add(generator.Id, example);
            }

            ViewContext = new ViewContext(TaskGeneratorsFactory);
            PresentersContext = new PresentersContext(TaskGeneratorsFactory, ViewContext, UserContext, ExamplesContext, taskWriter);
        }
    }
}