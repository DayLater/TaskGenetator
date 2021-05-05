﻿using System;
using System.Collections.Generic;
using TaskEngine.Generators.Tasks;
using TaskEngine.Sets;
using TaskEngine.Values;

namespace TaskEngine.Generators.SetGenerators
{
    public class ExpressionSetGenerator: Generator
    {
        private readonly Random _random = new Random();

        public ExpressionSetGenerator()
        {
            Add(new IntValue(ValuesIds.MinCoefficientValue) {Value = -10});
            Add(new IntValue(ValuesIds.MaxCoefficientValue) {Value = 10});
        }
        
        public List<IMathSet<int>> Generate(int count)
        {
            var result = new List<IMathSet<int>>();
            var containedItems = new HashSet<int>();
            var names = Symbols.Names;
            var min = Get<IntValue>(ValuesIds.MinCoefficientValue).Value;
            var max = Get<IntValue>(ValuesIds.MaxCoefficientValue).Value;
            
            for (var i = 0; i < count; i++)
            {
                int coefficient;
                do
                {
                    coefficient = _random.Next(min, max);
                } while (containedItems.Contains(coefficient) || coefficient == 0 || coefficient == 1);
                
                containedItems.Add(coefficient);
                var name = names[i];
                var set = new ExpressionSet(name, x => coefficient * x);
                result.Add(set);
            }

            return result;
        }
    }
}