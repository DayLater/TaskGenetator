using System;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Sets;
using TaskEngine.Values;

namespace TaskEngine.Generators.SetGenerators
{
    public class IntBorderSetGenerator: Valued, ISetGenerator<int>
    {
        private readonly Random _random;
        
        public IntBorderSetGenerator(Random random)
        {
            _random = random;
            Add(new IntValue(ValuesIds.BorderDelta) {Value = 5});
            Add(new IntValue(ValuesIds.MinBorder) {Value = -10});
            Add(new IntValue(ValuesIds.MaxBorder) {Value = 10});
        }
        
        public IMathSet<int> Generate(string name, params int[] startElements)
        {
            int minBorder = Get<IntValue>(ValuesIds.MinBorder).Value;
            int maxBorder = Get<IntValue>(ValuesIds.MaxBorder).Value;
            int delta = Get<IntValue>(ValuesIds.BorderDelta).Value;
            
            var startValue = _random.GetNext(minBorder, minBorder, delta);
            var endValue = _random.GetNext(maxBorder, maxBorder, delta);
            var startBorderType = _random.GetRandomBorderType();
            var endBorderType = _random.GetRandomBorderType();
            if (startElements.Length > 0)
            {
                var min = startElements.Min();
                if (min <= startValue)
                {
                    startValue = min;
                    startBorderType = BorderType.Close;
                }
                var max = startElements.Max();
                if (max >= endValue)
                {
                    endValue = max;
                    endBorderType = BorderType.Close;
                }
            }
            
            var startBorder = new SetBorder<int>(startValue, startBorderType);
            var endBorder = new SetBorder<int>(endValue, endBorderType);
            var set = new IntBorderedSet(name, startBorder, endBorder);
            return set;
        }
    }
}