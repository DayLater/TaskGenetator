using System;
using System.Linq;
using TaskEngine.Contexts;
using TaskEngine.Models;
using TaskEngine.Presenters;
using TaskEngine.Views;
using TaskEngine.Writers.DocWriters;
using TaskEngine.Writers.TaskWriters;

namespace WindowsGenerator
{
    public class PresentersContext
    {
        public MainPresenter MainPresenter { get; }
        public TaskChoosePresenter TaskChoosePresenter { get; }
        public CreateDocumentPresenter CreateDocumentPresenter { get; }
        
        public PresentersContext(TaskGeneratorContext generatorContext, IViewContext viewContext, UserModel userModel, ExamplesModel examplesModel, TaskWriter taskWriter, Random random, IThemesController themesController)
        {
            var homePagePresenter = new HomePagePresenter(viewContext.HomePageView, themesController);
            MainPresenter = new MainPresenter(viewContext.MainView, userModel);
            
            var taskIds = generatorContext.TaskGenerators.Select(g => g.Id).ToList();
            TaskChoosePresenter = new TaskChoosePresenter(userModel.TasksModel, viewContext.TaskChooseView, examplesModel, taskIds);
            CreateDocumentPresenter = new CreateDocumentPresenter(viewContext.CreateDocumentView, userModel.TasksModel, new DocWriter(), generatorContext, taskWriter, random);
        }
    }
}