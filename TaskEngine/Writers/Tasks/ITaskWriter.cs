using TaskEngine.Tasks;

namespace TaskEngine.Writers.Tasks
{
    public interface ITaskWriter<in TTask>
        where TTask: ITask
    {
        string WriteTask(TTask task);
        string WriteAnswer(TTask task);
    }
}