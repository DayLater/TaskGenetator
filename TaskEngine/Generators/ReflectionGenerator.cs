using System;
using TaskEngine.Extensions;
using TaskEngine.Models;
using TaskEngine.Models.Values;

namespace TaskEngine.Generators
{
    public class ReflectionGenerator: Valued
    {
        private readonly IntValue _maxCoefficientValue = new IntValue(ValuesIds.MaxCoefficientValue) {Value = 10};

        public int MaxCoefficientValue
        {
            get => _maxCoefficientValue.Value;
            set => _maxCoefficientValue.Value = value;
        }

        public int MinCoefficientValue
        {
            get => _minCoefficientValue.Value;
            set => _minCoefficientValue.Value = value;
        }

        public int MaxFreeCoefficientValue
        {
            get => _maxFreeCoefficientValue.Value;
            set => _maxFreeCoefficientValue.Value = value;
        }

        public int MinFreeCoefficientValue
        {
            get => _minFreeCoefficientValue.Value;
            set => _minFreeCoefficientValue.Value = value;
        }

        public bool IsFreeCoefficientNecessary
        {
            get => _isFreeCoefficientNecessary.Value;
            set => _isFreeCoefficientNecessary.Value = value;
        }

        public Random Random => _random;

        private readonly IntValue _minCoefficientValue = new IntValue(ValuesIds.MinCoefficientValue) {Value = -10};

        private readonly IntValue _maxFreeCoefficientValue = new IntValue(ValuesIds.MaxFreeCoefficientValue) {Value = 20};
        private readonly IntValue _minFreeCoefficientValue = new IntValue(ValuesIds.MinFreeCoefficientValue) {Value = -20};

        private readonly BoolValue _isFreeCoefficientNecessary = new BoolValue(ValuesIds.IsFreeCoefficientNecessary) {Value = true};
        private readonly Random _random;

        public ReflectionGenerator(Random random)
        {
            _random = random;
            Add(_maxCoefficientValue);
            Add(_minCoefficientValue);
            Add(_maxFreeCoefficientValue);
            Add(_minFreeCoefficientValue);
            Add(_isFreeCoefficientNecessary);
        }

        public Reflection Generate()
        {
            var k = _random.GetNextExcept(_minCoefficientValue.Value, _maxCoefficientValue.Value + 1, 0, 1);

            if (_isFreeCoefficientNecessary.Value)
            {
                var b = _random.Next(_minFreeCoefficientValue.Value, _maxFreeCoefficientValue.Value + 1);
                return new Reflection(k, b);
            }

            return new Reflection(k);
        }
    }
}