using System.Collections.Generic;
using System.Linq;

namespace TaskEngine.Sets
{
    public class Set<T>: ISet<T>
    {
        private readonly List<T> _elements; 
        
        public Set(string name, IEnumerable<T> elements)
        {
            Name = name;
            _elements = elements.Distinct().ToList();
        }

        public string Name { get; }
        public IEnumerable<T> GetElements() => _elements;
    }
}