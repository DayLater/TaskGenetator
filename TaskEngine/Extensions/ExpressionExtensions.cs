using System.Collections.Generic;
using System.Linq.Expressions;

namespace TaskEngine.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression Simplify(this Expression expression)
        {
            var searcher = new ParameterlessExpressionSearcher();
            searcher.Visit(expression);
            return new ParameterlessExpressionEvaluator(searcher.ParameterlessExpressions).Visit(expression);
        }

        public static Expression<T> Simplify<T>(this Expression<T> expression)
        {
            return (Expression<T>)Simplify((Expression)expression);
        }

        private class ParameterlessExpressionEvaluator : ExpressionVisitor
        {
            private readonly HashSet<Expression> _parameterlessExpressions;
            public ParameterlessExpressionEvaluator(HashSet<Expression> parameterlessExpressions)
            {
                _parameterlessExpressions = parameterlessExpressions;
            }
            public override Expression Visit(Expression node)
            {
                if (_parameterlessExpressions.Contains(node))
                    return Evaluate(node);
                
                return base.Visit(node);
            }

            private Expression Evaluate(Expression node)
            {
                if (node.NodeType == ExpressionType.Constant)
                {
                    return node;
                }
                object value = Expression.Lambda(node).Compile().DynamicInvoke();
                return Expression.Constant(value, node.Type);
            }
        }

        private class ParameterlessExpressionSearcher : ExpressionVisitor
        {
            public HashSet<Expression> ParameterlessExpressions { get; } = new HashSet<Expression>();
            private bool _containsParameter;

            public override Expression Visit(Expression node)
            {
                bool originalContainsParameter = _containsParameter;
                _containsParameter = false;
                base.Visit(node);
                if (!_containsParameter)
                {
                    if (node?.NodeType == ExpressionType.Parameter)
                        _containsParameter = true;
                    else
                        ParameterlessExpressions.Add(node);
                }
                _containsParameter |= originalContainsParameter;

                return node;
            }
        }
    }
}