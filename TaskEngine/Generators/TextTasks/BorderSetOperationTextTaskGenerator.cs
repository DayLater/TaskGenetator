using System.Linq;
using TaskEngine.Generators.Tasks;
using TaskEngine.Helpers;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks
{
    public class BorderSetOperationTextTaskGenerator: TextTaskGenerator<VariantsBorderSetOperationTask>
    {
        public BorderSetOperationTextTaskGenerator(ISetWriter setWriter, ITaskGenerator<VariantsBorderSetOperationTask> taskGenerator)
            : base(setWriter, taskGenerator) { }

        public override ITextTask Generate()
        {
            var task = GetTask();
            var firstSet = WriteSet(task.First);
            var secondSet = WriteSet(task.Second);
            var operation = SetOperationHelper.GetString(task.Operation);
            
            var textTask = $"Найдите {operation} множеств {firstSet} и {secondSet}";
            var variants = task.Variants
                .Select(variant => $"{WriteSet(variant, false)}")
                .ToList();
            
            var rightAnswer = WriteAnswer(task);
            return new VariantsTextTask(textTask, rightAnswer, variants);
        }
        
        private string WriteAnswer(VariantsBorderSetOperationTask setAnswerTask)
        {
            var index = setAnswerTask.Variants.IndexOf(setAnswerTask.Answer) + 1;
            var set = WriteSet(setAnswerTask.Answer, false);

            return $"{index}) {set}";
        }


    }
}