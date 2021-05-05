using System;
using System.Linq.Expressions;

namespace TaskEngine.Sets
{
    public interface IExpressionSet: IMathSet<int>
    {
        Expression<Func<int, int>> Expression { get; }
    }
}