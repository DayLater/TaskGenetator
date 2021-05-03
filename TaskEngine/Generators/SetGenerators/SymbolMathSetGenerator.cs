using System;
using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Generators.SetGenerators
{
    public class SymbolMathSetGenerator
    {
        private readonly Random _random = new Random();
        public int MaxCount { get; set; } = 10;
        public int MinCount { get; set; } = 6;

        public IMathSet<string> Generate()
        {
            var name = Symbols.GetRandomName();
            var elements = new List<string>();
            var count = _random.Next(MinCount, MaxCount);
            
            while (elements.Count < count)
            {
                var element = Symbols.GetRandomElementSymbol(elements.ToArray());
                elements.Add(element);
            }

            return new MathSet<string>(name, elements);
        }
    }
}