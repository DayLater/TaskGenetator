using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers.Tasks
{
    public class SubSetTaskWriter: ITaskWriter<SubSetTask>
    {
        private readonly ISetWriter _setWriter;

        public SubSetTaskWriter(ISetWriter setWriter)
        {
            _setWriter = setWriter;
        }

        public ITextTask WriteTask(SubSetTask task)
        {
            var writeSet = _setWriter.Write(task.TaskSet);
            var writeType = SubSetTypeHelper.GetNumbersType(task.TypeTask);
            var textTask = $"Дано множество {writeSet}." +
                         $"\nВыделите его подмножество, элементами которого являются {writeType} числа";

            var answer = WriteAnswer(task);
            return new TextTask(textTask, answer);
        }

        private string WriteAnswer(SubSetTask task)
        {
            return _setWriter.Write(task.TaskSet, false);
        }
    }
}