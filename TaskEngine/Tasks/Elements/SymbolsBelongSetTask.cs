using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks.Elements
{
    public class SymbolsBelongSetTask: ITask
    {
        public SymbolsBelongSetTask(List<string> variants, List<string> answers, IMathSet<string> set)
        {
            Variants = variants;
            Answers = answers;
            Set = set;
        }

        public List<string> Variants { get; }
        public List<string> Answers { get; }
        public IMathSet<string> Set { get; }
    }
}