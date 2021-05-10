using System;

namespace TaskEngine.Models.Values
{
    public class DefaultValue<T>: IValue
    {
        public DefaultValue(string id)
        {
            Id = id;
        }

        public string Id { get; }
        
        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                if (!_value.Equals(value))
                {
                    _value = value;
                    ValueChanged(_value);
                }
            }
        }

        public event Action<T> ValueChanged = i => { };
    }
}