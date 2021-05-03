using System;
using TaskEngine.Generators.Tasks;
using TaskEngine.Helpers;
using TaskEngine.Sets;
using TaskEngine.Values;

namespace TaskEngine.Generators.SetGenerators
{
    public class IntBorderSetGenerator: Generator
    {
        private readonly Random _random = new Random();
        
        public IntBorderSetGenerator()
        {
            Add(new IntValue(ValuesIds.BorderDelta) {Value = 5});
            Add(new IntValue(ValuesIds.MinBorder) {Value = -20});
            Add(new IntValue(ValuesIds.MaxBorder) {Value = 20});
        }
        
        public IntBorderedSet Generate()
        {
            int minBorder = Get<IntValue>(ValuesIds.MinBorder).Value;
            int maxBorder = Get<IntValue>(ValuesIds.MaxBorder).Value;
            int delta = Get<IntValue>(ValuesIds.BorderDelta).Value;
            
            var startValue = _random.Next(minBorder - delta, minBorder + delta);
            var endValue = _random.Next(maxBorder - delta, maxBorder + delta);
            var startBorderType = BorderHelper.GetRandomBorderType();
            var endBorderType = BorderHelper.GetRandomBorderType();
            var name = Symbols.GetRandomName();

            var startBorder = new SetBorder<int>(startValue, startBorderType);
            var endBorder = new SetBorder<int>(endValue, endBorderType);
            var set = new IntBorderedSet(name, startBorder, endBorder);
            return set;
        }
    }
}