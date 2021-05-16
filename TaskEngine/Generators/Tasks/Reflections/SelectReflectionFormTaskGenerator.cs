using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Comparers;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.Reflections
{
    public class SelectReflectionFormTaskGenerator: VariantsGenerator
    {
        private readonly ReflectionFormTaskGenerator _reflectionFormTaskGenerator;
        private readonly ISetGenerator<int> _setGenerator;
        private readonly ISetComparer<int> _setComparer = new MathSetComparer<int>();
        private readonly Random _random;
        
        public SelectReflectionFormTaskGenerator(ISetWriter setWriter, ISetGenerator<int> setGenerator, Random random) : base(TaskIds.SelectReflectionForm, 1, setWriter)
        {
            _setGenerator = setGenerator;
            _random = random;
            _reflectionFormTaskGenerator = new ReflectionFormTaskGenerator(setWriter, setGenerator, random);
            Add(_reflectionFormTaskGenerator);
        }

        public override ITask Generate()
        {
            var (set, reflection, answer) = _reflectionFormTaskGenerator.Generate();
            var condition = _reflectionFormTaskGenerator.GetCondition(true, set, reflection);

            var variants = new List<IMathSet<int>> {answer};
            while (variants.Count < VariantsCount)
            {
                var variant = _setGenerator.Generate(_random.GetRandomName());
                if (!variants.Any(v => _setComparer.IsEquals(v, variant)))
                    variants.Add(variant);
            }

            return new VariantsTask<IMathSet<int>>(answer, condition, variants);
        }
    }
}