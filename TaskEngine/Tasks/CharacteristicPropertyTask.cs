using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class CharacteristicPropertyTask: VariantsTask<int>
    {
        public CharacteristicPropertyTask(IMathSet<int> rightAnswer, IList<IMathSet<int>> variants) 
            : base(rightAnswer, variants)
        {
        }
    }
}