using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TaskEngine.Models.Sets
{
    public class ExpressionSet: IExpressionSet
    {
        private readonly Func<int, int> _creatingFunc;
        private readonly int _count;

        public ExpressionSet(string name, Expression<Func<int, int>> expression, int count = -1)
        {
            Name = name;
            Expression = expression;
            _creatingFunc = Expression.Compile();
            _count = count == -1 ? int.MaxValue : count;;
        }

        public string Name { get; }

        public IEnumerable<int> GetElements()
        {
            for (var i = 1; i <= _count; i++)
                yield return _creatingFunc.Invoke(i);
        }

        public Expression<Func<int, int>> Expression { get; }
    }
}