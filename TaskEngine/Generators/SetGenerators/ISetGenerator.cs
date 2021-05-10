using TaskEngine.Models.Sets;
using TaskEngine.Models.Values;

namespace TaskEngine.Generators.SetGenerators
{
    public interface ISetGenerator<T>: IValued
    {
        IMathSet<T> Generate(string name, params T[] startElements);
    }
}