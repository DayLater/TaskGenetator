using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class NumberBelongsSetConditionTaskGenerator: ConditionTaskGenerator<NumberBelongsSetTask>
    {
        public NumberBelongsSetConditionTaskGenerator(ISetWriter setWriter, ITaskGenerator<NumberBelongsSetTask> taskGenerator)
            : base(setWriter, taskGenerator) { }

        public override (ITask, string) Generate()
        {
            var task = GetTask();
            var writtenSet = WriteSet(task.Set);
            var condition = $"Выберите элемент, принадлежащий множеству {writtenSet}";
            return (task, condition);
        }
    }
}