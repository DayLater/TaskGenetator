using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public abstract class SetAnswerTask<T>: ISetAnswerTask<T>
    {
        protected SetAnswerTask(IMathSet<T> rightAnswer)
        {
            RightAnswer = rightAnswer;
        }

        public IMathSet<T> RightAnswer { get; } 
    }
}