using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Elements;
using TaskEngine.Values;

namespace TaskEngine.Generators.Tasks.Elements
{
    public class NumberBelongsBorderedSetTaskGenerator: VariantsGenerator<NumberBelongsSetTask>
    {
        private readonly IntBorderSetGenerator _setGenerator;
        private readonly Random _random;
        
        public NumberBelongsBorderedSetTaskGenerator(Random random) : base(TaskIds.NumberBelongsBorderedSetTask)
        {
            _setGenerator = new IntBorderSetGenerator(random);
            _random = random;
            Add(_setGenerator);
        }

        public override NumberBelongsSetTask Generate()
        {
            var set = _setGenerator.Generate();
            var elements = set.GetElements().ToList();
            var startValue = set.Start.Value;
            var endValue = set.End.Value;
            var answer = _random.Next(startValue, endValue);

            var variants = new List<int> {answer};
            var variantsCount = Get<IntValue>(ValuesIds.VariantsCount).Value;
            while (variants.Count < variantsCount)
            {
                var variant = _random.Next(startValue - elements.Count - variantsCount, endValue + elements.Count + variantsCount);
                if (!elements.Contains(variant) && !variants.Contains(variant))
                    variants.Add(variant);
            }

            return new NumberBelongsSetTask(answer, variants, set);
        }
    }
}