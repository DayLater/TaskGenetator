using System;
using TaskEngine.Sets;
using TaskEngine.Tasks;

namespace TaskEngine.Writers.Tasks
{
    public class SubSetTaskWriter: ITaskWriter<SubSetTask>
    {
        private readonly ISetWriter _setWriter;

        public SubSetTaskWriter(ISetWriter setWriter)
        {
            _setWriter = setWriter;
        }

        public string WriteTask(SubSetTask task)
        {
            var set = _setWriter.Write(task.Set);
            var type = GetStringType(task.Type);
            var result = $"Дано множество {set}." +
                         $"\nУкажите его подмножество, элементами которого являются все его {type} числа";

            foreach (var variant in task.Variants)
            {
                var writtenVariant = _setWriter.Write(variant.Value, false);
                result += $"\n{variant.Key}) {writtenVariant}";
            }

            return result;
        }

        private string GetStringType(SubSetType type)
        {
            return type switch
            {
                SubSetType.Positive => "положительные",
                SubSetType.NonPositive => "неположительные",
                SubSetType.Negative => "отрицательные",
                SubSetType.NonNegative => "неотрицательные",
                SubSetType.Even => "четные",
                SubSetType.Odd => "нечетные",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
        
        public string WriteAnswer(SubSetTask task)
        {
            throw new System.NotImplementedException();
        }
    }
}