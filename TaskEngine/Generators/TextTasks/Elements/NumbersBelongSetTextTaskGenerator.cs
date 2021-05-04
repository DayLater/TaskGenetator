using System.Linq;
using TaskEngine.Generators.Tasks.Elements;
using TaskEngine.Tasks.Elements;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class NumbersBelongSetTextTaskGenerator: TextTaskGenerator<NumbersBelongSetTask>
    {
        public NumbersBelongSetTextTaskGenerator(ISetWriter setWriter, NumbersBelongSetTaskGenerator taskGenerator) 
            : base(setWriter, taskGenerator) { }

        public override ITextTask Generate()
        {
            var task = GetTask();
            var writtenSet = WriteSet(task.TaskSet);
            var answerIndexes = task.Answers.Select(v => task.Variants.IndexOf(v) + 1);
            
            var answer = "";
            foreach (var answerIndex in answerIndexes)
                answer += $"{answerIndex + 1}, ";
            answer = answer.Remove(answer.Length - 2, 2);
            
            var variants = task.Variants.Select(v => v.ToString());
            var writtenTask = $"Выберите все элементы, принадлежащие множеству {writtenSet}";
            
            return new VariantsTextTask(writtenTask, answer, variants);
        }
    }
}