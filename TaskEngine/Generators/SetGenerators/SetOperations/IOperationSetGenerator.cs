using TaskEngine.Sets;

namespace TaskEngine.Generators.SetGenerators.SetOperations
{
    public interface IOperationSetGenerator
    {
        (IntBorderedSet, IntBorderedSet) Generate(IntBorderedSet answerSet);
    }
}