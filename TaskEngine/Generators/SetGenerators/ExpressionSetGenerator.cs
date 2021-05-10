using System;
using System.Collections.Generic;
using TaskEngine.Extensions;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Values;

namespace TaskEngine.Generators.SetGenerators
{
    public class ExpressionSetGenerator: Valued
    {
        private readonly Random _random;
        private readonly IntValue _minValue = new IntValue(ValuesIds.MinCoefficientValue) {Value = -10};
        private readonly IntValue _maxValue = new IntValue(ValuesIds.MaxCoefficientValue) {Value = 10};
        
        public ExpressionSetGenerator(Random random)
        {
            _random = random;
            Add(_minValue);
            Add(_maxValue);
        }
        
        public List<ExpressionSet> Generate(int count)
        {
            var result = new List<ExpressionSet>();
            var coefficients = new HashSet<int>();
            var names = Symbols.Names;
            var min = _minValue.Value;
            var max = _maxValue.Value;
            
            for (var i = 0; i < count; i++)
            {
                int coefficient;
                do
                {
                    coefficient = _random.Next(min, max);
                } while (IsSuitableCoefficient(coefficients, coefficient));
                
                coefficients.Add(coefficient);
                var name = names[i];
                var set = new ExpressionSet(name, x => coefficient * x);
                result.Add(set);
            }

            return result;
        }

        public ExpressionSet Generate()
        {
            var coefficients = new List<int>();
            var min = _minValue.Value;
            var max = _maxValue.Value;
            int coefficient;
            do
            {
                coefficient = _random.Next(min, max);
            } while (IsSuitableCoefficient(coefficients, coefficient));

            var name = _random.GetRandomName();
            return new ExpressionSet(name, x => coefficient * x);
        }

        private bool IsSuitableCoefficient(ICollection<int> coefficients, int coefficient)
        {
            return coefficients.Contains(coefficient) || coefficient == 0 || coefficient == 1 || coefficient == -1;
        }
    }
}