using System.Collections.Generic;

namespace TaskEngine.Models.Sets
{
    public interface IMathSet<out T>
    {
        string Name { get; }
        IEnumerable<T> GetElements();
    }
}