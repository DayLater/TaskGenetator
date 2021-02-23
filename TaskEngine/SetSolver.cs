using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskEngine
{
    public class SetSolver: ISetSolver
    {
        public IEnumerable<T> Solve<T>(IEnumerable<T> first, IEnumerable<T> second, SetOperation operation)
        {
            return operation switch
            {
                SetOperation.Undefined => throw new ArgumentOutOfRangeException(),
                SetOperation.Union => first.Union(second),
                SetOperation.Except => first.Except(second),
                SetOperation.Intersect => first.Intersect(second),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}