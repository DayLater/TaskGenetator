using TaskEngine.Sets;

namespace TaskEngine.Writers
{
    public interface ISetWriter
    {
        string Write<T>(IMathSet<T> set, bool withName = true);
        string WriteCharacteristicProperty<T>(IMathSet<T> set);
    }
}