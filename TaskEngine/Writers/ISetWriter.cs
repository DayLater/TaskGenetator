using TaskEngine.Sets;

namespace TaskEngine.Writers
{
    public interface ISetWriter
    {
        string Write<T>(ISet<T> set);
        string WriteCharacteristicProperty<T>(ISet<T> set);
    }
}