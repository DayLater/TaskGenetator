using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks.CharacteristicProperty
{
    public class SelectCharacteristicPropertyTask: AnswerTask<ExpressionSet>
    {
        public SelectCharacteristicPropertyTask(IList<ExpressionSet> answers, string condition) : base(answers, condition)
        {
        }

        public SelectCharacteristicPropertyTask(ExpressionSet answer, string condition) : base(answer, condition)
        {
        }
    }
}