using System.Collections.Generic;
using TaskEngine.Sets;
using Xceed.Document.NET;

namespace TaskEngine.Tasks.Elements
{
    public class NumbersBelongSetTask: ITask
    {
        public NumbersBelongSetTask(List<int> answers, List<int> variants, IMathSet<int> taskSet)
        {
            Answers = answers;
            Variants = variants;
            TaskSet = taskSet;
        }

        public List<int> Variants { get; }
        public List<int> Answers { get; }
        public IMathSet<int> TaskSet { get; }
    }
}