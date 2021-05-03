using System;
using System.Collections.Generic;
using TaskEngine.Generators.Tasks;
using TaskEngine.Sets;
using TaskEngine.Values;

namespace TaskEngine.Generators.SetGenerators
{
    public class SymbolMathSetGenerator: Generator
    {
        private readonly Random _random = new Random();
        public SymbolMathSetGenerator()
        {
            Add(new IntValue(ValuesIds.ElementMaxCount) {Value = 10});
            Add(new IntValue(ValuesIds.ElementMinCount) {Value = 6});
        }
        
        public IMathSet<string> Generate()
        {
            var name = Symbols.GetRandomName();
            var elements = new List<string>();
            var minCount = Get<IntValue>(ValuesIds.ElementMinCount).Value;
            var maxCount = Get<IntValue>(ValuesIds.ElementMaxCount).Value;
            var count = _random.Next(minCount, maxCount);
            
            while (elements.Count < count)
            {
                var element = Symbols.GetRandomElementSymbol(elements.ToArray());
                elements.Add(element);
            }

            return new MathSet<string>(name, elements);
        }
    }
}