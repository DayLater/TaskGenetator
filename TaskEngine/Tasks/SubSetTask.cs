using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class SubSetTask: Task<int>
    {
        public SubSetType TypeTask { get; }
        public IMathSet<int> TaskSet { get; }

        public SubSetTask(IMathSet<int> rightAnswer, SubSetType typeTask, IMathSet<int> taskSet) : base(rightAnswer)
        {
            TypeTask = typeTask;
            TaskSet = taskSet;
        }
    }
}