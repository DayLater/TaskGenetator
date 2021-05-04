using System.Linq;
using TaskEngine.Generators.Tasks;
using TaskEngine.Helpers;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks
{
    public class BorderSetOperationTextTaskGenerator: TextTaskGenerator<BorderSetOperationSetAnswerTask>
    {
        public BorderSetOperationTextTaskGenerator(ISetWriter setWriter, ITaskGenerator<BorderSetOperationSetAnswerTask> taskGenerator)
            : base(setWriter, taskGenerator) { }

        public override ITextTask Generate()
        {
            var task = GetTask();
            var firstName = task.First.Name;
            var secondName = task.Second.Name;
            var firstSet = WriteSet(task.First);
            var secondSet = WriteSet(task.Second);
            var operation = SetOperationHelper.GetString(task.Operation);
            
            var textTask = $"Найдите {operation} множеств {firstName} и {secondName}, если: {firstSet}, {secondSet}";
            var variants = task.Variants
                .Select(variant => $"{WriteSet(variant, false)}")
                .ToList();
            
            var rightAnswer = WriteAnswer(task);
            return new VariantsTextTask(textTask, rightAnswer, variants);
        }
        
        private string WriteAnswer(BorderSetOperationSetAnswerTask setAnswerTask)
        {
            var index = setAnswerTask.Variants.IndexOf(setAnswerTask.RightAnswer) + 1;
            var set = WriteSet(setAnswerTask.RightAnswer, false);

            return $"{index}) {set}";
        }


    }
}