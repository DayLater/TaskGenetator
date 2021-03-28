using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public interface ITask<T>
    {
        IMathSet<T> RightAnswer { get; } 
    }
}