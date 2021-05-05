using System;
using TaskEngine.Sets;

namespace TaskEngine.Writers
{
    public class SetWriter: ISetWriter
    {
        private readonly IExpressionWriter _expressionWriter;
        private readonly BorderSetWriter _borderSetWriter = new BorderSetWriter();
        private readonly int _maxCountElementOfExpressionSet;

        public SetWriter(IExpressionWriter expressionWriter, int maxCountElementOfExpressionSet)
        {
            _expressionWriter = expressionWriter;
            _maxCountElementOfExpressionSet = maxCountElementOfExpressionSet;
        }

        public string Write<T>(IMathSet<T> set, bool withName = true)
        {
            var result =  set switch
            {
                IBorderedSet<T> borderedSet => _borderSetWriter.Write(borderedSet),
                _ => WriteDefaultSet(set)
            };

            return withName? $"{set.Name} = {result}": result;
        }

        public string WriteCharacteristicProperty<T>(IMathSet<T> set)
        {
            return set switch
            {
                IBorderedSet<T> borderedSet => _borderSetWriter.WriteCharacteristicProperty(borderedSet),
                IExpressionSet expressionSet =>  _expressionWriter.Write(expressionSet.Expression),
                MathSet<T> _ => "Doesn't have characteristic property",
                _ => throw new ArgumentOutOfRangeException(nameof(set))
            };
        }

        private string WriteDefaultSet<T>(IMathSet<T> set)
        {
            var result = "{";

            var index = 0;
            foreach (var element in set.GetElements())
            {
                if (set is IExpressionSet && index >= _maxCountElementOfExpressionSet)
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