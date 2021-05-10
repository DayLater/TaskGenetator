using TaskEngine.Views;

namespace TaskEngine.Contexts
{
    public interface IViewContext
    {
        IMainView MainView { get; }
        ITaskChooseView TaskChooseView { get; }
        ICreateDocumentView CreateDocumentView { get; }
        IHomePageView HomePageView { get; }
    }
}