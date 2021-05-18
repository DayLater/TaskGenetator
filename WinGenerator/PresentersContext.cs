using System;
using System.Linq;
using TaskEngine.Contexts;
using TaskEngine.Factories;
using TaskEngine.Presenters;
using TaskEngine.Views;
using TaskEngine.Writers.DocWriters;
using TaskEngine.Writers.TaskWriters;

namespace WinGenerator
{
    public class PresentersContext
    {
        public MainPresenter MainPresenter { get; }
        public TaskChoosePresenter TaskChoosePresenter { get; }
        public CreateDocumentPresenter CreateDocumentPresenter { get; }
        
        public PresentersContext(TaskGeneratorFactory generatorFactory, IViewContext viewContext, UserContext userContext, ExamplesContext examplesContext, TaskWriter taskWriter, Random random, IThemesController themesController)
        {
            var homePagePresenter = new HomePagePresenter(viewContext.HomePageView, themesController);
            MainPresenter = new MainPresenter(viewContext.MainView, userContext);
            
            var taskIds = generatorFactory.TaskGenerators.Select(g => g.Id).ToList();
            TaskChoosePresenter = new TaskChoosePresenter(userContext.TasksContext, viewContext.TaskChooseView, examplesContext, taskIds);
            CreateDocumentPresenter = new CreateDocumentPresenter(viewContext.CreateDocumentView, userContext.TasksContext, new DocWriter(), generatorFactory, taskWriter, random);
        }
    }
}