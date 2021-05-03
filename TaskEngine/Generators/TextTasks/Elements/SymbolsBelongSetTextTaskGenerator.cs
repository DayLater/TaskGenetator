using System.Linq;
using TaskEngine.Generators.Tasks.Elements;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class SymbolsBelongSetTextTaskGenerator: ITextTaskGenerator
    {
        private readonly SymbolsBelongSetTaskGenerator _taskGenerator;
        private readonly ISetWriter _setWriter;

        public SymbolsBelongSetTextTaskGenerator(ISetWriter setWriter, SymbolsBelongSetTaskGenerator taskGenerator)
        {
            _taskGenerator = taskGenerator;
            _setWriter = setWriter;
        }

        public string Id => TaskIds.SymbolsBelongSetTask;
        
        public ITextTask Generate()
        {
            var task = _taskGenerator.Generate();
            var writtenSet = _setWriter.Write(task.Set);
            var answerIndexes = task.Answers.Where(a => task.Variants.Contains(a)).Select(a => task.Variants.IndexOf(a) + 1);
            
            var answer = "";
            foreach (var index in answerIndexes)
                answer += $"{index}, ";
            answer = answer.Remove(answer.Length - 2, 2);
            
            var writtenTask = $"Выберите элемент, принадлежащий множеству {writtenSet}.";
            return new VariantsTextTask(writtenTask, answer, task.Variants);
        }
    }
}