using System.Collections;
using System.Collections.Generic;
using TaskEngine.Values;

namespace TaskEngine.Generators.Tasks
{
    public abstract class Generator: IEnumerable<IValue>
    {
        private readonly Dictionary<string, IValue> _values = new Dictionary<string, IValue>();

        public TValue Get<TValue>(string id)
            where TValue : IValue
        {
            return (TValue) _values[id];
        }

        public IEnumerable<IValue> Values => _values.Values;
        
        protected void Add(IValue value) => _values.Add(value.Id, value);

        protected void Add(IEnumerable<IValue> values)
        {
            foreach (var value in values)
                Add(value);
        }
        
        public IEnumerator<IValue> GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}