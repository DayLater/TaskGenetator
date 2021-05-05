using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public interface ITask
    {
        string Condition { get; }
    }

    public interface IAnswerTask<T>: ITask
    {
        IList<T> Answers { get; }
    }

    public interface IVariantsTask<T>: IAnswerTask<T>
    {
        IList<T> Variants { get; }
    }
    
    public interface ISetContained<out T>
    {
        IMathSet<T> Set { get; }
    }
}