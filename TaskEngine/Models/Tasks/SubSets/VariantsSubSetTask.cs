using System.Collections.Generic;
using TaskEngine.Models.Sets;

namespace TaskEngine.Models.Tasks.SubSets
{
    public class VariantsSubSetTask: VariantsTask<IMathSet<int>>
    {
        private SubSetType Type { get; }
        private IMathSet<int> Set { get; }

        public VariantsSubSetTask(IList<IMathSet<int>> answers, string condition, IList<IMathSet<int>> variants, SubSetType type, IMathSet<int> set) : base(answers, condition, variants)
        {
            Type = type;
            Set = set;
        }

        public VariantsSubSetTask(IMathSet<int> answer, string condition, IList<IMathSet<int>> variants, SubSetType type, IMathSet<int> set) : base(answer, condition, variants)
        {
            Type = type;
            Set = set;
        }
    }
}