using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Tasks.Elements;
using TaskEngine.Values;

namespace TaskEngine.Generators.Tasks.Elements
{
    public class NumberBelongBorderedSetTaskGenerator: Generator, ITaskGenerator
    {
        private readonly IntBorderSetGenerator _setGenerator = new IntBorderSetGenerator();
        private readonly Random _random = new Random();
        
        public NumberBelongBorderedSetTaskGenerator()
        {
            Add(new IntValue(ValuesIds.VariantsCount) {Value = 4});

            foreach (var value in _setGenerator.Values)
                Add(value);
        }

        public NumberBelongsSetTask Generate()
        {
            var set = _setGenerator.Generate();
            var elements = set.GetElements().ToList();
            var startValue = set.Start.Value;
            var endValue = set.End.Value;
            var answer = _random.Next(startValue, endValue);

            var variants = new List<int>() {answer};
            var variantsCount = Get<IntValue>(ValuesIds.VariantsCount).Value;
            while (variants.Count < variantsCount)
            {
                var variant = _random.Next(startValue - elements.Count - variantsCount, endValue + elements.Count + variantsCount);
                if (!elements.Contains(variant) && !variants.Contains(variant))
                    variants.Add(variant);
            }

            return new NumberBelongsSetTask(answer, variants.ShuffleToList(), set);
        }
    }
}