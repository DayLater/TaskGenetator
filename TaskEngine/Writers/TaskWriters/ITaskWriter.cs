using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers.TaskWriters
{
    public interface ITaskWriter
    {
        ITextTask Write(ITask task);
    }
}