namespace TaskEngine.Sets
{
    public class SetBorder<T>: ISetBorder<T>
    {
        public BorderType BorderType { get; private set; }
        public bool IsChanged { get; private set; }
        
        public T Value { get; private set; }

        public void SetValue(T value, BorderType type)
        {
            Value = value;
            BorderType = type;
            IsChanged = true;
        }

        public void Reset()
        {
            Value = default(T);
            IsChanged = false;
        }
    }
}