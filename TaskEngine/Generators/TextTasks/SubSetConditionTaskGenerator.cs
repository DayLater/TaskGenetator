using TaskEngine.Generators.Tasks;
using TaskEngine.Helpers;
using TaskEngine.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks
{
    public class SubSetConditionTaskGenerator: ConditionTaskGenerator<SubSetTask>
    {
        public override (ITask, string) Generate()
        {
            var task = GetTask();
            var writeSet = WriteSet(task.Set);
            var writeType = SubSetTypeHelper.GetNumbersType(task.TypeTask);
            var textTask = $"Дано множество {writeSet}.\nВыделите его подмножество, элементами которого являются {writeType} числа";
            return (task, textTask);
        }

        public SubSetConditionTaskGenerator(ISetWriter setWriter, ITaskGenerator<SubSetTask> taskGenerator) : base(setWriter, taskGenerator)
        {
        }
    }
}