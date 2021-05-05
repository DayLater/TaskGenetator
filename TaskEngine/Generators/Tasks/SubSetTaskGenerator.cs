using System;
using System.Linq;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Helpers;
using TaskEngine.Sets;
using TaskEngine.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks
{
    public class SubSetTaskGenerator: TaskGenerator
    {
        private readonly Random _random;
        private readonly IntMathSetGenerator _setGenerator;

        public SubSetTaskGenerator(Random random, ISetWriter setWriter): base(TaskIds.SubSetTask, setWriter)
        {
            _random = random;
            _setGenerator = new IntMathSetGenerator(random);
            Add(_setGenerator);
        }

        public override ITask Generate()
        {
            var set = _setGenerator.Generate();
            var type = SubSetTypeHelper.GetRandomSubSetType();

            var createdFunc = SubSetTypeHelper.GetTypeFunc(type);
            var elements = set.GetElements().Where(e => createdFunc.Invoke(e)).ToList();
            var name = Symbols.GetRandomName(_random);
            var answerSet = new MathSet<int>(name, elements);

            var condition = GetCondition(set, type);
            var task = new SubSetTask(answerSet, condition, type, set);
            return task;
        }

        private string GetCondition<T>(IMathSet<T> set, SubSetType setType)
        {
            var writeSet = WriteSet(set);
            var writeType = SubSetTypeHelper.GetNumbersType(setType);
            return $"Дано множество {writeSet}.\nВыделите его подмножество, элементами которого являются {writeType} числа";
        }
    }
}