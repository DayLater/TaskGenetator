using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class NumberBelongsSetConditionTaskGenerator: ConditionTaskGenerator<NumberBelongsSetTask>
    {
        public NumberBelongsSetConditionTaskGenerator(ISetWriter setWriter, ITaskGenerator<NumberBelongsSetTask> taskGenerator)
            : base(setWriter, taskGenerator) { }
        
        protected override string GetCondition(NumberBelongsSetTask task)
        {
            return $"Выберите элемент, принадлежащий множеству {WriteSet(task.Set)}";
        }
    }
}