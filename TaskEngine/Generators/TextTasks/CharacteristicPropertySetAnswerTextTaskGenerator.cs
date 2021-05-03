using System.Linq;
using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks
{
    public class CharacteristicPropertySetAnswerTextTaskGenerator: SetAnswerTextTaskGenerator<CharacteristicPropertySetAnswerTask>
    {
        private readonly ISetWriter _setWriter;
        private readonly CharacteristicPropertyTaskGenerator _taskGenerator;

        public CharacteristicPropertySetAnswerTextTaskGenerator(ISetWriter setWriter, CharacteristicPropertyTaskGenerator taskGenerator)
        {
            _setWriter = setWriter;
            _taskGenerator = taskGenerator;
        }
        
        public override ITextTask Generate()
        {
            var task = _taskGenerator.Generate();
            var answer = task.RightAnswer;
            var writeSet = _setWriter.Write(answer);
            
            var textTask = $"Дано множество {writeSet}." +
                           $"\nУкажите его характеристическое свойство.";

            var variants = task.Variants
                .Select(set => _setWriter.WriteCharacteristicProperty(set))
                .ToList();

            var answerText = WriteAnswer(task);
            return new VariantsTextTask(textTask, answerText, variants);
        }
    }
}