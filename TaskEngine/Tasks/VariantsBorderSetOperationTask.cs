using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class VariantsBorderSetOperationTask: VariantsTask<IMathSet<int>>
    {
        public IntBorderedSet First { get; }
        public IntBorderedSet Second { get; }
        public SetOperation Operation { get; }

        public VariantsBorderSetOperationTask(IList<IMathSet<int>> answers, IList<IMathSet<int>> variants, IntBorderedSet first, IntBorderedSet second, SetOperation operation) : base(answers, variants)
        {
            First = first;
            Second = second;
            Operation = operation;
        }

        public VariantsBorderSetOperationTask(IMathSet<int> answer, IList<IMathSet<int>> variants, IntBorderedSet first, IntBorderedSet second, SetOperation operation) : base(answer, variants)
        {
            First = first;
            Second = second;
            Operation = operation;
        }
    }
}