using System.Collections.Generic;

namespace TaskEngine.Tasks
{
    public abstract class AnswerTask<T>: IAnswerTask<T>
    {
        protected AnswerTask(IList<T> answers)
        {
            Answers = answers;
        }

        protected AnswerTask(T answer)
        {
            Answers = new List<T> {answer};
        }

        public IList<T> Answers { get; }
    }
}