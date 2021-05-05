using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class NumbersBelongSetConditionTaskGenerator: ConditionTaskGenerator<NumbersBelongSetTask>
    {
        public NumbersBelongSetConditionTaskGenerator(ISetWriter setWriter, ITaskGenerator<NumbersBelongSetTask> taskGenerator) 
            : base(setWriter, taskGenerator) { }
        
        protected override string GetCondition(NumbersBelongSetTask task)
        {
            var writtenSet = WriteSet(task.Set);
            return $"Выберите все элементы, принадлежащие множеству {writtenSet}";
        }
    }
}