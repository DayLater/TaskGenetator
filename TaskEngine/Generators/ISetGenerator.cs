using System.Collections.Generic;

namespace TaskEngine.Generators
{
    public interface ISetGenerator<out T>
    {
        IEnumerable<T> Generate(int count);
    }
}