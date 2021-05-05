using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks.Elements
{
    public class ElementsBelongsSetConditionTaskGenerator<TTask, TType>: ConditionTaskGenerator<TTask>
        where TTask: ISetContained<TType>, IVariantsTask<TType>
    {

        protected override string GetCondition(TTask task)
        {
            var elementString = task.Answers.Count == 1 ? "элемент" : "все элементы";
            return $"Выберите {elementString}, принадлежащий множеству {WriteSet(task.Set)}";
        }

        public ElementsBelongsSetConditionTaskGenerator(ISetWriter setWriter, ITaskGenerator<TTask> taskGenerator) : base(setWriter, taskGenerator)
        {
        }
    }
}