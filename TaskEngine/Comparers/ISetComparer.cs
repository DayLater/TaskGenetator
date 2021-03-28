using TaskEngine.Sets;

namespace TaskEngine.Comparers
{
    public interface ISetComparer<in TSet>
        where TSet: IMathSet<int>
    {
        bool IsEquals(TSet first, TSet second);
    }
}