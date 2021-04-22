using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class VariantsSubSetTask: VariantsTask<int>
    {
        public SubSetType Type { get; }
        public IMathSet<int> Set { get; }

        public VariantsSubSetTask(IMathSet<int> rightAnswer, IList<IMathSet<int>> variants, SubSetType type, IMathSet<int> set) 
            : base(rightAnswer, variants)
        {
            Type = type;
            Set = set;
        }
    }
}