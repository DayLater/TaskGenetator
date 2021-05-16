using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.Reflections.ReflectionTypes
{
    public class VariantsSelectSurjectiveTaskGenerator<T1, T2>: VariantsGenerator
    {
        private readonly ISetGenerator<T1> _firstSetGenerator;
        private readonly ISetGenerator<T2> _secondSetGenerator;
        private readonly Random _random;
        
        public VariantsSelectSurjectiveTaskGenerator(string id, ISetWriter setWriter, ISetGenerator<T1> firstSetGenerator, ISetGenerator<T2> secondSetGenerator, Random random) : base(id, 1, setWriter)
        {
            _firstSetGenerator = firstSetGenerator;
            _secondSetGenerator = secondSetGenerator;
            _random = random;
        }

        public override ITask Generate()
        {
            var firstName = _random.GetRandomName();
            var firstSet = _firstSetGenerator.Generate(firstName);
            var firstSetElements = firstSet.GetElements().ToList();

            var secondName = _random.GetRandomName();
            var secondSet = _secondSetGenerator.Generate(secondName);
            var secondSetElements = secondSet.GetElements().ToList();

            var condition = GetCondition(firstSet, secondSet);
            
            var answerElements = new List<(T1, T2)>();
            foreach (var element in secondSetElements)
            {
                var firstSetElement = firstSetElements[_random.Next(0, firstSetElements.Count)];
                answerElements.Add((firstSetElement, element));
            }

            var variants = CreateVariants(firstSetElements, secondSetElements);
            var answer = new Accordance<T1, T2>(answerElements, _random.GetRandomName());
            variants.Add(answer);

            return new VariantsTask<Accordance<T1, T2>>(answer, condition, variants);
        }

        private List<Accordance<T1, T2>> CreateVariants(IReadOnlyList<T1> firstElements, IReadOnlyList<T2> secondElements)
        {
            var variants = new List<List<(T1, T2)>>();
            while (variants.Count < VariantsCount - 1)
            {
                var variant = new List<(T1, T2)>();
                var missedElementIndex = _random.Next(1, secondElements.Count);

                T2 previousElement = default;
                for (int i = 0; i < secondElements.Count; i++)
                {
                    var firstElement =  firstElements[_random.Next(0, firstElements.Count)];
                    var secondElement = i == missedElementIndex? previousElement: secondElements[i];
                    variant.Add((firstElement, secondElement));

                    previousElement = secondElement;
                }
                
                if (!variants.IsContain(variant))
                    variants.Add(variant);
            }

            return variants.Select(v => new Accordance<T1, T2>(v, _random.GetRandomName())).ToList();
        }

        private string GetCondition(IMathSet<T1> firstSet, IMathSet<T2> secondSet)
        {
            return $"Даны множества {WriteSet(firstSet)} и {WriteSet(secondSet)}. Укажите соответствие, являющееся сюръекцией";
        }
    }
}