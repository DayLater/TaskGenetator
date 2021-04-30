using System;
using System.Collections.Generic;
using TaskEngine.Extensions;
using TaskEngine.Sets;

namespace TaskEngine.Generators.SetGenerators
{
    public class MathSetGenerator: ISetGenerator<IMathSet<int>>
    {
        private readonly Random _random = new Random();
        public int MaxCount { get; set; } = 10;
        public int MinCount { get; set; } = 6;
        
        public int MinValue { get; set; } = -10;
        public int MaxValue { get; set; } = 10;

        public bool IsZeroNecessary { get; set; } = true;
        private bool _isZeroTaken;
        public int MinPositiveCount { get; set; } = 2;
        private int _currentPositiveCount;
        
        public int MinNegativeCount { get; set; } = 2;
        private int _currentNegativeCount;
        
        public List<IMathSet<int>> Generate(int count)
        {
            var result = new List<IMathSet<int>>();
            
            for (var i = 0; i < count; i++)
            {
                var name = Symbols.Names[i];
                var elementCount = _random.Next(MinCount, MaxCount);
                var set = CreateSet(elementCount, name);

                result.Add(set);
            }


            return result;
        }

        public IMathSet<int> Generate()
        {
            var name = Symbols.GetRandomName();
            var elementCount = _random.Next(MinCount, MaxCount);
            var set = CreateSet(elementCount, name);
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

        private IMathSet<int> CreateSet(int elementCount, string name)
        {
            var elements = new List<int>();
            for (var i = 0; i < elementCount; i++)
            {
                int element;
                do
                {
                    element = GetNextElement();
                } while (elements.Contains(element));
                elements.Add(element);
            }
            
            _currentNegativeCount = 0;
            _currentPositiveCount = 0;
            _isZeroTaken = false;

            return new MathSet<int>(name, elements.ShuffleToList());
        }
    }
}