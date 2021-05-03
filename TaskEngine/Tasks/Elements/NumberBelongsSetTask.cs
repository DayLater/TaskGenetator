using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks.Elements
{
    public class NumberBelongsSetTask: ITask
    {
        public IList<int> Variants { get; }
        public int RightAnswer { get; }
        public IMathSet<int> Set { get; }

        public NumberBelongsSetTask(int rightAnswer, IList<int> variants, IMathSet<int> set)
        {
            Variants = variants;
            Set = set;
            RightAnswer = rightAnswer;
        }
    }
}