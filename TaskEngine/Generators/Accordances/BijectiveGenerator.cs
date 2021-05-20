using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Models;

namespace TaskEngine.Generators.Accordances
{
    public class BijectiveGenerator<T1, T2>: IAccordanceGenerator<T1, T2>
    {
        private readonly Random _random;

        public BijectiveGenerator(Random random)
        {
            _random = random;
        }

        public Accordance<T1, T2> Generate(IEnumerable<T1> firstElements, IEnumerable<T2> secondElements)
        {
            var secondSetElements = secondElements.ToList();
            secondSetElements.Shuffle(_random);
            var firstSetElements = firstElements.ToList();
            firstSetElements.Shuffle(_random);

            var answerElements = new List<(T1, T2)>();
            for (int i = 0; i < firstSetElements.Count; i++)
            {
                answerElements.Add((firstSetElements[i], secondSetElements[i]));
            }

            return new Accordance<T1, T2>(answerElements, _random.GetRandomName());
        }
    }
}