using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class VariantsSubSetTask: ITask
    {
        public IMathSet<int> Answer { get; }
        public IList<IMathSet<int>> Variants { get; }
        public SubSetType Type { get; }
        public IMathSet<int> Set { get; }

        public VariantsSubSetTask(IMathSet<int> answer, IList<IMathSet<int>> variants, SubSetType type, IMathSet<int> set)
        {
            Answer = answer;
            Variants = variants;
            Type = type;
            Set = set;
        }
    }
}