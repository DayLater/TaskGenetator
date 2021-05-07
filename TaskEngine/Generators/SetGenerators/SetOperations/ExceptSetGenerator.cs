using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Sets;
using TaskEngine.Values;

namespace TaskEngine.Generators.SetGenerators.SetOperations
{
    public abstract class ExceptSetGenerator<T>: OperationSetGenerator<T>
    {
        private readonly IntValue _addedElements = new IntValue(ValuesIds.AddElementsInSet) {Value = 4};
        private readonly Random _random;

        protected ExceptSetGenerator(Random random) : base(random)
        {
            _random = random;
            Add(_addedElements);
        }

        protected override (IMathSet<T>, IMathSet<T>) CreateSets(string firstName, string secondName, IMathSet<T> answerSet)
        {
            var elements = answerSet.GetElements().ToList();
            var firstSubset = new List<T>(elements);
            var secondSubset = new List<T>();
            
            int added = 0;
            while (added < _addedElements.Value + elements.Count / 2)
            {
                var element = CreateElement(_random, firstSubset);
                if (!firstSubset.Contains(element) && secondSubset.TryAdd(element))
                    added++;
            }

            added = 0;
            while (added < _addedElements.Value)
            {
                var element = CreateElement(_random, firstSubset);
                if (!firstSubset.Contains(element) && secondSubset.Contains(element))
                {
                    firstSubset.Add(element);
                    secondSubset.Add(element);
                    added++;
                }
            }

            firstSubset.Shuffle(_random);
            secondSubset.Shuffle(_random);
            return (new MathSet<T>(firstName, firstSubset), new MathSet<T>(secondName, secondSubset));
        }

        protected abstract T CreateElement(Random random, IList<T> firstList);
    }
}