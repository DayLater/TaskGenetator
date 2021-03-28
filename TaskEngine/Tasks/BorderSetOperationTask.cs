using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class BorderSetOperationTask: ITask
    {
        public BorderSetOperationTask(IntBorderedSet first, IntBorderedSet second, IntBorderedSet rightAnswer, 
            List<IntBorderedSet> variants, SetOperation operation)
        {
            First = first;
            Second = second;
            RightAnswer = rightAnswer;
            Variants = variants;
            Operation = operation;
        }

        public IntBorderedSet First { get; }
        public IntBorderedSet Second { get; }
        public IntBorderedSet RightAnswer { get; }
        public List<IntBorderedSet> Variants { get; }
        public SetOperation Operation { get; }
    }
}