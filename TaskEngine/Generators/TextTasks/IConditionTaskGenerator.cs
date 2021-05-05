using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks;

namespace TaskEngine.Generators.TextTasks
{
    public interface IConditionTaskGenerator
    {
        string Id { get; }
        (ITask, string) Generate();
        IValued ValuedGenerator { get; }
    }
}