using System.Linq;
using TaskEngine.Helpers;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.TextTasks
{
    public class BorderSetOperationTextTaskGenerator: ITextTaskGenerator
    {
        private readonly ISetWriter _setWriter;
        private readonly BorderSetOperationTaskGenerator _taskGenerator;

        public BorderSetOperationTextTaskGenerator(ISetWriter setWriter, BorderSetOperationTaskGenerator taskGenerator)
        {
            _setWriter = setWriter;
            _taskGenerator = taskGenerator;
        }
        
        public ITextTask Generate()
        {
            var task = _taskGenerator.Generate();
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
        
        private string WriteAnswer(BorderSetOperationSetAnswerTask setAnswerTask)
        {
            var index = setAnswerTask.Variants.IndexOf(setAnswerTask.RightAnswer) + 1;
            var set = _setWriter.Write(setAnswerTask.RightAnswer, false);

            return $"{index}) {set}";
        }
    }
}