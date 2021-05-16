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
    public class SelectPrototypeByReflectionTaskGenerator: VariantsGenerator
    {
        private readonly Random _random;
        private readonly PrototypeByReflectionTaskGenerator _prototypeByReflectionTaskGenerator;
        private readonly ISetGenerator<int> _setGenerator;
        private readonly ISetComparer<int> _setComparer = new MathSetComparer<int>();
        
        public SelectPrototypeByReflectionTaskGenerator(ISetWriter setWriter, Random random, ISetGenerator<int> setGenerator) : base(TaskIds.SelectPrototypeFormByReflection, 1, setWriter)
        {
            _random = random;
            _setGenerator = setGenerator;
            _prototypeByReflectionTaskGenerator = new PrototypeByReflectionTaskGenerator(random, setGenerator, setWriter);
            Add(_prototypeByReflectionTaskGenerator);
        }

        public override ITask Generate()
        {
            var (set, reflection, endSet) = _prototypeByReflectionTaskGenerator.Generate();
            var condition = _prototypeByReflectionTaskGenerator.CreateCondition(endSet, reflection, true);

            var variants = new List<IMathSet<int>>() {set};
            while (variants.Count < VariantsCount)
            {
                var variant = _setGenerator.Generate(_random.GetRandomName());
                if (!variants.Any(v => _setComparer.IsEquals(v, variant)))
                    variants.Add(variant);
            }

            return new VariantsTask<IMathSet<int>>(set, condition, variants);
        }
    }
}