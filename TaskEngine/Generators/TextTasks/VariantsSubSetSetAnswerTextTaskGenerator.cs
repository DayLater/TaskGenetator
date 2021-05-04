using System.Linq;
using TaskEngine.Generators.Tasks;
using TaskEngine.Helpers;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks
{
    public class VariantsSubSetSetAnswerTextTaskGenerator: TextTaskGenerator<VariantsSetAnswerSubSetTask>
    {
        public override ITextTask Generate()
        {
            var task = GetTask();
            var set = WriteSet(task.Set);
            var type = SubSetTypeHelper.GetNumbersType(task.Type);
            var textTask = $"Дано множество {set}." +
                           $"\nУкажите его подмножество, элементами которого являются все его {type} числа";
            
            var variants = task.Variants.Select(variant => WriteSet(variant, false)).ToList();
            var answer = WriteAnswer(task);
            return new VariantsTextTask(textTask, answer, variants);
        }

        private string WriteAnswer<T>(IVariantsSetAnswerTask<T> variantsSetAnswerTask)
        {
            var rightAnswerIndex = variantsSetAnswerTask.Variants.IndexOf(variantsSetAnswerTask.RightAnswer);
            return $"{rightAnswerIndex + 1}";
        }

        public VariantsSubSetSetAnswerTextTaskGenerator(ISetWriter setWriter, ITaskGenerator<VariantsSetAnswerSubSetTask> taskGenerator) 
            : base(setWriter, taskGenerator) { }
    }
}