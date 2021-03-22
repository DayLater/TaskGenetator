using System.Collections.Generic;
using System.Linq;

namespace TaskEngine.Sets
{
    public class MathSet<T>: IMathSet<T>
    {
        private readonly List<T> _elements; 
        
        public MathSet(string name, IEnumerable<T> elements)
        {
            Name = name;
            _elements = elements.Distinct().ToList();
        }

        public string Name { get; }
        public IEnumerable<T> GetElements() => _elements;
    }
}