namespace TaskEngine.Sets
{
    public interface ISetBorder<T>
    {
        BorderType BorderType { get; }
        bool IsChanged { get; }
        T Value { get; }
        void SetValue(T value, BorderType type);
        void Reset();
    }
}