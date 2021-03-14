namespace TaskEngine.Sets
{
    public class SetBorder<T>: ISetBorder<T>
    {
        public bool IsChanged { get; private set; }

        private T _value;
        
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                IsChanged = true;
            }
        }

        public void Reset()
        {
            _value = default(T);
            IsChanged = false;
        }
    }
}