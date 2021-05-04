using System.Collections.Generic;
using TaskEngine.Values;

namespace TaskEngine.Generators.Tasks
{
    public interface IGenerator: IEnumerable<IValue>
    {
        public TValue Get<TValue>(string id)
            where TValue : IValue;
        
        public IEnumerable<IValue> Values { get; }
    }
}