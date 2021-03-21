using System;
using System.Linq.Expressions;

namespace TaskEngine.Writers
{
    public interface IExpressionWriter
    {
        string Write<T>(Expression<Func<int, T>> expression);
        
    }
}