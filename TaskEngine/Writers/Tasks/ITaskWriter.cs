using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers.Tasks
{
    public interface ITaskWriter<in TTask>
        where TTask: ITask
    {
        ITextTask WriteTask(TTask task);
    }
}