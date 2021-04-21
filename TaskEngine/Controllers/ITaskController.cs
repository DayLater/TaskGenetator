using TaskEngine.Tasks.Texts;

namespace TaskEngine.Controllers
{
    public interface ITaskController
    {
        string Id { get; }
        ITextTask Generate();
    }
}