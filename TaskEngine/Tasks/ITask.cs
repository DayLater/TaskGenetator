using System.Collections.Generic;

namespace TaskEngine.Tasks
{
    public interface ITask
    {
    }

    public interface IAnswerTask<T>: ITask
    {
        IList<T> Answers { get; }
    }

    public interface IVariantsTask<T>: IAnswerTask<T>
    {
        IList<T> Variants { get; }
    }
}