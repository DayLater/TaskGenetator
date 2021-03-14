using System;
using System.Linq.Expressions;

namespace TaskEngine
{
    public interface IExpressionWriter
    {
        string Write<T>(Expression<Func<int, T>> expression);
    }
}