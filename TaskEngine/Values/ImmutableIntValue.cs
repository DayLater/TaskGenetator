namespace TaskEngine.Values
{
    public class ImmutableIntValue: IValue
    {
        public ImmutableIntValue(string id, int value)
        {
            Value = value;
            Id = id;
        }

        public string Id { get; }
        public int Value { get; }
    }
}