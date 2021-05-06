using TaskEngine.Sets;
using TaskEngine.Values;

namespace TaskEngine.Generators.SetGenerators
{
    public interface ISetGenerator<T>: IValued
    {
        IMathSet<T> Generate();
    }
}