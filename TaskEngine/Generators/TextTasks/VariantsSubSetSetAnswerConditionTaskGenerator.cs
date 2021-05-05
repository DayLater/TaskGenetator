using TaskEngine.Generators.Tasks;
using TaskEngine.Helpers;
using TaskEngine.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks
{
    public class VariantsSubSetSetAnswerConditionTaskGenerator: ConditionTaskGenerator<VariantsSubSetTask>
    {
        public override (ITask, string) Generate()
        {
            var task = GetTask();
            var set = WriteSet(task.Set);
            var type = SubSetTypeHelper.GetNumbersType(task.Type);
            var textTask = $"Дано множество {set}." +
                           $"\nУкажите его подмножество, элементами которого являются все его {type} числа";
            return (task, textTask);
        }
        
        public VariantsSubSetSetAnswerConditionTaskGenerator(ISetWriter setWriter, ITaskGenerator<VariantsSubSetTask> taskGenerator) 
            : base(setWriter, taskGenerator) { }
    }
}