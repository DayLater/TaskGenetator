using System.Collections.Generic;

namespace TaskEngine.Tasks
{
    public abstract class VariantsTask<T>: AnswerTask<T>, IVariantsTask<T>
    {
        public IList<T> Variants { get; }

        protected VariantsTask(IList<T> answers, string condition, IList<T> variants) : base(answers, condition)
        {
            Variants = variants;
        }

        protected VariantsTask(T answer, string condition, IList<T> variants) : base(answer, condition)
        {
            Variants = variants;
        }
    }
}