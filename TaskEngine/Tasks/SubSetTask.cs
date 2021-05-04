using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class SubSetTask: ITask
    {
        public IMathSet<int> Answer { get; }
        public SubSetType TypeTask { get; }
        public IMathSet<int> TaskSet { get; }

        public SubSetTask(IMathSet<int> answer, SubSetType typeTask, IMathSet<int> taskSet)
        {
            Answer = answer;
            TypeTask = typeTask;
            TaskSet = taskSet;
        }
    }
}