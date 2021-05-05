using System;
using System.Linq;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Helpers;
using TaskEngine.Sets;
using TaskEngine.Tasks;

namespace TaskEngine.Generators.Tasks
{
    public class SubSetTaskGenerator: Generator, ITaskGenerator<SubSetTask>
    {
        private readonly Random _random;
        private readonly IntMathSetGenerator _setGenerator;

        public SubSetTaskGenerator(Random random)
        {
            _random = random;
            _setGenerator = new IntMathSetGenerator(random);
            Add(_setGenerator);
        }

        public string Id => TaskIds.SubSetTask;

        public SubSetTask Generate()
        {
            var set = _setGenerator.Generate();
            var type = SubSetTypeHelper.GetRandomSubSetType();

            var createdFunc = SubSetTypeHelper.GetTypeFunc(type);
            var elements = set.GetElements().Where(e => createdFunc.Invoke(e)).ToList();
            var name = Symbols.GetRandomName(_random);
            var answerSet = new MathSet<int>(name, elements);

            var task = new SubSetTask(answerSet, type, answerSet);
            return task;
        }
    }
}