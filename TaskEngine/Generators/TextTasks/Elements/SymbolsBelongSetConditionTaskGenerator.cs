using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class SymbolsBelongSetConditionTaskGenerator: ConditionTaskGenerator<SymbolsBelongSetTask>
    {
        public SymbolsBelongSetConditionTaskGenerator(ISetWriter setWriter, ITaskGenerator<SymbolsBelongSetTask> taskGenerator) 
            : base(setWriter, taskGenerator) { }
        
        protected override string GetCondition(SymbolsBelongSetTask task)
        {
            var writtenSet = WriteSet(task.Set);
            return $"Выберите все элементы, принадлежащий множеству {writtenSet}";
        }
    }
}