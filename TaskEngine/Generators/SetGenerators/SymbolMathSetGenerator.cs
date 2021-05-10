using System;
using System.Collections.Generic;
using TaskEngine.Extensions;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Values;

namespace TaskEngine.Generators.SetGenerators
{
    public class SymbolMathSetGenerator: Valued, ISetGenerator<string>
    {
        private readonly Random _random;
        private readonly IntValue _maxCount = new IntValue(ValuesIds.ElementMaxCount) {Value = 10, MinValue = 4, MaxValue = 25};
        private readonly IntValue _minCount = new IntValue(ValuesIds.ElementMinCount) {Value = 6, MinValue = 1, MaxValue = 25};
        
        public int MaxCount
        {
            get => _maxCount.Value;
            set => _maxCount.Value = value;
        }

        public int MinCount
        {
            get => _minCount.Value;
            set => _minCount.Value = value;
        }
        
        public SymbolMathSetGenerator(Random random)
        {
            _random = random;
            Add(_minCount);
            Add(_maxCount);
        }
        
        public IMathSet<string> Generate(string name, params string[] startElements)
        {
            var elements = new List<string>(startElements);
            var minCount = Get<IntValue>(ValuesIds.ElementMinCount).Value;
            var maxCount = Get<IntValue>(ValuesIds.ElementMaxCount).Value;
            var count = _random.Next(minCount, maxCount);
            
            while (elements.Count < count)
            {
                var element = _random.GetRandomElementSymbol();
                if (!elements.Contains(element))
                    elements.Add(element);
            }
            
            return new MathSet<string>(name, elements);
        }
    }
}