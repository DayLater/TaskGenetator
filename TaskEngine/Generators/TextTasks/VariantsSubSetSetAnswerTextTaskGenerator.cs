using System.Linq;
using TaskEngine.Generators.Tasks;
using TaskEngine.Helpers;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks
{
    public class VariantsSubSetSetAnswerTextTaskGenerator: SetAnswerTextTaskGenerator<VariantsSetAnswerSubSetTask>
    {
        private readonly ISetWriter _setWriter;
        private readonly VariantsSubSetTaskGenerator _taskGenerator;

        public VariantsSubSetSetAnswerTextTaskGenerator(ISetWriter setWriter, VariantsSubSetTaskGenerator taskGenerator)
        {
            _setWriter = setWriter;
            _taskGenerator = taskGenerator;
        }

        public override ITextTask Generate()
        {
            var task = _taskGenerator.Generate();
            var set = _setWriter.Write(task.Set);
            var type = SubSetTypeHelper.GetNumbersType(task.Type);
            var textTask = $"Дано множество {set}." +
                           $"\nУкажите его подмножество, элементами которого являются все его {type} числа";
            
            var variants = task.Variants.Select(variant => _setWriter.Write(variant, false)).ToList();
            var answer = WriteAnswer(task);
            return new VariantsTextTask(textTask, answer, variants);
        }
    }
}