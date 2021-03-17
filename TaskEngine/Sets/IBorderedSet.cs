namespace TaskEngine.Sets
{
    public interface IBorderedSet<T>: ISet<T>
    {
        ISetBorder<T> Start { get; }
        ISetBorder<T> End { get; }
    }
}