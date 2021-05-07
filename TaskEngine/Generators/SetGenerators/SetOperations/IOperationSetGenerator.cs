using TaskEngine.Sets;

namespace TaskEngine.Generators.SetGenerators.SetOperations
{
    public interface IOperationSetGenerator
    {
        (IMathSet<T> , IMathSet<T>) Generate<T>(IMathSet<T> answerSet);
    }
}