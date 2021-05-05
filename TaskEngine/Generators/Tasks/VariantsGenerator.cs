using TaskEngine.Values;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks
{
    public abstract class VariantsGenerator : TaskGenerator
    {
        protected VariantsGenerator(string id, int answerCount, ISetWriter setWriter): base(id, setWriter)
        {
            Add(new IntValue(ValuesIds.VariantsCount) {Value = 4});
            if (answerCount == 1)
            {
                Add(new ImmutableIntValue(ValuesIds.AnswersCount, 1));
            }
            else
            {
                Get<IntValue>(ValuesIds.VariantsCount).Value = 6;
                Add(new IntValue(ValuesIds.AnswersCount) {Value = 2});
            }
        }

        protected int VariantsCount => Get<IntValue>(ValuesIds.VariantsCount).Value;
        protected int AnswersCount
        {
            get
            {
                return TryGetValue<IntValue>(ValuesIds.AnswersCount, out var value) ? value.Value
                    : Get<ImmutableIntValue>(ValuesIds.AnswersCount).Value;
            }
        }
    }
}