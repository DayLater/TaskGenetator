namespace TaskEngine.Tasks
{
    public class ConditionTask: IConditionTask
    {
        public ConditionTask(ITask task, string condition)
        {
            Task = task;
            Condition = condition;
        }

        public ITask Task { get; }
        public string Condition { get; }
    }
}