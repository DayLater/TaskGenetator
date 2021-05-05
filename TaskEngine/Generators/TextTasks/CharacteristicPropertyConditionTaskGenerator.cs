using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks
{
    public class CharacteristicPropertyConditionTaskGenerator: ConditionTaskGenerator<VariantsCharacteristicPropertyTask>
    {
        public override (ITask, string) Generate()
        {
            var task = GetTask();
            var writeSet = WriteSet(task.Answers[0]);
            var textTask = $"Дано множество {writeSet}.\nУкажите его характеристическое свойство.";
            return (task, textTask);
        }
        
        public CharacteristicPropertyConditionTaskGenerator(ISetWriter setWriter, ITaskGenerator<VariantsCharacteristicPropertyTask> taskGenerator) 
            : base(setWriter, taskGenerator)
        {
        }
    }
}