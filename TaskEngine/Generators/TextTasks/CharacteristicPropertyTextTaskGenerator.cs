using System.Linq;
using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks
{
    public class CharacteristicPropertyTextTaskGenerator: TextTaskGenerator<CharacteristicPropertySetAnswerTask>
    {
        public override ITextTask Generate()
        {
            var task = GetTask();
            var answer = task.RightAnswer;
            var writeSet = WriteSet(answer);
            var textTask = $"Дано множество {writeSet}." +
                           $"\nУкажите его характеристическое свойство.";

            var variants = task.Variants.Select(WriteCharacteristicProperty).ToList();
            var answerText = WriteAnswer(task);
            return new VariantsTextTask(textTask, answerText, variants);
        }

        private string WriteAnswer<T>(IVariantsSetAnswerTask<T> variantsSetAnswerTask)
        {
            var rightAnswerIndex = variantsSetAnswerTask.Variants.IndexOf(variantsSetAnswerTask.RightAnswer);
            return $"{rightAnswerIndex + 1}";
        }

        public CharacteristicPropertyTextTaskGenerator(ISetWriter setWriter, ITaskGenerator<CharacteristicPropertySetAnswerTask> taskGenerator) 
            : base(setWriter, taskGenerator)
        {
        }
    }
}