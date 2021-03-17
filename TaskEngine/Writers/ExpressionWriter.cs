using System;
using System.Linq.Expressions;

namespace TaskEngine.Writers
{
    public class ExpressionWriter: IExpressionWriter
    {
        public string Write<T>(Expression<Func<int, T>> expression)
        {
            var result = GetFunctionBody(expression);
            var type = GetType(typeof(T));
            return "{" + result + ", x ∈ " + type + "}"; 
        }

        private string GetFunctionBody<T>(Expression<Func<int, T>> func)
        {
            var result = func.Body.ToString();
            var parameterName = func.Parameters[0].Name;
            result = result.Replace(parameterName, "x");
            return "x | x = " + result.Replace("=>", "|");
        }

        private string GetType(Type type)
        {
            if (type == typeof(int))
                return "Z";
            if (type == typeof(uint))
                return "N";
            if (type == typeof(double))
                return "Q";

            throw new ArgumentException("Unknown type");
        }
    }
}