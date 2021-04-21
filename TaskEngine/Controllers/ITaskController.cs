using TaskEngine.Tasks.Texts;
using TaskEngine.Views;

namespace TaskEngine.Controllers
{
    public interface ITaskController
    {
        string Id { get; }
        ITextTask Generate();
        IView GeneratorView { get; }
    }
}