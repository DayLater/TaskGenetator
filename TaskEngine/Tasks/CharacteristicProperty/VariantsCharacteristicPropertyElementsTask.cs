using System.Collections.Generic;

namespace TaskEngine.Tasks.CharacteristicProperty
{
    public class VariantsCharacteristicPropertyElementsTask: VariantsTask<List<int>>
    {
        public VariantsCharacteristicPropertyElementsTask(IList<List<int>> answers, string condition, IList<List<int>> variants) : base(answers, condition, variants)
        {
        }

        public VariantsCharacteristicPropertyElementsTask(List<int> answer, string condition, IList<List<int>> variants) : base(answer, condition, variants)
        {
        }
    }
}