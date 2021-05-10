using System.Collections.Generic;

namespace TaskEngine.Models.Tasks
{
    public class AnswerTask<T>: IAnswerTask<T>
    {
        public AnswerTask(IList<T> answers, string condition)
        {
            Answers = answers;
            Condition = condition;
        }

        public AnswerTask(T answer, string condition)
        {
            Condition = condition;
            Answers = new List<T> {answer};
        }

        public IList<T> Answers { get; }
        public string Condition { get; }
    }
}