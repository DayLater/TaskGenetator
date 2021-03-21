using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class CharacteristicPropertyTask
    {
        private readonly Dictionary<int, IMathSet<int>> _mathSets = new Dictionary<int, IMathSet<int>>();
        public int RightAnswerIndex { get; }

        public CharacteristicPropertyTask(IEnumerable<IMathSet<int>> sets, int rightAnswerIndex)
        {
            RightAnswerIndex = rightAnswerIndex;
            var index = 0;
            foreach (var set in sets)
            {
                _mathSets.Add(index, set);
                index++;
            }
        }
        
        public IReadOnlyDictionary<int, IMathSet<int>> Sets => _mathSets;
    }
}