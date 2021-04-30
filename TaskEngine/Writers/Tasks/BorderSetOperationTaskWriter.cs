using System.Linq;
using TaskEngine.Helpers;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers.Tasks
{
    public class BorderSetOperationTaskWriter: ITaskWriter<BorderSetOperationSetAnswerTask>
    {
        private readonly ISetWriter _setWriter;

        public BorderSetOperationTaskWriter(ISetWriter setWriter)
        {
            _setWriter = setWriter;
        }

        public ITextTask WriteTask(BorderSetOperationSetAnswerTask setAnswerTask)
        {
            var firstName = setAnswerTask.First.Name;
            var secondName = setAnswerTask.Second.Name;
            var firstSet = _setWriter.Write(setAnswerTask.First);
            var secondSet = _setWriter.Write(setAnswerTask.Second);
            var operation = SetOperationHelper.GetString(setAnswerTask.Operation);
            
            var textTask = $"Найдите {operation} множеств {firstName} и {secondName}, если: {firstSet}, {secondSet}";
            var variants = setAnswerTask.Variants
                .Select(variant => $"{_setWriter.Write(variant, false)}")
                .ToList();
            
            var rightAnswer = WriteAnswer(setAnswerTask);
            return new VariantsTextTask(textTask, rightAnswer, variants);
        }

        public string WriteAnswer(BorderSetOperationSetAnswerTask setAnswerTask)
        {
            var index = setAnswerTask.Variants.IndexOf(setAnswerTask.RightAnswer) + 1;
            var set = _setWriter.Write(setAnswerTask.RightAnswer, false);

            return $"{index}) {set}";
        }
    }
}