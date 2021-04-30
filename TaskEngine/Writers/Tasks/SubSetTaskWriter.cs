using TaskEngine.Helpers;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers.Tasks
{
    public class SubSetTaskWriter: ITaskWriter<SubSetSetAnswerTask>
    {
        private readonly ISetWriter _setWriter;

        public SubSetTaskWriter(ISetWriter setWriter)
        {
            _setWriter = setWriter;
        }

        public ITextTask WriteTask(SubSetSetAnswerTask setAnswerTask)
        {
            var writeSet = _setWriter.Write(setAnswerTask.TaskSet);
            var writeType = SubSetTypeHelper.GetNumbersType(setAnswerTask.TypeTask);
            var textTask = $"Дано множество {writeSet}." +
                         $"\nВыделите его подмножество, элементами которого являются {writeType} числа";

            var answer = WriteAnswer(setAnswerTask);
            return new TextTask(textTask, answer);
        }

        private string WriteAnswer(SubSetSetAnswerTask setAnswerTask)
        {
            return _setWriter.Write(setAnswerTask.TaskSet, false);
        }
    }
}