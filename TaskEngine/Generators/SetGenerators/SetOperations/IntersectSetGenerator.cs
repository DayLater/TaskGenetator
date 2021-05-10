using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Values;

namespace TaskEngine.Generators.SetGenerators.SetOperations
{
    public abstract class IntersectSetGenerator<T>: OperationSetGenerator<T>
    {
        private readonly IntValue _addedElementCount = new IntValue(ValuesIds.AddElementsInSet) {Value = 3};
        private readonly Random _random;

        protected IntersectSetGenerator(Random random) : base(random)
        {
            _random = random;
            Add(_addedElementCount);
        }

        protected override (IMathSet<T>, IMathSet<T>) CreateSets(string firstName, string secondName, IMathSet<T> answerSet)
        {
            var elements = answerSet.GetElements().ToList();
            var isOneInOther = _random.GetBool();
            var (firstElements, secondElements) = isOneInOther ? CreateOneInOtherElements(elements): CreateOnIntersect(elements);
            firstElements.Shuffle(_random);
            secondElements.Shuffle(_random);
            return (new MathSet<T>(firstName, firstElements), new MathSet<T>(secondName, secondElements));
        }

        private (List<T>, List<T>) CreateOneInOtherElements(IReadOnlyCollection<T> elements)
        {
            var otherList = new List<T>(elements);
            
            int added = 0;
            while (added < _addedElementCount.Value)
            {
                var element = CreateElement(_random, otherList);
                if (otherList.TryAdd(element))
                    added++;
            }

            return (new List<T>(elements), otherList);
        }
        
        private (List<T>, List<T>) CreateOnIntersect(IList<T> elements)
        {
            var firstList = new List<T>(elements);
            var secondList = new List<T>(elements);
            
            AddElementsInList(firstList, secondList);
            AddElementsInList(secondList, firstList);
            return (firstList, secondList);
        }

        private void AddElementsInList(IList<T> addingList, IList<T> exceptList)
        {
            int added = 0;
            while (added < _addedElementCount.Value)
            {
                var element = CreateElement(_random, exceptList);
                if (!exceptList.Contains(element) && addingList.TryAdd(element))
                    added++;
            }
        }

        protected abstract T CreateElement(Random random, IList<T> elements);
    }
}