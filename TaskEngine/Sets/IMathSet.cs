using System.Collections.Generic;

namespace TaskEngine.Sets
{
    public interface IMathSet<out T>
    {
        string Name { get; }
        IEnumerable<T> GetElements();
    }
}