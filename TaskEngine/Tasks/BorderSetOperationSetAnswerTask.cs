using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class BorderSetOperationSetAnswerTask: VariantsSetAnswerTask<int>
    {
        public IntBorderedSet First { get; }
        public IntBorderedSet Second { get; }
        public SetOperation Operation { get; }

        public BorderSetOperationSetAnswerTask(IMathSet<int> rightAnswer, IList<IMathSet<int>> variants, IntBorderedSet first, IntBorderedSet second, SetOperation operation) 
            : base(rightAnswer, variants)
        {
            First = first;
            Second = second;
            Operation = operation;
        }
    }
}