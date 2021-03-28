using TaskEngine.Tasks;

namespace TaskEngine.Writers.Tasks
{
    public class SubSetTaskWriter: ITaskWriter<SubSetTask>
    {
        private readonly ISetWriter _setWriter;

        public SubSetTaskWriter(ISetWriter setWriter)
        {
            _setWriter = setWriter;
        }

        public string WriteTask(SubSetTask task)
        {
            var writeSet = _setWriter.Write(task.TaskSet);
            var writeType = SubSetTypeHelper.GetNumbersType(task.TypeTask);
            var result = $"Дано множество {writeSet}." +
                         $"\nВыделите его подмножество, элементами которого являются {writeType} числа";
            return result;
        }

        public string WriteAnswer(SubSetTask task)
        {
            return _setWriter.Write(task.AnswerSet, false);
        }
    }
}