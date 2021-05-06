using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks.CharacteristicProperty
{
    public class VariantsSelectCharacteristicPropertyTask: VariantsTask<ExpressionSet>
    {
        public VariantsSelectCharacteristicPropertyTask(IList<ExpressionSet> answers, string condition, IList<ExpressionSet> variants) : base(answers, condition, variants)
        {
        }

        public VariantsSelectCharacteristicPropertyTask(ExpressionSet answer, string condition, IList<ExpressionSet> variants) : base(answer, condition, variants)
        {
        }
    }
}