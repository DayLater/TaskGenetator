using System;
using TaskEngine.Sets;
using TaskEngine.Tasks;

namespace TaskEngine.Writers.Tasks
{
    public class TestableSubSetTaskWriter: ITaskWriter<TestableSubSetTask>
    {
        private readonly ISetWriter _setWriter;

        public TestableSubSetTaskWriter(ISetWriter setWriter)
        {
            _setWriter = setWriter;
        }

        public string WriteTask(TestableSubSetTask task)
        {
            var set = _setWriter.Write(task.Set);
            var type = SubSetTypeHelper.GetNumbersType(task.Type);
            var result = $"Дано множество {set}." +
                         $"\nУкажите его подмножество, элементами которого являются все его {type} числа";

            foreach (var variant in task.Variants)
            {
                var writtenVariant = _setWriter.Write(variant.Value, false);
                result += $"\n{variant.Key}) {writtenVariant}";
            }

            return result;
        }
        
        public string WriteAnswer(TestableSubSetTask task)
        {
            throw new System.NotImplementedException();
        }
    }
}