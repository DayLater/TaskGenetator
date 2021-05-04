using TaskEngine.Generators.Tasks.Elements;
using TaskEngine.Tasks.Elements;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class SymbolBelongsSetTextTaskGenerator: TextTaskGenerator<SymbolBelongsSetTask>
    {
        public SymbolBelongsSetTextTaskGenerator(ISetWriter setWriter, SymbolBelongsSetTaskGenerator taskGenerator)
            : base(setWriter, taskGenerator) { }

        public override ITextTask Generate()
        {
            var task = GetTask();
            var writtenSet = WriteSet(task.Set);
            var answerIndex = task.Variants.IndexOf(task.Answer);
            var answer = (answerIndex + 1).ToString();
            var writtenTask = $"Выберите элемент, принадлежащий множеству {writtenSet}.";
            return new VariantsTextTask(writtenTask, answer, task.Variants);
        }
    }
}