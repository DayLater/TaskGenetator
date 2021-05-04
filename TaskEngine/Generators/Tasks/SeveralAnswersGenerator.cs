using TaskEngine.Tasks;
using TaskEngine.Values;

namespace TaskEngine.Generators.Tasks
{
    public abstract class SeveralAnswersGenerator<TTask>: VariantsGenerator<TTask>
        where TTask: ITask
    {
        protected SeveralAnswersGenerator(string id, int variantCount = 6, int answerCount = 2): base(id, variantCount)
        {
            Add(new IntValue(ValuesIds.AnswersCount) {Value = answerCount});
        }

        protected int AnswersCount => Get<IntValue>(ValuesIds.AnswersCount).Value;
    }
}