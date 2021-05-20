using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Models;

namespace TaskEngine.Generators.Accordances
{
    public class SurjectiveGenerator<T1, T2>: IAccordanceGenerator<T1, T2>
    {
        private readonly Random _random;

        public SurjectiveGenerator(Random random)
        {
            _random = random;
        }

        public Accordance<T1, T2> Generate(IEnumerable<T1> firstElements, IEnumerable<T2> secondElements)
        {
            var firstSetElements = firstElements.ToList();
            var answerElements = new List<(T1, T2)>();
            foreach (var element in secondElements)
            {
                var firstSetElement = firstSetElements[_random.Next(0, firstSetElements.Count)];
                answerElements.Add((firstSetElement, element));
            }

            return new Accordance<T1, T2>(answerElements, _random.GetRandomName());
        }
    }
}