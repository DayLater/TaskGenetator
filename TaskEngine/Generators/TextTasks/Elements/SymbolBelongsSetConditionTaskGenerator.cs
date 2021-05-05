using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class SymbolBelongsSetConditionTaskGenerator: ConditionTaskGenerator<SymbolBelongsSetTask>
    {
        public SymbolBelongsSetConditionTaskGenerator(ISetWriter setWriter, ITaskGenerator<SymbolBelongsSetTask> taskGenerator)
            : base(setWriter, taskGenerator) { }

        protected override string GetCondition(SymbolBelongsSetTask task)
        {
            var writtenSet = WriteSet(task.Set);
            return $"Выберите элемент, принадлежащий множеству {writtenSet}.";
        }
    }
}