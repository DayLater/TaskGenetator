using System.Collections.Generic;
using System.Linq;

namespace TaskEngine.Sets
{
    public class Set<T>: ISet<T>
    {
        private readonly List<T> _elements; 
        
        public Set(IEnumerable<T> elements)
        {
            _elements = elements.Distinct().ToList();
        }

        public IEnumerable<T> Elements => _elements;
    }
}