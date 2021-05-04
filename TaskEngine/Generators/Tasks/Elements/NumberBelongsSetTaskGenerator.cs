using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Tasks.Elements;
using TaskEngine.Values;

namespace TaskEngine.Generators.Tasks.Elements
{
    public class NumberBelongsSetTaskGenerator: VariantsGenerator
    {
        private readonly IntMathSetGenerator _intMathSetGenerator = new IntMathSetGenerator();
        private readonly Random _random = new Random();

        public NumberBelongsSetTaskGenerator()
        {
            Add(_intMathSetGenerator);
        }

        public NumberBelongsSetTask Generate()
        {
            var set = _intMathSetGenerator.Generate();
            var elements = set.GetElements().ToList();
            var elementIndex = _random.Next(0, elements.Count);
            var answer = elements[elementIndex];

            var variants = new List<int> {answer};
            var variantsCount = Get<IntValue>(ValuesIds.VariantsCount).Value;
            while (variants.Count < variantsCount)
            {
                var element = _random.Next(_intMathSetGenerator.MinValue, _intMathSetGenerator.MaxValue);
                if (!variants.Contains(element) && !elements.Contains(element))
                    variants.Add(element);
            }

            return new NumberBelongsSetTask(answer, variants.ShuffleToList(), set);
        }
    }
}