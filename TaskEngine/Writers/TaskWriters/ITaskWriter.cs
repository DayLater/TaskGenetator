using TaskEngine.Models.Tasks;
using TaskEngine.Models.Tasks.Texts;

namespace TaskEngine.Writers.TaskWriters
{
    public interface ITaskWriter
    {
        ITextTask Write(ITask task);
    }
}