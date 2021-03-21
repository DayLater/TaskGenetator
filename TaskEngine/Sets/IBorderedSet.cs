namespace TaskEngine.Sets
{
    public interface IBorderedSet<T>: IMathSet<T>
    {
        ISetBorder<T> Start { get; }
        ISetBorder<T> End { get; }
    }
}