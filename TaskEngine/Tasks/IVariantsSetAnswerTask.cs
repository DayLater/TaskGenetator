using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public interface IVariantsSetAnswerTask<T>: ISetAnswerTask<T>
    {
        IList<IMathSet<T>> Variants { get; }
    }
}