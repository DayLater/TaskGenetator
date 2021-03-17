using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TaskEngine.Sets
{
    public class ExpressionSet<T> : IExpressionSet<T>
    {
        private readonly Func<int, T> _creatingFunc;
        private readonly int _count;

        public ExpressionSet(string name, Expression<Func<int, T>> expression, int count = -1)
        {
            Name = name;
            Expression = expression;
            _creatingFunc = Expression.Compile();
            _count = count == -1 ? int.MaxValue : count;;
        }

        public string Name { get; }

        public IEnumerable<T> GetElements()
        {
            for (var i = 1; i <= _count; i++)
                yield return _creatingFunc.Invoke(i);
        }

        public Expression<Func<int, T>> Expression { get; }
    }
}