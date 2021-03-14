namespace TaskEngine.Sets
{
    public interface ISetBorder<T>
    {
        bool IsChanged { get; }
        T Value { get; set; }
        void Reset();
    }
}