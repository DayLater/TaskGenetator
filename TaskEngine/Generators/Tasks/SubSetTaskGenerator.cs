using System.Linq;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Helpers;
using TaskEngine.Sets;
using TaskEngine.Tasks;

namespace TaskEngine.Generators.Tasks
{
    public class SubSetTaskGenerator: ITaskGenerator<SubSetTask>
    {
        private readonly MathSetGenerator _generator;

        public SubSetTaskGenerator(MathSetGenerator generator)
        {
            _generator = generator;
        }

        public SubSetTask Generate()
        {
            var set = _generator.Generate();
            var type = SubSetTypeHelper.GetRandomSubSetType();

            var createdFunc = SubSetTypeHelper.GetTypeFunc(type);
            var elements = set.GetElements().Where(e => createdFunc.Invoke(e)).ToList();
            var name = Symbols.GetRandomName();
            var answerSet = new MathSet<int>(name, elements);

            var task = new SubSetTask(set, type, answerSet);
            return task;
        }
    }
}