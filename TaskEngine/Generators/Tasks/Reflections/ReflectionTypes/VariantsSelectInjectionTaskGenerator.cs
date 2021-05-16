using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Tasks;
using TaskEngine.Models.Values;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.Reflections.ReflectionTypes
{
    public class VariantsSelectInjectionTaskGenerator<T1, T2>: VariantsGenerator
    {
        private readonly Random _random;
        private readonly ISetGenerator<T1> _firstSetGenerator;
        private readonly ISetGenerator<T2> _secondSetGenerator;

        public VariantsSelectInjectionTaskGenerator(string id, ISetWriter setWriter, Random random, ISetGenerator<T1> firstSetGenerator, ISetGenerator<T2> secondSetGenerator) : base(id, 1, setWriter)
        {
            _random = random;
            _firstSetGenerator = firstSetGenerator;
            _secondSetGenerator = secondSetGenerator;

            var variantsCount = Get<IntValue>(ValuesIds.VariantsCount);
            variantsCount.ValueChanged += i =>
            {
                _firstSetGenerator.Get<IntValue>(ValuesIds.ElementMaxCount).Value = i;
                _firstSetGenerator.Get<IntValue>(ValuesIds.ElementMinCount).Value = i - 1;
                _secondSetGenerator.Get<IntValue>(ValuesIds.ElementMaxCount).Value = i;
                _secondSetGenerator.Get<IntValue>(ValuesIds.ElementMinCount).Value = i;
            };
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

            var addedElements = new List<T2>();
            var answerElements = new List<(T1, T2)>();
            foreach (var element in firstSetElements)
            {
                T2 addingElement;
                do
                {
                    var index = _random.Next(0, secondSetElements.Count);
                    addingElement = secondSetElements[index];
                } while (addedElements.Contains(addingElement));
                
                addedElements.Add(addingElement);
                var accordance = (element, addingElement);
                answerElements.Add(accordance);
            }

            var answerName = _random.GetRandomName();
            var answer = new Accordance<T1, T2>(answerElements, answerName);
            var variants = CreateVariants(firstSetElements, secondSetElements);
            variants.Add(answer);

            return new VariantsTask<Accordance<T1, T2>>(answer, condition, variants);
        }

        private List<Accordance<T1, T2>> CreateVariants(List<T1> firstSetElements, List<T2> secondSetElements)
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

            return variants.Select(v => new Accordance<T1, T2>(v, _random.GetRandomName())).ToList();
        }

        private string GetCondition(IMathSet<T1> firstSet, IMathSet<T2> secondSet)
        {
            return $"Даны множества {WriteSet(firstSet)} и {WriteSet(secondSet)}. Укажите отображение, являющееся инъекцией";
        }
    }
}