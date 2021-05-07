using System;
using TaskEngine.Extensions;
using TaskEngine.Helpers;
using TaskEngine.Sets;

namespace TaskEngine.Generators.SetGenerators.SetOperations
{
    public class IntersectSetGenerator: IOperationSetGenerator
    {
        private readonly Random _random;

        public IntersectSetGenerator(Random random)
        {
            _random = random;
        }

        public (IntBorderedSet, IntBorderedSet) Generate(IntBorderedSet answerSet)
        {
            var firstName = _random.GetRandomName();
            var secondName = _random.GetRandomName();
            var firstSet = CreateFirstSetOnIntersect(firstName, answerSet);
            var secondSet = CreateSecondSetOnIntersect(secondName, answerSet);
            _random.ClearNames();
            return (firstSet, secondSet);
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
    }
}