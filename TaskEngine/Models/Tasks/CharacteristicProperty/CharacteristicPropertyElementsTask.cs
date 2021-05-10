using System.Collections.Generic;

namespace TaskEngine.Models.Tasks.CharacteristicProperty
{
    public class CharacteristicPropertyElementsTask: IAnswerTask<int>
    {
        public CharacteristicPropertyElementsTask(string condition, IList<int> answers)
        {
            Condition = condition;
            Answers = answers;
        }

        public string Condition { get; }
        public IList<int> Answers { get; }
    }
}