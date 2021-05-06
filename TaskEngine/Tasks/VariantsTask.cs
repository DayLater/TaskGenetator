using System.Collections.Generic;

namespace TaskEngine.Tasks
{
    public class VariantsTask<T>: AnswerTask<T>, IVariantsTask<T>
    {
        public IList<T> Variants { get; }

        public VariantsTask(IList<T> answers, string condition, IList<T> variants) : base(answers, condition)
        {
            Variants = variants;
        }

        public VariantsTask(T answer, string condition, IList<T> variants) : base(answer, condition)
        {
            Variants = variants;
        }
    }
}