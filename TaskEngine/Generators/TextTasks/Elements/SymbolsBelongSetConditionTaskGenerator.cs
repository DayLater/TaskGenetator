using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class SymbolsBelongSetConditionTaskGenerator: ConditionTaskGenerator<SymbolsBelongSetTask>
    {
        public SymbolsBelongSetConditionTaskGenerator(ISetWriter setWriter, ITaskGenerator<SymbolsBelongSetTask> taskGenerator) 
            : base(setWriter, taskGenerator) { }

        public override (ITask, string) Generate()
        {
            var task = GetTask();
            var writtenSet = WriteSet(task.Set);
            var writtenTask = $"Выберите все элементы, принадлежащий множеству {writtenSet}";
            return (task, writtenTask);
        }
    }
}