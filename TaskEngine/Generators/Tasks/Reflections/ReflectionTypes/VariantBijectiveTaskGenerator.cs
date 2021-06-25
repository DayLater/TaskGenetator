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
    public class VariantBijectiveTaskGenerator<T1, T2>: VariantsGenerator
    {
        private readonly ISetGenerator<T1> _firstSetGenerator;
        private readonly ISetGenerator<T2> _secondSetGenerator;
        private readonly Random _random;
        private readonly BijectiveGenerator<T1, T2> _bijectiveGenerator;
        
        public VariantBijectiveTaskGenerator(string id, ISetWriter setWriter, ISetGenerator<T1> firstSetGenerator, ISetGenerator<T2> secondSetGenerator, Random random) : base(id,1, setWriter)
        {
            _firstSetGenerator = firstSetGenerator;
            _secondSetGenerator = secondSetGenerator;
            _random = random;
            _bijectiveGenerator = new BijectiveGenerator<T1, T2>(random);
        }
        
        public IMathSet<T1> FirstLastMathSet { get; set; }
        public IMathSet<T2> SecondLastSet { get; set; }


        public override ITask Generate()
        {
            FirstLastMathSet = _firstSetGenerator.Generate(_random.GetRandomName());
            SecondLastSet = _secondSetGenerator.Generate(_random.GetRandomName());

            var firstElements = FirstLastMathSet.GetElements().ToList();
            var secondElements = SecondLastSet.GetElements().ToList();

            var answer = _bijectiveGenerator.Generate(firstElements, secondElements);
            var variants = CreateVariants(firstElements, secondElements);
            variants.Add(answer);

            var condition = CreateCondition(FirstLastMathSet, SecondLastSet);
            return new VariantsTask<Accordance<T1, T2>>(answer, condition, variants);
        }

        private List<Accordance<T1, T2>> CreateVariants(List<T1> firstElements, IReadOnlyList<T2> secondElements)
        {
            var variants = CreateVariantsWithSameAccordance(firstElements, secondElements);
            return variants.Select(e => new Accordance<T1, T2>(e, _random.GetRandomName())).ToList();
        }
        
        private List<List<(T1, T2)>> CreateVariantsWithSameAccordance(IList<T1> firstSetElements, IReadOnlyList<T2> secondSetElements)
        {
            var variants = new List<List<(T1, T2)>>();
            while (variants.Count < VariantsCount - 1)
            {
                var variantElements = new List<(T1, T2)>();
                var firstElements = firstSetElements.GetListWithRandomElements(firstSetElements.Count, _random);

                var firstRandomIndex = _random.Next(0, firstElements.Count);
                var secondRandomIndex = _random.GetNextExcept(0, firstElements.Count, firstRandomIndex);
                var secondElementIndex = _random.Next(0, secondSetElements.Count);
                variantElements.Add((firstElements[firstRandomIndex], secondSetElements[secondElementIndex]));
                variantElements.Add((firstElements[secondRandomIndex], secondSetElements[secondElementIndex]));
                
                foreach (var firstElement in firstElements)
                {
                    if (variantElements.Any(v => v.Item1.Equals(firstElement)))
                        continue;
                    
                    var secondElement = secondSetElements[_random.Next(0, secondSetElements.Count)];
                    variantElements.Add((firstElement, secondElement));
                }

                if (!variants.IsContain(variantElements))
                {
                    variantElements.Shuffle(_random);
                    variants.Add(variantElements);
                }
            }

            return variants;
        }

        private string CreateCondition(IMathSet<T1> firstSet, IMathSet<T2> secondSet)
        {
            return $"Даны множества {WriteSet(firstSet)} и {WriteSet(secondSet)}. Укажите соответствие, являющееся биекцией";
        }
    }
}