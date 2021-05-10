using TaskEngine.Models.Values;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks
{
    public abstract class VariantsGenerator : TaskGenerator
    {
        private readonly IntValue _variantsCount = new IntValue(ValuesIds.VariantsCount) {Value = 4, MaxValue = 20, MinValue = 2};
        protected VariantsGenerator(string id, int answerCount, ISetWriter setWriter): base(id, setWriter)
        {
            Add(_variantsCount);
            if (answerCount == 1)
            {
                Add(new ImmutableIntValue(ValuesIds.AnswersCount, 1));
            }
            else
            {
                Get<IntValue>(ValuesIds.VariantsCount).Value = 6;
                Add(new IntValue(ValuesIds.AnswersCount) {Value = 2, MinValue = 1, MaxValue = 5});
            }
        }

        protected int VariantsCount => _variantsCount.Value;
        
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