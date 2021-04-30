using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class CharacteristicPropertySetAnswerTask: VariantsSetAnswerTask<int>
    {
        public CharacteristicPropertySetAnswerTask(IMathSet<int> rightAnswer, IList<IMathSet<int>> variants) 
            : base(rightAnswer, variants)
        {
        }
    }
}