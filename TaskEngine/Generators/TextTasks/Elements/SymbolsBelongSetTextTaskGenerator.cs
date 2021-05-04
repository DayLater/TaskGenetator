using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class SymbolsBelongSetTextTaskGenerator: TextTaskGenerator<SymbolsBelongSetTask>
    {
        public SymbolsBelongSetTextTaskGenerator(ISetWriter setWriter, ITaskGenerator<SymbolsBelongSetTask> taskGenerator) 
            : base(setWriter, taskGenerator) { }

        public override ITextTask Generate()
        {
            var task = GetTask();
            var writtenSet = WriteSet(task.Set);
            var answer = task.Answers.Select(a => task.Variants.IndexOf(a) + 1).GetStringRepresentation();
            var writtenTask = $"Выберите все элементы, принадлежащий множеству {writtenSet}";
            return new VariantsTextTask(writtenTask, answer, task.Variants);
        }
    }
}