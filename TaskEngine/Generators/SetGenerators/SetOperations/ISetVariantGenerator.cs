using System.Collections.Generic;
using TaskEngine.Sets;
using TaskEngine.Values;

namespace TaskEngine.Generators.SetGenerators.SetOperations
{
    public interface ISetVariantGenerator<T>: IValued
    {
        IEnumerable<IMathSet<T>> Generate(IMathSet<T> answerSet, int variantCount);
    }
}