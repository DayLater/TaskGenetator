using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Models;

namespace TaskEngine.Generators.Accordances
{
    public class InjectiveGenerator<T1, T2>: IAccordanceGenerator<T1, T2>
    {
        private readonly Random _random;

        public InjectiveGenerator(Random random)
        {
            _random = random;
        }

        public Accordance<T1, T2> Generate(IEnumerable<T1> firstElements, IEnumerable<T2> secondElements)
        {
            var secondSetElements = secondElements.ToList();
            var addedElements = new List<T2>();
            var answerElements = new List<(T1, T2)>();
            foreach (var element in firstElements)
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
            return new Accordance<T1, T2>(answerElements, answerName);
        }
    }
}