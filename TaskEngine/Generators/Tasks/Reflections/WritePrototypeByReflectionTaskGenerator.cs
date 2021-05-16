using System;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.Reflections
{
    public class WritePrototypeByReflectionTaskGenerator: TaskGenerator
    {
        private readonly PrototypeByReflectionTaskGenerator _prototypeByReflectionTaskGenerator;
        
        public WritePrototypeByReflectionTaskGenerator(ISetWriter setWriter, Random random, ISetGenerator<int> setGenerator) : base(TaskIds.WritePrototypeFormByReflection, setWriter)
        {
            _prototypeByReflectionTaskGenerator = new PrototypeByReflectionTaskGenerator(random, setGenerator, setWriter);
            Add(_prototypeByReflectionTaskGenerator);
        }

        public override ITask Generate()
        {
            var (set, reflection, endSet) = _prototypeByReflectionTaskGenerator.Generate();
            var condition = _prototypeByReflectionTaskGenerator.CreateCondition(endSet, reflection, false);
            return new AnswerTask<IMathSet<int>>(set, condition);
        }
    }
}