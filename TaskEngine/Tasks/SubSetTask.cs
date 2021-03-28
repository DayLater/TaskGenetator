using TaskEngine.Sets;

namespace TaskEngine.Tasks
{
    public class SubSetTask: ITask
    {
        public SubSetTask(IMathSet<int> taskSet, SubSetType typeTask, IMathSet<int> answerSet)
        {
            TaskSet = taskSet;
            TypeTask = typeTask;
            AnswerSet = answerSet;
        }
        
        public SubSetType TypeTask { get; }
        public IMathSet<int> TaskSet { get; }
        
        public IMathSet<int> AnswerSet { get; }
    }
}