using System;
using TaskEngine.Sets;

namespace TaskEngine.Writers
{
    public class SetWriter: ISetWriter
    {
        private readonly IExpressionWriter _expressionWriter;
        private readonly BorderSetWriter _borderSetWriter = new BorderSetWriter();
        private readonly int _maxCount;

        public SetWriter(IExpressionWriter expressionWriter, int maxCount)
        {
            _expressionWriter = expressionWriter;
            _maxCount = maxCount;
        }

        public string Write<T>(ISet<T> set)
        {
            var result =  set switch
            {
                IBorderedSet<T> borderedSet => _borderSetWriter.Write(borderedSet),
                IExpressionSet<T> expressionSet => WriteDefaultSet(expressionSet),
                Set<T> defaultSet => WriteDefaultSet(defaultSet),
                _ => throw new ArgumentOutOfRangeException(nameof(set))
            };

            return $"{set.Name} = {result}";
        }

        public string WriteCharacteristicProperty<T>(ISet<T> set)
        {
            return set switch
            {
                IBorderedSet<T> borderedSet => _borderSetWriter.WriteCharacteristicProperty(borderedSet),
                IExpressionSet<T> expressionSet =>  _expressionWriter.Write(expressionSet.Expression),
                Set<T> _ => "Doesn't have characteristic property",
                _ => throw new ArgumentOutOfRangeException(nameof(set))
            };
        }

        private string WriteDefaultSet<T>(ISet<T> set)
        {
            var result = "{";

            var index = 0;
            foreach (var element in set.GetElements())
            {
                if (index >= _maxCount)
                    break;
                index++;
                
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