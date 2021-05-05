using TaskEngine.Generators.Tasks;
using TaskEngine.Sets;
using TaskEngine.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.TextTasks
{
    public abstract class ConditionTaskGenerator<TTask>: IConditionTaskGenerator
        where TTask: ITask
    {
        private readonly ITaskGenerator<TTask> _taskGenerator;
        private readonly ISetWriter _setWriter;

        protected ConditionTaskGenerator(ISetWriter setWriter, ITaskGenerator<TTask> taskGenerator)
        {
            _taskGenerator = taskGenerator;
            _setWriter = setWriter;
        }

        public string Id => _taskGenerator.Id;

        public IConditionTask Generate()
        {
            var task = _taskGenerator.Generate();
            var condition = GetCondition(task);
            return new ConditionTask(task, condition);
        }

        protected abstract string GetCondition(TTask task);
        
        public IValued ValuedGenerator => _taskGenerator;

        protected TTask GetTask() => _taskGenerator.Generate();
        protected string WriteSet<T>(IMathSet<T> set, bool isWriteName = true) => _setWriter.Write(set, isWriteName);
    }
}