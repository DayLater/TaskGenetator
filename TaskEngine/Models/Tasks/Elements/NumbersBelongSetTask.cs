using System.Collections.Generic;
using TaskEngine.Models.Sets;

namespace TaskEngine.Models.Tasks.Elements
{
    public class NumbersBelongSetTask: VariantsTask<int>, ISetContained<int>
    {
        public IMathSet<int> Set { get; }

        public NumbersBelongSetTask(IList<int> answers, string condition, IList<int> variants, IMathSet<int> set) : base(answers, condition, variants)
        {
            Set = set;
        }

        public NumbersBelongSetTask(int answer, string condition, IList<int> variants, IMathSet<int> set) : base(answer, condition, variants)
        {
            Set = set;
        }
    }
}