using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TaskEngine.Sets
{
    public class ExpressionSet<T> : IExpressionSet<T>
    {
        private readonly Func<int, T> _creatingFunc;
        private readonly int _count;

        public ExpressionSet(Expression<Func<int, T>> expression, int count = -1)
        {
            Expression = expression;
            _creatingFunc = Expression.Compile();
            _count = count == -1 ? int.MaxValue : count;;
        }

        public IEnumerable<T> Elements
        {
            get
            {
                for (var i = 1; i <= _count; i++)
                    yield return _creatingFunc.Invoke(i);
            }
        }

        public Expression<Func<int, T>> Expression { get; }

        public ISetBorder<T> Min { get; } = new SetBorder<T>();
        public ISetBorder<T> Max { get; } = new SetBorder<T>();
    }
}