using TaskEngine.Tasks;

namespace TaskEngine.Writers.Tasks
{
    public class CharacteristicPropertyTaskWriter: ITaskWriter<CharacteristicPropertyTask>
    {
        private readonly ISetWriter _setWriter = new SetWriter(new ExpressionWriter(), 6);
        
        public string WriteTask(CharacteristicPropertyTask task)
        {
            var rightSet = task.Sets[task.RightAnswerIndex];
            var writeSet = _setWriter.Write(rightSet);
            var result = $"Дано множество {writeSet}." +
                         $"\nУкажите его характеристическое свойство.";
            
            foreach (var set in task.Sets)
            {
                var variant = _setWriter.WriteCharacteristicProperty(set.Value);
                result += $"\n {set.Key}) {variant}";
            }

            return result;
        }

        public string WriteAnswer(CharacteristicPropertyTask task)
        {
            return task.RightAnswerIndex.ToString();
        }
    }
}