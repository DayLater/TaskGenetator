using System.Collections.Generic;

namespace TaskEngine.Sets
{
    public interface ISet<out T>
    {
        IEnumerable<T> Elements { get; }
    }
}