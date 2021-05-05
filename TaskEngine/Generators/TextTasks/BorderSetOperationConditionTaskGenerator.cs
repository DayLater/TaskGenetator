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
        
        protected override string GetCondition(VariantsBorderSetOperationTask task)
        {
            var firstSet = WriteSet(task.First);
            var secondSet = WriteSet(task.Second);
            var operation = SetOperationHelper.GetString(task.Operation);
            return $"Найдите {operation} множеств {firstSet} и {secondSet}";
        }
    }
}