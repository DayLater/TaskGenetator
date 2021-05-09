using System;
using TaskEngine.Contexts;
using TaskEngine.Factories;
using TaskEngine.Presenters;
using TaskEngine.Writers.DocWriters;
using TaskEngine.Writers.TaskWriters;

namespace WinGenerator
{
    public class PresentersContext
    {
        public MainPresenter MainPresenter { get; }
        public TaskChoosePresenter TaskChoosePresenter { get; }
        public CreateDocumentPresenter CreateDocumentPresenter { get; }
        
        public PresentersContext(TaskGeneratorFactory generatorFactory, IViewContext viewContext, UserContext userContext, ExamplesContext examplesContext, TaskWriter taskWriter, Random random)
        {
            MainPresenter = new MainPresenter(viewContext.MainView, userContext);
            TaskChoosePresenter = new TaskChoosePresenter(userContext.TasksContext, viewContext.TaskChooseView, examplesContext);
            CreateDocumentPresenter = new CreateDocumentPresenter(viewContext.CreateDocumentView, userContext.TasksContext, new DocWriter(), generatorFactory, taskWriter, random);
        }
    }
}