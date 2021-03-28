using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers.Tasks
{
    public abstract class TaskWriter<TTask>: ITaskWriter<TTask>
        where TTask: ITask<int>
    {
        protected virtual string WriteAnswer(IVariantsTask<int> variantsTask)
        {
            var rightAnswerIndex = variantsTask.Variants.IndexOf(variantsTask.RightAnswer);
            return $"{rightAnswerIndex + 1}";
        }

        public abstract ITextTask WriteTask(TTask task);
    }
}