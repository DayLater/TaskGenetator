using TaskEngine.Tasks.Texts;
using TaskEngine.Views;

namespace TaskEngine.Presenters
{
    public interface ITaskPresenter
    {
        string Id { get; }
        ITextTask Generate();
        IView GeneratorView { get; }
    }
}