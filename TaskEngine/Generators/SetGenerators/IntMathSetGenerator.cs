﻿using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Values;

namespace TaskEngine.Generators.SetGenerators
{
    public class IntMathSetGenerator: Valued, ISetGenerator<int>
    {
        private readonly Random _random;
        
        private readonly IntValue _maxCount = new IntValue(ValuesIds.ElementMaxCount) {Value = 10, MinValue = 1};
        private readonly IntValue _minCount = new IntValue(ValuesIds.ElementMinCount) {Value = 6, MinValue = 1};
        private readonly IntValue _maxValue = new IntValue(ValuesIds.ElementMaxValue) {Value = 10};
        private readonly IntValue _minValue = new IntValue(ValuesIds.ElementMinValue) {Value = -10};
        private readonly BoolValue _isZeroNecessary = new BoolValue(ValuesIds.IsZeroNecessary) {Value = true};
        private readonly IntValue _minPositiveCount = new IntValue(ValuesIds.MinPositiveCount) {Value = 2, MinValue = 0};
        private readonly IntValue _minNegativeCount = new IntValue(ValuesIds.MinNegativeCount) {Value = 2, MinValue = 0};
        
        private bool _isZeroTaken;
        private int _currentNegativeCount;
        private int _currentPositiveCount;

        public int MaxCount
        {
            get => _maxCount.Value;
            set => _maxCount.Value = value;
        }

        private int _count = -1;

        public int Count
        {
            get => _count == -1 ? _random.Next(MinCount, MaxCount + 1) : _count;
            set => _count = value;
        }

        public int MinCount
        {
            get => _minCount.Value;
            set => _minCount.Value = value;
        }
        
        public int MinValue
        {
            get => _minValue.Value;
            set => _minValue.Value = value;
        }
        
        public int MaxValue
        {
            get => _maxValue.Value;
            set => _maxValue.Value = value;
        }

        public bool IsZeroNecessary
        {
            get => _isZeroNecessary.Value;
            set => _isZeroNecessary.Value = value;
        }

        public int MinPositiveCount
        {
            get => _minPositiveCount.Value;
            set => _minPositiveCount.Value = value;
        }
        
        public int MinNegativeCount
        {
            get => _minNegativeCount.Value;
            set => _minNegativeCount.Value = value;
        }

        public IntMathSetGenerator(Random random)
        {
            _random = random;
            Add(_minCount);
            Add(_maxCount);
            Add(_minValue);
            Add(_maxValue);
            Add(_minPositiveCount);
            Add(_minNegativeCount);
            Add(_isZeroNecessary);
        }

        private List<IMathSet<int>> Generate(int count)
        {
            var result = new List<IMathSet<int>>();
            
            for (var i = 0; i < count; i++)
            {
                var name = Symbols.Names[i];
                var set = CreateSet(Count, name, new List<int>());
                result.Add(set);
            }
            
            return result;
        }

        public IMathSet<int> Generate(string name, List<int> exceptElements = null, params int[] startElements)
        {
            exceptElements ??= new List<int>();
            var set = CreateSet(Count, name, exceptElements, startElements);
            return set;
        }

        private int GetNextElement()
        {
            if (IsZeroNecessary && !_isZeroTaken)
            {
                _isZeroTaken = true;
                return 0;
            }

            if (_currentNegativeCount < MinNegativeCount)
            {
                _currentNegativeCount++;
                return _random.Next(MinValue, 0);
            }

            if (_currentPositiveCount < MinPositiveCount)
            {
                _currentPositiveCount++;
                return _random.Next(1, MaxValue);
            }

            return _random.Next(MinValue, MaxValue);
        }

        private IMathSet<int> CreateSet(int elementCount, string name, ICollection<int> exceptElements, params int[] startElements)
        {
            var elements = new List<int>(startElements);
            for (var i = 0; i < elementCount - startElements.Length; i++)
            {
                int element;
                do
                {
                    element = GetNextElement();
                } while (elements.Contains(element) || exceptElements.Contains(element));
                elements.Add(element);
            }
            
            _currentNegativeCount = 0;
            _currentPositiveCount = 0;
            _isZeroTaken = false;
            elements.Shuffle(_random);
            return new MathSet<int>(name, elements);
        }

        public IMathSet<int> Generate()
        {
            return Generate(1).First();
        }

        public IMathSet<int> Generate(string name, params int[] startElements)
        {
            return CreateSet(Count, name, new List<int>(), startElements);
        }
    }
}