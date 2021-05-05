using System;
using TaskEngine.Contexts;
using TaskEngine.Writers;
using WinGenerator.Views;

namespace WinGenerator
{
    public class Contexts
    {
        public TaskGeneratorContext TaskGeneratorsContext { get; }
        public TextTaskGeneratorsContext TextTaskGeneratorsContext { get; }
        public PresentersContext PresentersContext { get; }
        public IViewContext ViewContext { get; }
        public ExamplesContext ExamplesContext { get; } = new ExamplesContext();
        public UserContext UserContext { get; } = new UserContext();

        private readonly TaskWriter _taskWriter;

        public Contexts(ISetWriter setWriter, Random random)
        {
            _taskWriter = new TaskWriter(setWriter);
            TaskGeneratorsContext = new TaskGeneratorContext(random);
            TextTaskGeneratorsContext = new TextTaskGeneratorsContext(setWriter, TaskGeneratorsContext);

            foreach (var generator in TextTaskGeneratorsContext.Generators)
            {
                var (task, condition) = generator.Generate();
                var example = _taskWriter.WriteAll(task, condition);
                ExamplesContext.Add(generator.Id, example);
            }

            ViewContext = new ViewContext(TextTaskGeneratorsContext);
            PresentersContext = new PresentersContext(TextTaskGeneratorsContext, ViewContext, UserContext, ExamplesContext, _taskWriter);
        }
    }
}