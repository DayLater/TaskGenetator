using System;
using System.Linq.Expressions;

namespace TaskEngine.Sets
{
    public interface IExpressionSet<T>: ISet<T>
    {
        Expression<Func<int, T>> Expression { get; }
        ISetBorder<T> Min { get; }
        ISetBorder<T> Max { get; }
    }
}