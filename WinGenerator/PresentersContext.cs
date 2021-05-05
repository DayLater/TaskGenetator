using TaskEngine.Contexts;
using TaskEngine.Presenters;
using TaskEngine.Writers;
using TaskEngine.Writers.DocWriters;

namespace WinGenerator
{
    public class PresentersContext
    {
        public MainPresenter MainPresenter { get; }
        public TaskChoosePresenter TaskChoosePresenter { get; }
        public CreateDocumentPresenter CreateDocumentPresenter { get; }
        
        public PresentersContext(TextTaskGeneratorsContext textTaskGeneratorsContext, IViewContext viewContext, UserContext userContext, ExamplesContext examplesContext, TaskWriter taskWriter)
        {
            MainPresenter = new MainPresenter(viewContext.MainView, userContext);
            TaskChoosePresenter = new TaskChoosePresenter(userContext.TasksContext, viewContext.TaskChooseView, examplesContext);
            CreateDocumentPresenter = new CreateDocumentPresenter(viewContext.CreateDocumentView, userContext.TasksContext, new DocWriter(), textTaskGeneratorsContext, taskWriter);
        }
    }
}