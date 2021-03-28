using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class TestableSubSetTask: ITask
    {
        public TestableSubSetTask(IMathSet<int> set, SubSetType type, IReadOnlyList<IMathSet<int>> variants, int rightAnswerIndex)
        {
            Type = type;
            Set = set;
            RightAnswerIndex = rightAnswerIndex;

            for (var i = 0; i < variants.Count; i++)
            {
                Variants.Add(i, variants[i]);
            }
        }
        
        public SubSetType Type { get; }
        public int RightAnswerIndex { get; }
        public Dictionary<int, IMathSet<int>> Variants { get; } = new Dictionary<int, IMathSet<int>>();

        public IMathSet<int> Set { get; }
    }
}