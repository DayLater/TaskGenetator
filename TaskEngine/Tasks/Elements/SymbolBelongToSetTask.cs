using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks.Elements
{
    public class SymbolBelongToSetTask: ITask
    {
        public SymbolBelongToSetTask(List<string> variants, string answer, IMathSet<string> set)
        {
            Variants = variants;
            Answer = answer;
            Set = set;
        }

        public List<string> Variants { get; }
        public string Answer { get; }
        public IMathSet<string> Set { get; }
    }
}