using TaskEngine.Generators.Tasks;
using TaskEngine.Models.Sets;

namespace TaskEngine.Writers
{
    public class BorderSetWriter
    {
        public string WriteCharacteristicProperty<T>(IBorderedSet<T> borderedSet)
        {
            var borders = $"{borderedSet.Start.Value}";
            if (borderedSet.Start.BorderType == BorderType.Close)
                borders += Symbols.LessOrEquals;
            else
                borders += Symbols.Less;
            borders += "x";
            if (borderedSet.End.BorderType == BorderType.Close)
                borders += Symbols.LessOrEquals;
            else
                borders += Symbols.Less;
            borders += $"{borderedSet.End.Value}";
            
            var type = Symbols.GetTypeSymbol(typeof(T));
            return "{x | x ∈ " + type + ", " + borders + "}";
        }
        
        public string Write<T>(IBorderedSet<T> set)
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
    }
}