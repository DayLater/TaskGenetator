using TaskEngine.Generators.Tasks.Elements;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class SymbolBelongsSetTextTaskGenerator: ITextTaskGenerator
    {
        private readonly SymbolBelongToSetTaskGenerator _taskGenerator;
        private readonly ISetWriter _setWriter;

        public SymbolBelongsSetTextTaskGenerator(ISetWriter setWriter, SymbolBelongToSetTaskGenerator taskGenerator)
        {
            _taskGenerator = taskGenerator;
            _setWriter = setWriter;
        }

        public string Id => TaskIds.SymbolBelongsSetTask;

        public ITextTask Generate()
        {
            var task = _taskGenerator.Generate();
            var writtenSet = _setWriter.Write(task.Set);
            var answerIndex = task.Variants.IndexOf(task.Answer);
            var answer = (answerIndex + 1).ToString();
            var writtenTask = $"Выберите элемент, принадлежащий множеству {writtenSet}.";
            return new VariantsTextTask(writtenTask, answer, task.Variants);
        }
    }
}