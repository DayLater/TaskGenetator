using System;
using System.Linq.Expressions;
using TaskEngine.Extensions;

namespace TaskEngine.Writers
{
    public class ExpressionWriter: IExpressionWriter
    {
        public string Write<T>(Expression<Func<int, T>> expression)
        {
            var simplifiedExpression = expression.Simplify();
            var result = GetFunctionBody(simplifiedExpression);
            var type = Symbols.GetTypeSymbol(typeof(T));
            return "{" + result + ", x ∈ " + type + "}"; 
        }

        private string GetFunctionBody<T>(Expression<Func<int, T>> func)
        {
            var result = func.Body.ToString();
            var parameterName = func.Parameters[0].Name;
            result = result.Replace(parameterName, "x");
            return "x | x = " + result.Replace("=>", "|");
        }
    }
}