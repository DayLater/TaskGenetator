using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks.Elements
{
    public class NumbersBelongSetTask: VariantsTask<int>
    {
        public IMathSet<int> Set { get; }

        public NumbersBelongSetTask(IList<int> answers, IList<int> variants, IMathSet<int> set) : base(answers, variants)
        {
            Set = set;
        }

        public NumbersBelongSetTask(int answer, IList<int> variants, IMathSet<int> set) : base(answer, variants)
        {
            Set = set;
        }
    }
}