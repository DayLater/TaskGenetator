using TaskEngine.Generators.Tasks;
using TaskEngine.Helpers;
using TaskEngine.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks
{
    public class BorderSetOperationConditionTaskGenerator: ConditionTaskGenerator<VariantsBorderSetOperationTask>
    {
        public BorderSetOperationConditionTaskGenerator(ISetWriter setWriter, ITaskGenerator<VariantsBorderSetOperationTask> taskGenerator)
            : base(setWriter, taskGenerator) { }

        public override (ITask, string) Generate()
        {
            var task = GetTask();
            var firstSet = WriteSet(task.First);
            var secondSet = WriteSet(task.Second);
            var operation = SetOperationHelper.GetString(task.Operation);
            var textTask = $"Найдите {operation} множеств {firstSet} и {secondSet}";
            return (task, textTask);
        }
    }
}