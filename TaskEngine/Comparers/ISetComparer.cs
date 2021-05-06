using TaskEngine.Sets;

namespace TaskEngine.Comparers
{
    public interface ISetComparer<in T>
    {
        bool IsEquals(IMathSet<T> first, IMathSet<T> second);
    }
}