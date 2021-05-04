using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class CharacteristicPropertyTask: ITask
    {
        public IMathSet<int> Answer { get; }
        public IList<IMathSet<int>> Variants { get; }

        public CharacteristicPropertyTask(IMathSet<int> answer, IList<IMathSet<int>> variants)
        {
            Answer = answer;
            Variants = variants;
        }
    }
}