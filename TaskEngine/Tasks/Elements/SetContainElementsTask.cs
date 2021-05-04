using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks.Elements
{
    public class SetContainElementsTask : ITask
    {
        public SetContainElementsTask(List<int> elements, List<IMathSet<int>> variants, List<IMathSet<int>> answer)
        {
            Elements = elements;
            Variants = variants;
            Answer = answer;
        }

        public List<int> Elements { get; }
        public List<IMathSet<int>> Variants { get; }
        public List<IMathSet<int>> Answer { get; }
    }
}