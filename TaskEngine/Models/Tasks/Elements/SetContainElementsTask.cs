using System.Collections.Generic;
using TaskEngine.Models.Sets;

namespace TaskEngine.Models.Tasks.Elements
{
    public class SetContainElementsTask : VariantsTask<IMathSet<int>>
    {
        public List<int> Elements { get; }

        public SetContainElementsTask(IList<IMathSet<int>> answers, string condition, IList<IMathSet<int>> variants, List<int> elements) : base(answers, condition, variants)
        {
            Elements = elements;
        }

        public SetContainElementsTask(IMathSet<int> answer, string condition, IList<IMathSet<int>> variants, List<int> elements) : base(answer, condition, variants)
        {
            Elements = elements;
        }
    }
}