using System;
using TaskEngine.Writers;

namespace TaskEngine.Contexts
{
    public class Contexts
    {
        public TaskGeneratorContext TaskGeneratorsContext { get; }
        public TextTaskGeneratorsContext TextTaskGeneratorsContext { get; }
        public PresentersContext PresentersContext { get; }
        public IViewContext ViewContext { get; }
        public ExamplesContext ExamplesContext { get; } = new ExamplesContext();
        public UserContext UserContext { get; } = new UserContext();

        public Contexts(ISetWriter setWriter, Random random, IViewContext viewContext)
        {
            ViewContext = viewContext;
            TaskGeneratorsContext = new TaskGeneratorContext(random);
            TextTaskGeneratorsContext = new TextTaskGeneratorsContext(setWriter, TaskGeneratorsContext);

            foreach (var (id, generator) in TextTaskGeneratorsContext.Generators)
            {
                ExamplesContext.Add(id, generator.Generate().Task);
            }
            
            PresentersContext = new PresentersContext(TaskGeneratorsContext, TextTaskGeneratorsContext, viewContext, UserContext, ExamplesContext);
        }
    }
}