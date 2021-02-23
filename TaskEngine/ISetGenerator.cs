using System.Collections.Generic;

namespace TaskEngine
{
    public interface ISetGenerator<out T>
    {
        IEnumerable<T> Generate(int count);
    }
}