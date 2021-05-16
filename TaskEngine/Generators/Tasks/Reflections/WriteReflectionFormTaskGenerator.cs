using System;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.Reflections
{
    public class WriteReflectionFormTaskGenerator: TaskGenerator
    {
        private readonly ReflectionFormTaskGenerator _reflectionFormTaskGenerator;
        
        public WriteReflectionFormTaskGenerator(ISetWriter setWriter, ISetGenerator<int> setGenerator, Random random) : base(TaskIds.WriteReflectionForm, setWriter)
        {
            _reflectionFormTaskGenerator = new ReflectionFormTaskGenerator(setWriter, setGenerator, random);
            Add(_reflectionFormTaskGenerator);
        }

        public override ITask Generate()
        {
            var (set, reflection, answer) = _reflectionFormTaskGenerator.Generate();
            var condition = _reflectionFormTaskGenerator.GetCondition(false, set, reflection);

            return new AnswerTask<IMathSet<int>>(answer, condition);
        }
    }
}