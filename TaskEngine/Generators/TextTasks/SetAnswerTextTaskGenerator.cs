using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Generators.TextTasks
{
    public abstract class SetAnswerTextTaskGenerator : ITextTaskGenerator
    {
        protected virtual string WriteAnswer<T>(IVariantsSetAnswerTask<T> variantsSetAnswerTask)
        {
            var rightAnswerIndex = variantsSetAnswerTask.Variants.IndexOf(variantsSetAnswerTask.RightAnswer);
            return $"{rightAnswerIndex + 1}";
        }

        public abstract string Id { get; }
        public abstract ITextTask Generate();
    }
}