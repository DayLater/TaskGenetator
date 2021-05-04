using System.Linq;
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