using System.Linq;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Helpers;
using TaskEngine.Sets;
using TaskEngine.Tasks;

namespace TaskEngine.Generators.Tasks
{
    public class SubSetTaskGenerator: Generator, ITaskGenerator<SubSetSetAnswerTask>
    {
        private readonly IntMathSetGenerator _setGenerator;

        public SubSetTaskGenerator(IntMathSetGenerator setGenerator)
        {

            _setGenerator = setGenerator;
            Add(_setGenerator);
        }

        public string Id => TaskIds.SubSetTask;

        public SubSetSetAnswerTask Generate()
        {
            var set = _setGenerator.Generate();
            var type = SubSetTypeHelper.GetRandomSubSetType();

            var createdFunc = SubSetTypeHelper.GetTypeFunc(type);
            var elements = set.GetElements().Where(e => createdFunc.Invoke(e)).ToList();
            var name = Symbols.GetRandomName();
            var answerSet = new MathSet<int>(name, elements);

            var task = new SubSetSetAnswerTask(set, type, answerSet);
            return task;
        }
    }
}