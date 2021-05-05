using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks.Elements
{
    public class SetContainElementsTask : VariantsTask<IMathSet<int>>
    {
        public List<int> Elements { get; }

        public SetContainElementsTask(IList<IMathSet<int>> answers, IList<IMathSet<int>> variants, List<int> elements) : base(answers, variants)
        {
            Elements = elements;
        }
    }
}