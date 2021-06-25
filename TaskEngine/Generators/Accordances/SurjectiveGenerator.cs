using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Models;
using Xceed.Document.NET;

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
            var second = secondElements.ToList();
            var freeSecondElements = new List<T2>(second);

            var answerElements = new List<(T1, T2)>();
            foreach (var element in firstElements)
            {
                T2 secondElement;
                if (freeSecondElements.Count > 0)
                    secondElement = freeSecondElements[_random.Next(0, freeSecondElements.Count)];
                else
                {
                    secondElement = second.ToList()[_random.Next(0, second.Count)];
                }

                freeSecondElements.Remove(secondElement);
                
                answerElements.Add((element, secondElement));
            }

            return new Accordance<T1, T2>(answerElements, _random.GetRandomName());
        }
    }
}