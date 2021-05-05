using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks;

namespace TaskEngine.Generators.TextTasks
{
    public interface IConditionTaskGenerator
    {
        string Id { get; }
        IConditionTask Generate();
        IValued ValuedGenerator { get; }
    }
}