using TaskEngine.Tasks;

namespace TaskEngine.Generators.Tasks
{
    public interface ITaskGenerator : IValued
    {
        string Id { get; }
        ITask Generate();
    }
}