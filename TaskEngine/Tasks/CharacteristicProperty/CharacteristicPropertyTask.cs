using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks.CharacteristicProperty
{
    public class CharacteristicPropertyTask: AnswerTask<ExpressionSet>
    {
        public CharacteristicPropertyTask(IList<ExpressionSet> answers, string condition) : base(answers, condition)
        {
        }

        public CharacteristicPropertyTask(ExpressionSet answer, string condition) : base(answer, condition)
        {
        }
    }
}