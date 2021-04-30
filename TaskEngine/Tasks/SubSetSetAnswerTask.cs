using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class SubSetSetAnswerTask: SetAnswerTask<int>
    {
        public SubSetType TypeTask { get; }
        public IMathSet<int> TaskSet { get; }

        public SubSetSetAnswerTask(IMathSet<int> rightAnswer, SubSetType typeTask, IMathSet<int> taskSet) : base(rightAnswer)
        {
            TypeTask = typeTask;
            TaskSet = taskSet;
        }
    }
}