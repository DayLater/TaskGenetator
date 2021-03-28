using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public abstract class VariantsTask<T>: Task<T>, IVariantsTask<T>
    {
        public VariantsTask(IMathSet<T> rightAnswer, IList<IMathSet<T>> variants) : base(rightAnswer)
        {
            Variants = variants;
        }
        
        public IList<IMathSet<T>> Variants { get; }
    }
}