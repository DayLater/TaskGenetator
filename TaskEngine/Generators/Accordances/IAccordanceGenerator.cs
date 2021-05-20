using System.Collections.Generic;
using TaskEngine.Models;

namespace TaskEngine.Generators.Accordances
{
    public interface IAccordanceGenerator<T1, T2>
    {
        Accordance<T1, T2> Generate(IEnumerable<T1> firstElements, IEnumerable<T2> secondElements);
    }
}