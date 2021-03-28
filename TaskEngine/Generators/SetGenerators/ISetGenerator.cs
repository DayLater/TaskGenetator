using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Generators.SetGenerators
{
    public interface ISetGenerator<TSet>
        where TSet: IMathSet<int>
    {
        List<TSet> Generate(int count);
        TSet Generate();
    }
}