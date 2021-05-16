using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TaskEngine.Models
{
    public class Reflection
    {
        private readonly Func<int, int> _func;
        
        public int Coefficient { get; }
        public int FreeCoefficient { get; }
        public bool IsFreeCoefficient { get; }
        
        public Reflection(int coefficient, int freeCoefficient)
        {
            Expression = x => coefficient * x + freeCoefficient;
            Coefficient = coefficient;
            if (freeCoefficient != 0)
            {
                FreeCoefficient = freeCoefficient;
                IsFreeCoefficient = true;
            }

            _func = Expression.Compile();
        }
        
        public Reflection(int coefficient)
        {
            Expression = x => coefficient * x;
            Coefficient = coefficient;
            _func = Expression.Compile();
        }

        public IEnumerable<int> GetElements(IEnumerable<int> startElements)
        {
            return startElements.Select(element => _func(element));
        }

        public bool IsEquals(Reflection reflection)
        {
            return Coefficient == reflection.Coefficient && FreeCoefficient == reflection.FreeCoefficient;
        }

        public Expression<Func<int, int>> Expression { get; }
    }
}