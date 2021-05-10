using System.Collections.Generic;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Values;

namespace TaskEngine.Generators.SetGenerators.SetOperations
{
    public interface ISetVariantGenerator<T>: IValued
    {
        IEnumerable<IMathSet<T>> Generate(IMathSet<T> answerSet, int variantCount);
    }
}