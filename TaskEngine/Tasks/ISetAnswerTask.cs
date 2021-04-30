using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public interface ISetAnswerTask<T>: ITask
    {
        IMathSet<T> RightAnswer { get; } 
    }
}