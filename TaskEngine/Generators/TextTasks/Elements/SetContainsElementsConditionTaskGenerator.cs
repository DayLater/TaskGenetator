using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class SetContainsElementsConditionTaskGenerator: ConditionTaskGenerator<SetContainElementsTask>
    {
        public SetContainsElementsConditionTaskGenerator(ISetWriter setWriter, ITaskGenerator<SetContainElementsTask> taskGenerator) 
            : base(setWriter, taskGenerator) { }

        public override (ITask, string) Generate()
        {
            var task = GetTask();
            var elements = task.Elements;
            var writtenTask = elements.Count == 1 ? $"Выберите множество, в котором присутствует элемент {elements[0]}" 
                : $"Выберите множество, в котором присутствуеют элементы: {elements.GetStringRepresentation()}";
            return (task, writtenTask);
        }
    }
}