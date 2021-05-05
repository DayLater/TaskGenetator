using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks
{
    public class CharacteristicPropertyConditionTaskGenerator: ConditionTaskGenerator<VariantsCharacteristicPropertyTask>
    {
        protected override string GetCondition(VariantsCharacteristicPropertyTask task)
        {
            var writeSet = WriteSet(task.Answers[0]);
            return $"Дано множество {writeSet}.\nУкажите его характеристическое свойство.";
        }

        public CharacteristicPropertyConditionTaskGenerator(ISetWriter setWriter, ITaskGenerator<VariantsCharacteristicPropertyTask> taskGenerator) 
            : base(setWriter, taskGenerator)
        {
        }
    }
}