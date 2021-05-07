using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class VariantsBorderSetOperationTask: VariantsTask<IMathSet<int>>
    {
        public VariantsBorderSetOperationTask(IList<IMathSet<int>> answers, string condition, IList<IMathSet<int>> variants, IntBorderedSet first, IntBorderedSet second, SetOperation operation) : base(answers, condition, variants)
        {
        }

        public VariantsBorderSetOperationTask(IMathSet<int> answer, string condition, IList<IMathSet<int>> variants, IntBorderedSet first, IntBorderedSet second, SetOperation operation) : base(answer, condition, variants)
        {
        }
    }
}