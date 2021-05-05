using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class VariantsCharacteristicPropertyTask: VariantsTask<IMathSet<int>>
    {
        public VariantsCharacteristicPropertyTask(IList<IMathSet<int>> answers, string condition, IList<IMathSet<int>> variants) : base(answers, condition, variants)
        {
        }

        public VariantsCharacteristicPropertyTask(IMathSet<int> answer, string condition, IList<IMathSet<int>> variants) : base(answer, condition, variants)
        {
        }
    }
}