using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Generators.Tasks.TextTasks
{
    public abstract class SetAnswerTextTaskGenerator<TTask>: ITextTaskGenerator
        where TTask: ISetAnswerTask<int>
    {
        protected virtual string WriteAnswer(IVariantsSetAnswerTask<int> variantsSetAnswerTask)
        {
            var rightAnswerIndex = variantsSetAnswerTask.Variants.IndexOf(variantsSetAnswerTask.RightAnswer);
            return $"{rightAnswerIndex + 1}";
        }
        
        public abstract ITextTask Generate();
    }
}