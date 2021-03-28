namespace TaskEngine.Sets
{
    public class SetBorder<T>: ISetBorder<T>
    {
        public BorderType BorderType { get; private set; }
        public T Value { get; private set; }

        public SetBorder(T value, BorderType type)
        {
            SetValue(value, type);
        }

        private void SetValue(T value, BorderType type)
        {
            Value = value;
            BorderType = type;
        }

        public ISetBorder<T> Clone()
        {
            return new SetBorder<T>(Value, BorderType);
        }
    }
}