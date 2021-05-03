using System.Linq;
using TaskEngine.Generators.Tasks.Elements;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class NumberBelongBorderedSetTextTaskGenerator: ITextTaskGenerator
    {
        private readonly NumberBelongBorderedSetTaskGenerator _taskGenerator;
        private readonly ISetWriter _setWriter;

        public NumberBelongBorderedSetTextTaskGenerator(ISetWriter setWriter, NumberBelongBorderedSetTaskGenerator taskGenerator)
        {
            _taskGenerator = taskGenerator;
            _setWriter = setWriter;
        }

        public string Id => TaskIds.NumberBelongsBorderedSetTask;
        public ITextTask Generate()
        {
            var task = _taskGenerator.Generate();
            var writtenSet = _setWriter.Write(task.Set);
            var answer = (task.Variants.IndexOf(task.RightAnswer) + 1).ToString();

            var variants = task.Variants.Select(v => v.ToString());
            var writtenTask = $"Выберите элемент, принадлежащий множеству {writtenSet}:";

            return new VariantsTextTask(writtenTask, answer, variants);
        }
    }
}