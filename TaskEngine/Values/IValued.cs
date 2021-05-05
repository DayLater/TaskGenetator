using System.Collections.Generic;

namespace TaskEngine.Values
{
    public interface IValued: IEnumerable<IValue>
    {
        public TValue Get<TValue>(string id)
            where TValue : IValue;
        
        public IEnumerable<IValue> Values { get; }
    }
}