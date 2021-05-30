using System;
using WindowsGenerator.Views;
using MaterialSkin;
using TaskEngine.Contexts;
using TaskEngine.Extensions;
using TaskEngine.Models;
using TaskEngine.Views;
using TaskEngine.Writers;
using TaskEngine.Writers.TaskWriters;

namespace WindowsGenerator
{
    public class Contexts
    {
        public PresentersContext PresentersContext { get; }
        public ViewContext ViewContext { get; }

        public Contexts(ISetWriter setWriter, Random random, IMainView mainView, IThemesController themesController, MaterialSkinManager skinManager)
        {
            var taskWriter = new TaskWriter(setWriter, random);
            var taskGeneratorsFactory = new TaskGeneratorContext(random, setWriter);

            var exampleContext = new ExamplesModel();
            foreach (var generator in taskGeneratorsFactory.TaskGenerators)
            {
                var task = generator.Generate();
                random.ClearNames();
                random.ClearSymbols();
                var example = taskWriter.WriteAll(task);
                exampleContext.Add(generator.Id, example);
            }

            ViewContext = new ViewContext(taskGeneratorsFactory, mainView, skinManager);
            PresentersContext = new PresentersContext(taskGeneratorsFactory, ViewContext, new UserModel(), exampleContext, taskWriter, random, themesController);
        }
    }
}