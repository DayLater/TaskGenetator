using TaskEngine.Tasks;
using TaskEngine.Values;

namespace TaskEngine.Generators
{
    public abstract class SeveralAnswersGenerator<TTask>: VariantsGenerator<TTask>
        where TTask: ITask
    {
        protected SeveralAnswersGenerator(string id): base(id, 6)
        {
            Add(new IntValue(ValuesIds.AnswersCount) {Value = 2});
        }
    }
}