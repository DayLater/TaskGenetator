using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks.Elements
{
    public class NumberBelongsSetTask: VariantsTask<int>
    {
        public IMathSet<int> Set { get; }

        public NumberBelongsSetTask(IList<int> answers, IList<int> variants, IMathSet<int> set) : base(answers, variants)
        {
            Set = set;
        }

        public NumberBelongsSetTask(int answer, IList<int> variants, IMathSet<int> set) : base(answer, variants)
        {
            Set = set;
        }
    }
}