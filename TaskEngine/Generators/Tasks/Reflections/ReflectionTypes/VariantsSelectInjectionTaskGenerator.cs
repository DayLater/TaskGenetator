using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.Accordances;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.Reflections.ReflectionTypes
{
    public class VariantsSelectInjectionTaskGenerator<T1, T2>: VariantsGenerator
    {
        private readonly Random _random;
        private readonly ISetGenerator<T1> _firstSetGenerator;
        private readonly ISetGenerator<T2> _secondSetGenerator;
        private readonly InjectiveGenerator<T1, T2> _injectiveGenerator;
        private readonly AccordanceGenerator<T1, T2> _accordanceGenerator;

        public VariantsSelectInjectionTaskGenerator(string id, ISetWriter setWriter, Random random, ISetGenerator<T1> firstSetGenerator, ISetGenerator<T2> secondSetGenerator) : base(id, 1, setWriter)
        {
            _random = random;
            _firstSetGenerator = firstSetGenerator;
            _secondSetGenerator = secondSetGenerator;
            _injectiveGenerator = new InjectiveGenerator<T1, T2>(random);
            _accordanceGenerator = new AccordanceGenerator<T1, T2>(random);
        }

        public override ITask Generate()
        {
            var firstName = _random.GetRandomName();
            var firstSet = _firstSetGenerator.Generate(firstName);

            var secondName = _random.GetRandomName();
            var secondSet = _secondSetGenerator.Generate(secondName);

            var condition = GetCondition(firstSet, secondSet);
            
            var firstSetElements = firstSet.GetElements().ToList();
            var secondSetElements = secondSet.GetElements().ToList();
            
            var answer = _injectiveGenerator.Generate(firstSetElements, secondSetElements);
            var variants = CreateVariants(firstSetElements, secondSetElements);
            variants.Add(answer);

            return new VariantsTask<Accordance<T1, T2>>(answer, condition, variants);
        }

        private List<Accordance<T1, T2>> CreateVariants(IList<T1> firstSetElements, IReadOnlyList<T2> secondSetElements)
        {
           return _accordanceGenerator.CreateVariantsWithSameAccordance(firstSetElements, secondSetElements, VariantsCount - 1)
                .Select(v => new Accordance<T1, T2>(v, _random.GetRandomName()))
                .ToList();
        }

        private string GetCondition(IMathSet<T1> firstSet, IMathSet<T2> secondSet)
        {
            return $"Даны множества {WriteSet(firstSet)} и {WriteSet(secondSet)}. Укажите соответствие, являющееся инъекцией";
        }
    }
}