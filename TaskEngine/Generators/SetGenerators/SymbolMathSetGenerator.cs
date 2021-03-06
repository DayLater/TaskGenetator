﻿using System;
using System.Collections.Generic;
using TaskEngine.Extensions;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Values;

namespace TaskEngine.Generators.SetGenerators
{
    public class SymbolMathSetGenerator: Valued, ISetGenerator<string>
    {
        private readonly Random _random;
        private readonly IntValue _maxCount = new IntValue(ValuesIds.ElementMaxCount) {Value = 10, MinValue = 1, MaxValue = 25};
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
        
        private int _count = -1;

        public int Count
        {
            get => _count == -1 ? _random.Next(MinCount, MaxCount + 1) : _count;
            set => _count = value;
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
            while (elements.Count < Count)
            {
                var element = _random.GetRandomElementSymbol();
                if (!elements.Contains(element))
                    elements.Add(element);
            }
            
            return new MathSet<string>(name, elements);
        }
    }
}