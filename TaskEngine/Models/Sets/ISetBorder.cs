namespace TaskEngine.Models.Sets
{
    public interface ISetBorder<T>
    {
        BorderType BorderType { get; }
        T Value { get; }
        ISetBorder<T> Clone();
    }
}