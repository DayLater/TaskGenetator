using System.Collections.Generic;

namespace TaskEngine.Sets
{
    public abstract class BorderedSet<T>: IBorderedSet<T>
    {
        protected readonly List<T> _elements = new List<T>();

        protected BorderedSet(string name, T start, BorderType startType, T end, BorderType endType)
        {
            Name = name;
            Start = new SetBorder<T>(start, startType);
            End = new SetBorder<T>(end, endType);
            FillElements();
        }

        protected abstract void FillElements();

        public string Name { get; }
        
        public IEnumerable<T> GetElements() => _elements;
        public ISetBorder<T> Start { get; }
        public ISetBorder<T> End { get; }
    }
}