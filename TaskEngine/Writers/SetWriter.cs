using System;
using TaskEngine.Sets;

namespace TaskEngine.Writers
{
    public class SetWriter: ISetWriter
    {
        private readonly IExpressionWriter _expressionWriter;

        public SetWriter(IExpressionWriter expressionWriter)
        {
            _expressionWriter = expressionWriter;
        }

        public string Write<T>(ISet<T> set)
        {
            var result =  set switch
            {
                IBorderedSet<T> borderedSet => WriteBorderedSet(borderedSet),
                IExpressionSet<T> expressionSet => WriteExpressionSet(expressionSet),
                Set<T> defaultSet => WriteDefaultSet(defaultSet),
                _ => throw new ArgumentOutOfRangeException(nameof(set))
            };

            return $"{set.Name} = {result}";
        }

        private string WriteExpressionSet<T>(IExpressionSet<T> set)
        {
            return _expressionWriter.Write(set.Expression);
        }

        private string WriteBorderedSet<T>(IBorderedSet<T> set)
        {
            var result = "";
            if (set.Start.BorderType == BorderType.Close)
                result += "[";
            else
                result += "(";

            result += $"{set.Start.Value}; {set.End.Value}";

            if (set.End.BorderType == BorderType.Close)
                result += "]";
            else
                result += ")";
            return $"{result}";
        }

        private string WriteDefaultSet<T>(ISet<T> set)
        {
            var result = "{";

            foreach (var element in set.GetElements())
            {
                result += $"{element}; ";
            }

            if (result.Length > 1)
            {
                result = result.Remove(result.Length - 2);
            }

            result += "}";
            return result;
        }
    }
}