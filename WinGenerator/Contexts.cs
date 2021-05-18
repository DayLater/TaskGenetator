using System;
using MaterialSkin;
using TaskEngine.Contexts;
using TaskEngine.Extensions;
using TaskEngine.Factories;
using TaskEngine.Views;
using TaskEngine.Writers;
using TaskEngine.Writers.TaskWriters;
using WinGenerator.Views;

namespace WinGenerator
{
    public class Contexts
    {
        public TaskGeneratorFactory TaskGeneratorsFactory { get; }
        public PresentersContext PresentersContext { get; }
        public ViewContext ViewContext { get; }
        public ExamplesContext ExamplesContext { get; } = new ExamplesContext();
        public UserContext UserContext { get; } = new UserContext();

        public Contexts(ISetWriter setWriter, Random random, IMainView mainView, IThemesController themesController, MaterialSkinManager skinManager)
        {
            var taskWriter = new TaskWriter(setWriter, random);
            TaskGeneratorsFactory = new TaskGeneratorFactory(random, setWriter);

            foreach (var generator in TaskGeneratorsFactory.TaskGenerators)
            {
                var task = generator.Generate();
                random.ClearNames();
                random.ClearSymbols();
                var example = taskWriter.WriteAll(task);
                ExamplesContext.Add(generator.Id, example);
            }

            ViewContext = new ViewContext(TaskGeneratorsFactory, mainView, skinManager);
            PresentersContext = new PresentersContext(TaskGeneratorsFactory, ViewContext, UserContext, ExamplesContext, taskWriter, random, themesController);
        }
    }
}