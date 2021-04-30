using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers.Tasks
{
    public abstract class SetAnswerTaskWriter<TTask>: ITaskWriter<TTask>
        where TTask: ISetAnswerTask<int>
    {
        protected virtual string WriteAnswer(IVariantsSetAnswerTask<int> variantsSetAnswerTask)
        {
            var rightAnswerIndex = variantsSetAnswerTask.Variants.IndexOf(variantsSetAnswerTask.RightAnswer);
            return $"{rightAnswerIndex + 1}";
        }

        public abstract ITextTask WriteTask(TTask task);
    }
}