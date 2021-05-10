using System;

namespace TaskEngine.Models.Values
{
    public class IntValue: IValue
    {
        public IntValue(string id)
        {
            Id = id;
        }
        public string Id { get; }
        
        private int _value;
        public int Value
        {
            get => _value;
            set
            {
                if (!_value.Equals(value) && value <= MaxValue && value >= MinValue)
                {
                    _value = value;
                    ValueChanged(_value);
                }
            }
        }

        public int MaxValue { get; set; } = int.MaxValue;
        public int MinValue { get; set; } = int.MinValue;

        public event Action<int> ValueChanged = i => { };
    }
}