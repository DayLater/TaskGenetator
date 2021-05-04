using System.Linq;
using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class SetContainsElementsTextTaskGenerator: TextTaskGenerator<SetContainElementsTask>
    {
        public SetContainsElementsTextTaskGenerator(ISetWriter setWriter, ITaskGenerator<SetContainElementsTask> taskGenerator) : base(setWriter, taskGenerator)
        {
        }

        public override ITextTask Generate()
        {
            var task = GetTask();
            var elements = task.Elements;
            
            string writtenTask;
            if (elements.Count == 1)
                writtenTask = $"Выберите множество, в котором присутствует элемент {elements[0]}";
            else
            {
                var writtenElements = elements.Aggregate("", (s, i) => $"{i}, ");
                writtenElements = writtenElements.Remove(writtenElements.Length - 2, 2);
                writtenTask = $"Выберите множество, в котором присутствуеют элементы: {writtenElements}";
            }

            var variants = task.Variants.Select(s => WriteSet(s, false)).ToList();
            var answer = task.Answer.Select(a => (task.Variants.IndexOf(a) + 1).ToString()).Aggregate("", (s, s1) => $"{s}, ");
            answer = answer.Remove(answer.Length - 2, 2);

            return new VariantsTextTask(writtenTask, answer, variants);
        }
    }
}