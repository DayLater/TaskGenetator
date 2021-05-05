using TaskEngine.Generators.Tasks;
using TaskEngine.Sets;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;
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
        public abstract (ITask, string) Generate();
        public IValued ValuedGenerator => _taskGenerator;

        protected TTask GetTask() => _taskGenerator.Generate();
        protected string WriteSet<T>(IMathSet<T> set, bool isWriteName = true) => _setWriter.Write(set, isWriteName);
        protected string WriteCharacteristicProperty<T>(IMathSet<T> set) => _setWriter.WriteCharacteristicProperty(set);
    }
}