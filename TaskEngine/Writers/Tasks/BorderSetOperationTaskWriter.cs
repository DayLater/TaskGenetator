using System.Linq;
using TaskEngine.Helpers;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers.Tasks
{
    public class BorderSetOperationTaskWriter: ITaskWriter<BorderSetOperationTask>
    {
        private readonly ISetWriter _setWriter;

        public BorderSetOperationTaskWriter(ISetWriter setWriter)
        {
            _setWriter = setWriter;
        }

        public ITextTask WriteTask(BorderSetOperationTask task)
        {
            var firstName = task.First.Name;
            var secondName = task.Second.Name;
            var firstSet = _setWriter.Write(task.First);
            var secondSet = _setWriter.Write(task.Second);
            var operation = SetOperationHelper.GetString(task.Operation);
            
            var textTask = $"Найдите {operation} множеств {firstName} и {secondName}, если: {firstSet}, {secondSet}";
            var variants = task.Variants
                .Select(variant => $"{_setWriter.Write(variant, false)}")
                .ToList();
            
            var rightAnswer = WriteAnswer(task);
            return new VariantsTextTask(textTask, rightAnswer, variants);
        }

        public string WriteAnswer(BorderSetOperationTask task)
        {
            var index = task.Variants.IndexOf(task.RightAnswer) + 1;
            var set = _setWriter.Write(task.RightAnswer, false);

            return $"{index}) {set}";
        }
    }
}