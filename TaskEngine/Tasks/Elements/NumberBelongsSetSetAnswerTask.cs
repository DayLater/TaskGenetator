using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks.Elements
{
    public class NumberBelongsSetSetAnswerTask: VariantsSetAnswerTask<int>
    {
        public NumberBelongsSetSetAnswerTask(IMathSet<int> rightAnswer, IList<IMathSet<int>> variants) : base(rightAnswer, variants)
        {
            
        }
    }
}