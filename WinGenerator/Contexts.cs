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
        public PresentersContext PresentersContext { get; }
        public ViewContext ViewContext { get; }

        public Contexts(ISetWriter setWriter, Random random, IMainView mainView, IThemesController themesController, MaterialSkinManager skinManager)
        {
            var taskWriter = new TaskWriter(setWriter, random);
            var taskGeneratorsFactory = new TaskGeneratorFactory(random, setWriter);

            var exampleContext = new ExamplesContext();
            foreach (var generator in taskGeneratorsFactory.TaskGenerators)
            {
                var task = generator.Generate();
                random.ClearNames();
                random.ClearSymbols();
                var example = taskWriter.WriteAll(task);
                exampleContext.Add(generator.Id, example);
            }

            ViewContext = new ViewContext(taskGeneratorsFactory, mainView, skinManager);
            PresentersContext = new PresentersContext(taskGeneratorsFactory, ViewContext, new UserContext(), exampleContext, taskWriter, random, themesController);
        }
    }
}