using TaskEngine.Models.Tasks;
using TaskEngine.Models.Values;

namespace TaskEngine.Generators.Tasks
{
    public interface ITaskGenerator : IValued
    {
        string Id { get; }
        ITask Generate();
    }
}