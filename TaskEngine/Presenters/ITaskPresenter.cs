using TaskEngine.Tasks.Texts;
using TaskEngine.Views;

namespace TaskEngine.Presenters
{
    public interface ITaskPresenter
    {
        string Id { get; }
        string ExampleTask { get; }
        IView GeneratorView { get; }
    }
}