using System;
using System.Linq.Expressions;

namespace TaskEngine.Sets
{
    public interface IExpressionSet<T>: IMathSet<T>
    {
        Expression<Func<int, T>> Expression { get; }
    }
}