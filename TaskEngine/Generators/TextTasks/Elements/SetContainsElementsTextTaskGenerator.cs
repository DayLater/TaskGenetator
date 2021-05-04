using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class SetContainsElementsTextTaskGenerator: TextTaskGenerator<SetContainElementsTask>
    {
        public SetContainsElementsTextTaskGenerator(ISetWriter setWriter, ITaskGenerator<SetContainElementsTask> taskGenerator) 
            : base(setWriter, taskGenerator) { }

        public override ITextTask Generate()
        {
            var task = GetTask();
            var elements = task.Elements;
            var writtenTask = elements.Count == 1 ? $"Выберите множество, в котором присутствует элемент {elements[0]}" 
                : $"Выберите множество, в котором присутствуеют элементы: {elements.GetStringRepresentation()}";

            var variants = task.Variants.Select(s => WriteSet(s, false)).ToList();
            var answer = task.Answer.Select(a => task.Variants.IndexOf(a) + 1).GetStringRepresentation();
            
            return new VariantsTextTask(writtenTask, answer, variants);
        }
    }
}