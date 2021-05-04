using System.Linq;
using TaskEngine.Generators.Tasks;
using TaskEngine.Helpers;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks
{
    public class VariantsSubSetSetAnswerTextTaskGenerator: TextTaskGenerator<VariantsSubSetTask>
    {
        public override ITextTask Generate()
        {
            var task = GetTask();
            var set = WriteSet(task.Set);
            var type = SubSetTypeHelper.GetNumbersType(task.Type);
            var textTask = $"Дано множество {set}." +
                           $"\nУкажите его подмножество, элементами которого являются все его {type} числа";
            
            var variants = task.Variants.Select(variant => WriteSet(variant, false)).ToList();
            var answer = $"{task.Variants.IndexOf(task.Answer) + 1}";
            return new VariantsTextTask(textTask, answer, variants);
        }
        
        public VariantsSubSetSetAnswerTextTaskGenerator(ISetWriter setWriter, ITaskGenerator<VariantsSubSetTask> taskGenerator) 
            : base(setWriter, taskGenerator) { }
    }
}