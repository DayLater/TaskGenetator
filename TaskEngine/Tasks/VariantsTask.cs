using System.Collections.Generic;

namespace TaskEngine.Tasks
{
    public abstract class VariantsTask<T>: AnswerTask<T>, IVariantsTask<T>
    {
        protected VariantsTask(IList<T> answers, IList<T> variants) : base(answers)
        {
            Variants = variants;
        }

        protected VariantsTask(T answer, IList<T> variants) : base(answer)
        {
            Variants = variants;
        }

        public IList<T> Variants { get; }
    }
}