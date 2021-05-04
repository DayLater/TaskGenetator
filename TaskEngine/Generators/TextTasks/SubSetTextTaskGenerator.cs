using TaskEngine.Generators.Tasks;
using TaskEngine.Helpers;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks
{
    public class SubSetTextTaskGenerator: TextTaskGenerator<SubSetTask>
    {
        private string WriteAnswer(SubSetTask setAnswerTask)
        {
            return WriteSet(setAnswerTask.TaskSet, false);
        }
        
        public override ITextTask Generate()
        {
            var task = GetTask();
            var writeSet = WriteSet(task.TaskSet);
            var writeType = SubSetTypeHelper.GetNumbersType(task.TypeTask);
            var textTask = $"Дано множество {writeSet}." +
                           $"\nВыделите его подмножество, элементами которого являются {writeType} числа";

            var answer = WriteAnswer(task);
            return new TextTask(textTask, answer);
        }

        public SubSetTextTaskGenerator(ISetWriter setWriter, ITaskGenerator<SubSetTask> taskGenerator) : base(setWriter, taskGenerator)
        {
        }
    }
}