using TaskEngine.Tasks;

namespace TaskEngine.Generators.Tasks
{
    public interface ITaskGenerator<out TTask>: IGenerator
        where TTask: ITask
    {
        string Id { get; }
        TTask Generate();

    }
}