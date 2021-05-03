using System.Linq;
using TaskEngine.Generators.Tasks.Elements;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class NumberBelongsSetTextTaskGenerator: ITextTaskGenerator
    {
        private readonly ISetWriter _setWriter;
        private readonly NumberBelongsSetTaskGenerator _taskGenerator;

        public NumberBelongsSetTextTaskGenerator(ISetWriter setWriter, NumberBelongsSetTaskGenerator taskGenerator)
        {
            _setWriter = setWriter;
            _taskGenerator = taskGenerator;
        }

        public string Id => TaskIds.NumberBelongsSetTask;

        public ITextTask Generate()
        {
            var task = _taskGenerator.Generate();
            var writtenSet = _setWriter.Write(task.Set);
            var answerIndex = task.Variants.IndexOf(task.RightAnswer);
            var answer = (answerIndex + 1).ToString();
            var variants = task.Variants.Select(v => v.ToString());
            var writtenTask = $"Выберите элемент, принадлежащий множеству {writtenSet}: ";
            return new VariantsTextTask(writtenTask, answer, variants);
        }
    }
}