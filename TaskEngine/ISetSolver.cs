using System.Collections.Generic;

namespace TaskEngine
{
    public interface ISetSolver
    {
        IEnumerable<T> Solve<T>(IEnumerable<T> first, IEnumerable<T> second, SetOperation operation);
    }
}