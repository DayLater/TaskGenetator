using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class VariantsSubSetTask: VariantsTask<IMathSet<int>>
    {
        public SubSetType Type { get; }
        public IMathSet<int> Set { get; }

        public VariantsSubSetTask(IList<IMathSet<int>> answers, IList<IMathSet<int>> variants, SubSetType type, IMathSet<int> set) : base(answers, variants)
        {
            Type = type;
            Set = set;
        }

        public VariantsSubSetTask(IMathSet<int> answer, IList<IMathSet<int>> variants, SubSetType type, IMathSet<int> set) : base(answer, variants)
        {
            Type = type;
            Set = set;
        }
    }
}