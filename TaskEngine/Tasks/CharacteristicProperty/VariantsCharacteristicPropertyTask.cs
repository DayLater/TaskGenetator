using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks.CharacteristicProperty
{
    public class VariantsCharacteristicPropertyTask: VariantsTask<ExpressionSet>
    {
        public VariantsCharacteristicPropertyTask(IList<ExpressionSet> answers, string condition, IList<ExpressionSet> variants) : base(answers, condition, variants)
        {
        }

        public VariantsCharacteristicPropertyTask(ExpressionSet answer, string condition, IList<ExpressionSet> variants) : base(answer, condition, variants)
        {
        }
    }
}