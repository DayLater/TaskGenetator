using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks.Elements
{
    public class NumberBelongsSetTask: ITask
    {
        public IList<int> Variants { get; }
        public int RightAnswer { get; }
        public IMathSet<int> TaskSet { get; }

        public NumberBelongsSetTask(int rightAnswer, IList<int> variants, IMathSet<int> taskSet)
        {
            Variants = variants;
            TaskSet = taskSet;
            RightAnswer = rightAnswer;
        }
    }
}