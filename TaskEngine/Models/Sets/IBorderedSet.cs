namespace TaskEngine.Models.Sets
{
    public interface IBorderedSet<T>: IMathSet<T>
    {
        ISetBorder<T> Start { get; }
        ISetBorder<T> End { get; }
    }
}