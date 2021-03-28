using System.Collections.Generic;

namespace TaskEngine.Sets
{
    public abstract class BorderedSet<T>: IBorderedSet<T>
    {
        protected readonly List<T> _elements = new List<T>();

        protected BorderedSet(string name, ISetBorder<T> start, ISetBorder<T> end)
        {
            Name = name;
            Start = start;
            End = end;
            FillElements();
        }

        protected abstract void FillElements();

        public string Name { get; }
        
        public IEnumerable<T> GetElements() => _elements;
        public ISetBorder<T> Start { get; }
        public ISetBorder<T> End { get; }
    }
}