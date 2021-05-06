using System;
using System.Collections.Generic;
using TaskEngine.Extensions;
using TaskEngine.Sets;
using TaskEngine.Values;

namespace TaskEngine.Generators.SetGenerators
{
    public class SymbolMathSetGenerator: Valued, ISetGenerator<string>
    {
        private readonly Random _random;
        public SymbolMathSetGenerator(Random random)
        {
            _random = random;
            Add(new IntValue(ValuesIds.ElementMaxCount) {Value = 10});
            Add(new IntValue(ValuesIds.ElementMinCount) {Value = 6});
        }
        
        public IMathSet<string> Generate(string name, params string[] startElements)
        {
            var elements = new List<string>(startElements);
            var minCount = Get<IntValue>(ValuesIds.ElementMinCount).Value;
            var maxCount = Get<IntValue>(ValuesIds.ElementMaxCount).Value;
            var count = _random.Next(minCount, maxCount);
            
            while (elements.Count < count)
            {
                var element = _random.GetRandomElementSymbol(elements.ToArray());
                elements.Add(element);
            }

            return new MathSet<string>(name, elements);
        }
    }
}