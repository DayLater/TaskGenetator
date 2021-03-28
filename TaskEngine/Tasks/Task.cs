using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public abstract class Task<T>: ITask<T>
    {
        protected Task(IMathSet<T> rightAnswer)
        {
            RightAnswer = rightAnswer;
        }

        public IMathSet<T> RightAnswer { get; } 
    }
}