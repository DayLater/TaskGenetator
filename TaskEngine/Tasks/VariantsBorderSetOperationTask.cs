using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class VariantsBorderSetOperationTask: ITask
    {
        public IMathSet<int> Answer { get; }
        public IList<IMathSet<int>> Variants { get; }
        public IntBorderedSet First { get; }
        public IntBorderedSet Second { get; }
        public SetOperation Operation { get; }

        public VariantsBorderSetOperationTask(IMathSet<int> answer, IList<IMathSet<int>> variants, IntBorderedSet first, IntBorderedSet second, SetOperation operation)
        {
            Answer = answer;
            Variants = variants;
            First = first;
            Second = second;
            Operation = operation;
        }
    }
}