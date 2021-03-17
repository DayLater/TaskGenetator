using System.Collections.Generic;

namespace TaskEngine.Sets
{
    public interface ISet<out T>
    {
        string Name { get; }
        IEnumerable<T> GetElements();
    }
}