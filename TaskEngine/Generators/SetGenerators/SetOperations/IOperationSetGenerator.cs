using TaskEngine.Sets;
using TaskEngine.Values;

namespace TaskEngine.Generators.SetGenerators.SetOperations
{
    public interface IOperationSetGenerator<T>: IValued
    {
        (IMathSet<T> , IMathSet<T>) Generate(IMathSet<T> answerSet);
    }
}