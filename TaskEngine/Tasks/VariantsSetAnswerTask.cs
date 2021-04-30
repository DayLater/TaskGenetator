using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public abstract class VariantsSetAnswerTask<T>: SetAnswerTask<T>, IVariantsSetAnswerTask<T>
    {
        public VariantsSetAnswerTask(IMathSet<T> rightAnswer, IList<IMathSet<T>> variants) : base(rightAnswer)
        {
            Variants = variants;
        }
        
        public IList<IMathSet<T>> Variants { get; }
    }
}