using TaskEngine.Models.Sets;
using TaskEngine.Models.Values;

namespace TaskEngine.Generators.SetGenerators.SetOperations
{
    public interface IOperationSetGenerator<T>: IValued
    {
        (IMathSet<T> , IMathSet<T>) Generate(IMathSet<T> answerSet);
    }
}