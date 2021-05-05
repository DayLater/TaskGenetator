namespace TaskEngine.Tasks
{
    public interface IConditionTask
    {
        ITask Task { get; }
        string Condition { get; }
    }
}