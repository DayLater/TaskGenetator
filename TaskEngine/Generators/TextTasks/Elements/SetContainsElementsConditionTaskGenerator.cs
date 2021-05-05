using TaskEngine.Extensions;
using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class SetContainsElementsConditionTaskGenerator: ConditionTaskGenerator<SetContainElementsTask>
    {
        public SetContainsElementsConditionTaskGenerator(ISetWriter setWriter, ITaskGenerator<SetContainElementsTask> taskGenerator) 
            : base(setWriter, taskGenerator) { }

        protected override string GetCondition(SetContainElementsTask task)
        { 
            var elements = task.Elements;
            return  elements.Count == 1 ? $"Выберите множество, в котором присутствует элемент {elements[0]}" 
                : $"Выберите множество, в котором присутствуеют элементы: {elements.GetStringRepresentation()}";
        }
    }
}