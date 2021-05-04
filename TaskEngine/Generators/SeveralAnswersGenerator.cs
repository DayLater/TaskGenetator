using TaskEngine.Values;

namespace TaskEngine.Generators
{
    public abstract class SeveralAnswersGenerator: VariantsGenerator
    {
        protected SeveralAnswersGenerator(): base(6)
        {
            Add(new IntValue(ValuesIds.AnswersCount) {Value = 2});
        }
    }
}