using System.Linq;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers.Tasks
{
    public class CharacteristicPropertyTaskWriter: TaskWriter<CharacteristicPropertySetAnswerTask>
    {
        private readonly ISetWriter _setWriter;

        public CharacteristicPropertyTaskWriter(ISetWriter setWriter)
        {
            _setWriter = setWriter;
        }

        public override ITextTask WriteTask(CharacteristicPropertySetAnswerTask setAnswerTask)
        {
            var answer = setAnswerTask.RightAnswer;
            var writeSet = _setWriter.Write(answer);
            
            var textTask = $"Дано множество {writeSet}." +
                           $"\nУкажите его характеристическое свойство.";

            var variants = setAnswerTask.Variants
                .Select(set => _setWriter.WriteCharacteristicProperty(set))
                .ToList();

            var answerText = WriteAnswer(setAnswerTask);
            return new VariantsTextTask(textTask, answerText, variants);
        }
    }
}