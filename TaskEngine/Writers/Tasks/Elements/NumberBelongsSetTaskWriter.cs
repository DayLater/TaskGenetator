using System.Linq;
using TaskEngine.Tasks.Elements;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers.Tasks.Elements
{
    public class NumberBelongsSetTaskWriter: ITaskWriter<NumberBelongsSetSetAnswerTask>
    {
        private readonly ISetWriter _setWriter;

        public NumberBelongsSetTaskWriter(ISetWriter setWriter)
        {
            _setWriter = setWriter;
        }

        public ITextTask WriteTask(NumberBelongsSetSetAnswerTask task)
        {
            var writtenSet = _setWriter.Write(task.TaskSet);
            var answerIndex = task.Variants.IndexOf(task.RightAnswer);
            var answer = (answerIndex + 1).ToString();
            var variants = task.Variants.Select(v => v.ToString());
            var writtenTask = $"Выберите элемент, принадлежащий множеству {writtenSet}: ";
            return new VariantsTextTask(writtenTask, answer, variants);
        }
    }
}