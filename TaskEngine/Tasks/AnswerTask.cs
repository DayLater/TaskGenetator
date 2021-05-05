using System.Collections.Generic;

namespace TaskEngine.Tasks
{
    public abstract class AnswerTask<T>: IAnswerTask<T>
    {
        protected AnswerTask(IList<T> answers, string condition)
        {
            Answers = answers;
            Condition = condition;
        }

        protected AnswerTask(T answer, string condition)
        {
            Condition = condition;
            Answers = new List<T> {answer};
        }

        public IList<T> Answers { get; }
        public string Condition { get; }
    }
}