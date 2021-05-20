using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;

namespace TaskEngine.Generators.Accordances
{
    public class AccordanceGenerator<T1, T2>
    {
        private readonly Random _random;

        public AccordanceGenerator(Random random)
        {
            _random = random;
        }

        public List<List<(T1, T2)>> CreateVariantsWithSameAccordance(IList<T1> firstSetElements, IReadOnlyList<T2> secondSetElements, int variantsCount)
        {
            var variants = new List<List<(T1, T2)>>();
            while (variants.Count < variantsCount)
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
    }
}