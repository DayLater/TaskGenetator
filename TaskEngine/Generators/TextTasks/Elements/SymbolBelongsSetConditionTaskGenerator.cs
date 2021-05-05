using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class SymbolBelongsSetConditionTaskGenerator: ConditionTaskGenerator<SymbolBelongsSetTask>
    {
        public SymbolBelongsSetConditionTaskGenerator(ISetWriter setWriter, ITaskGenerator<SymbolBelongsSetTask> taskGenerator)
            : base(setWriter, taskGenerator) { }

        public override (ITask, string) Generate()
        {
            var task = GetTask();
            var writtenSet = WriteSet(task.Set);
            var writtenTask = $"Выберите элемент, принадлежащий множеству {writtenSet}.";
            return (task, writtenTask);
        }
    }
}