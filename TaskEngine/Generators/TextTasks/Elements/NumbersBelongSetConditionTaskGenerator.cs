using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class NumbersBelongSetConditionTaskGenerator: ConditionTaskGenerator<NumbersBelongSetTask>
    {
        public NumbersBelongSetConditionTaskGenerator(ISetWriter setWriter, ITaskGenerator<NumbersBelongSetTask> taskGenerator) 
            : base(setWriter, taskGenerator) { }

        public override (ITask, string) Generate()
        {
            var task = GetTask();
            var writtenSet = WriteSet(task.Set);
            var writtenTask = $"Выберите все элементы, принадлежащие множеству {writtenSet}";
            return (task, writtenTask);
        }
    }
}