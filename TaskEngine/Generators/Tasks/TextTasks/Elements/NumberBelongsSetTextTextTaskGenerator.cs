using System.Linq;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.TextTasks.Elements
{
    public class NumberBelongsSetTextTextTaskGenerator: ITextTaskGenerator
    {
        private readonly ISetWriter _setWriter;
        private readonly NumberBelongsSetTaskGenerator _taskGenerator;

        public NumberBelongsSetTextTextTaskGenerator(ISetWriter setWriter, NumberBelongsSetTaskGenerator taskGenerator)
        {
            _setWriter = setWriter;
            _taskGenerator = taskGenerator;
        }
        
        public ITextTask Generate()
        {
            var task = _taskGenerator.Generate();
            var writtenSet = _setWriter.Write(task.TaskSet);
            var answerIndex = task.Variants.IndexOf(task.RightAnswer);
            var answer = (answerIndex + 1).ToString();
            var variants = task.Variants.Select(v => v.ToString());
            var writtenTask = $"Выберите элемент, принадлежащий множеству {writtenSet}: ";
            return new VariantsTextTask(writtenTask, answer, variants);
        }
    }
}