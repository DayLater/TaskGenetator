using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public interface IVariantsTask<T>: ITask<T>
    {
        IList<IMathSet<T>> Variants { get; }
    }
}