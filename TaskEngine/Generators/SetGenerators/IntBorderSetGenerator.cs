using System;
using System.Collections.Generic;
using TaskEngine.Helpers;
using TaskEngine.Sets;

namespace TaskEngine.Generators.SetGenerators
{
    public class IntBorderSetGenerator: ISetGenerator<IntBorderedSet>
    {
        private readonly Random _random = new Random();
        
        public int MinBorder { get; set; } = -20;
        public int MaxBorder { get; set; } = 20;
        public int MinDifferent { get; set; } = 20;
        
        public List<IntBorderedSet> Generate(int count)
        {
            var result = new List<IntBorderedSet>();
            for (var i = 0; i < count; i++)
            {
                var set = Generate();
                result.Add(set);
            }

            return result;
        }

        public IntBorderedSet Generate()
        {
            var startValue = _random.Next(MinBorder, MaxBorder - MinDifferent);
            var endValue = _random.Next(startValue + MinDifferent, MaxBorder);
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