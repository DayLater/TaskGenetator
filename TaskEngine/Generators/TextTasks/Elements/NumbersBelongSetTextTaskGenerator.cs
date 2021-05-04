using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class NumbersBelongSetTextTaskGenerator: TextTaskGenerator<NumbersBelongSetTask>
    {
        public NumbersBelongSetTextTaskGenerator(ISetWriter setWriter, ITaskGenerator<NumbersBelongSetTask> taskGenerator) 
            : base(setWriter, taskGenerator) { }

        public override ITextTask Generate()
        {
            var task = GetTask();
            var writtenSet = WriteSet(task.TaskSet);
            var answer = task.Answers.Select(v => task.Variants.IndexOf(v) + 1).GetStringRepresentation();
            var variants = task.Variants.Select(v => v.ToString());
            var writtenTask = $"Выберите все элементы, принадлежащие множеству {writtenSet}";
            return new VariantsTextTask(writtenTask, answer, variants);
        }
    }
}