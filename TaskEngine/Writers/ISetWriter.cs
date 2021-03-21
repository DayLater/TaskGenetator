using TaskEngine.Sets;

namespace TaskEngine.Writers
{
    public interface ISetWriter
    {
        string Write<T>(IMathSet<T> set);
        string WriteCharacteristicProperty<T>(IMathSet<T> set);
    }
}