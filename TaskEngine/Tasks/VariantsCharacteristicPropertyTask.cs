using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class VariantsCharacteristicPropertyTask: VariantsTask<IMathSet<int>>
    {
        public VariantsCharacteristicPropertyTask(IList<IMathSet<int>> answers, IList<IMathSet<int>> variants) : base(answers, variants)
        {
        }

        public VariantsCharacteristicPropertyTask(IMathSet<int> answer, IList<IMathSet<int>> variants) : base(answer, variants)
        {
        }
    }
}