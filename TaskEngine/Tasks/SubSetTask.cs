using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class SubSetTask: AnswerTask<IMathSet<int>>
    {
        public SubSetType TypeTask { get; }
        public IMathSet<int> Set { get; }
        
        public SubSetTask(IList<IMathSet<int>> answers, SubSetType typeTask, IMathSet<int> set) : base(answers)
        {
            TypeTask = typeTask;
            Set = set;
        }

        public SubSetTask(IMathSet<int> answer, SubSetType typeTask, IMathSet<int> set) : base(answer)
        {
            TypeTask = typeTask;
            Set = set;
        }
    }
}