using System.Linq;
using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks
{
    public class CharacteristicPropertyTextTaskGenerator: TextTaskGenerator<CharacteristicPropertyTask>
    {
        public override ITextTask Generate()
        {
            var task = GetTask();
            var answer = task.Answer;
            var writeSet = WriteSet(answer);
            var textTask = $"Дано множество {writeSet}." +
                           $"\nУкажите его характеристическое свойство.";

            var variants = task.Variants.Select(WriteCharacteristicProperty).ToList();
            var answerText =  $"{task.Variants.IndexOf(task.Answer) + 1}";
            return new VariantsTextTask(textTask, answerText, variants);
        }
        
        public CharacteristicPropertyTextTaskGenerator(ISetWriter setWriter, ITaskGenerator<CharacteristicPropertyTask> taskGenerator) 
            : base(setWriter, taskGenerator)
        {
        }
    }
}