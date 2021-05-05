using TaskEngine.Generators.Tasks;
using TaskEngine.Helpers;
using TaskEngine.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks
{
    public class SubSetConditionTaskGenerator: ConditionTaskGenerator<SubSetTask>
    {
        protected override string GetCondition(SubSetTask task)
        {
            var writeSet = WriteSet(task.Set);
            var writeType = SubSetTypeHelper.GetNumbersType(task.TypeTask);
            return $"Дано множество {writeSet}.\nВыделите его подмножество, элементами которого являются {writeType} числа";
        }

        public SubSetConditionTaskGenerator(ISetWriter setWriter, ITaskGenerator<SubSetTask> taskGenerator) : base(setWriter, taskGenerator)
        {
        }
    }
}