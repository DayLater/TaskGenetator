using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks;
using TaskEngine.Values;

namespace TaskEngine.Generators
{
    public abstract class VariantsGenerator<TTask>: Generator, ITaskGenerator<TTask>
        where TTask: ITask
    {
        protected VariantsGenerator(string id, int variantCount = 4)
        {
            Id = id;
            Add(new IntValue(ValuesIds.VariantsCount) {Value = variantCount});
        }

        public string Id { get; }
        public abstract TTask Generate();
    }
}