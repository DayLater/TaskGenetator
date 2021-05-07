using System;
using TaskEngine.Extensions;
using TaskEngine.Sets;

namespace TaskEngine.Generators.SetGenerators.SetOperations
{
    public class IntersectBorderedSetGenerator: OperationSetGenerator<int>
    {
        private readonly Random _random;

        public IntersectBorderedSetGenerator(Random random) : base(random)
        {
            _random = random;
        }

        private IntBorderedSet CreateFirstSetOnIntersect(string name, IntBorderedSet set)
        {
            var startBorderValue = _random.Next(set.Start.Value - 10, set.Start.Value + 1);
            var startBorderType = _random.GetRandomBorderType();
            var startBorder = new SetBorder<int>(startBorderValue, startBorderType);
            var endBorder = set.End.Clone();
            return new IntBorderedSet(name, startBorder, endBorder);
        }
        
        private IntBorderedSet CreateSecondSetOnIntersect(string name, IntBorderedSet set)
        {
            var startBorder = set.Start.Clone();
            var endBorderValue = _random.Next(set.End.Value + 1, set.End.Value + 20);
            var endBorderType = _random.GetRandomBorderType();
            var endBorder = new SetBorder<int>(endBorderValue, endBorderType);
            return new IntBorderedSet(name, startBorder, endBorder);
        }

        protected override (IMathSet<int>, IMathSet<int>) CreateSets(string firstName, string secondName, IMathSet<int> answerSet)
        {
            var set = (IntBorderedSet) answerSet;
            var firstSet = CreateFirstSetOnIntersect(firstName, set);
            var secondSet = CreateSecondSetOnIntersect(secondName, set);
            return (firstSet, secondSet);
        }
    }
}