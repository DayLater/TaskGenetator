using System;
using System.Collections.Generic;

namespace TaskEngine.Generators
{
    public class RandomSetGenerator: ISetGenerator<int>
    {
        private readonly HashSet<int> _tempValues = new HashSet<int>();
        private readonly Random _random = new Random();
        private readonly int _minValue;
        private readonly int _maxValue;

        public RandomSetGenerator(int minValue, int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public IEnumerable<int> Generate(int count)
        {
            for (var i = 0; i < count; i++)
            {
                int value;
                do
                {
                    value = _random.Next(_minValue, _maxValue);
                } while (_tempValues.Contains(value));
                
                _tempValues.Add(value);
                yield return value;
            }
            
            _tempValues.Clear();
        }
    }
}