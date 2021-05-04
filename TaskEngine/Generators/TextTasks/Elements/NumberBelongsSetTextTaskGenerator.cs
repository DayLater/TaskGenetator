using System.Linq;
using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class NumberBelongsSetTextTaskGenerator: TextTaskGenerator<NumberBelongsSetTask>
    {
        public NumberBelongsSetTextTaskGenerator(ISetWriter setWriter, ITaskGenerator<NumberBelongsSetTask> taskGenerator)
            : base(setWriter, taskGenerator) { }

        public override ITextTask Generate()
        {
            var task = GetTask();
            var writtenSet = WriteSet(task.Set);
            var answerIndex = task.Variants.IndexOf(task.RightAnswer);
            var answer = (answerIndex + 1).ToString();
            var variants = task.Variants.Select(v => v.ToString());
            var writtenTask = $"Выберите элемент, принадлежащий множеству {writtenSet}: ";
            return new VariantsTextTask(writtenTask, answer, variants);
        }
    }
}