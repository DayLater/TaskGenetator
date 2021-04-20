using System.Linq;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers.Tasks
{
    public class CharacteristicPropertyTaskWriter: TaskWriter<CharacteristicPropertyTask>
    {
        private readonly ISetWriter _setWriter;

        public CharacteristicPropertyTaskWriter(ISetWriter setWriter)
        {
            _setWriter = setWriter;
        }

        public override ITextTask WriteTask(CharacteristicPropertyTask task)
        {
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