using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks.SubSets
{
    public class SubSetTask: AnswerTask<IMathSet<int>>, ISetContained<int>
    {
        public SubSetType TypeTask { get; }
        public IMathSet<int> Set { get; }

        public SubSetTask(IList<IMathSet<int>> answers, string condition, SubSetType typeTask, IMathSet<int> set) : base(answers, condition)
        {
            TypeTask = typeTask;
            Set = set;
        }

        public SubSetTask(IMathSet<int> answer, string condition, SubSetType typeTask, IMathSet<int> set) : base(answer, condition)
        {
            TypeTask = typeTask;
            Set = set;
        }
    }
}