using TaskEngine.Generators.Tasks;
using TaskEngine.Helpers;
using TaskEngine.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks
{
    public class VariantsSubSetConditionTaskGenerator: ConditionTaskGenerator<VariantsSubSetTask>
    {
        protected override string GetCondition(VariantsSubSetTask task)
        {
            var set = WriteSet(task.Set);
            var type = SubSetTypeHelper.GetNumbersType(task.Type);
            return $"Дано множество {set}.\nУкажите его подмножество, элементами которого являются все его {type} числа";
        }

        public VariantsSubSetConditionTaskGenerator(ISetWriter setWriter, ITaskGenerator<VariantsSubSetTask> taskGenerator) 
            : base(setWriter, taskGenerator) { }
    }
}