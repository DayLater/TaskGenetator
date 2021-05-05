using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks.Elements
{
    public class SymbolsBelongSetTask: VariantsTask<string>, ISetContained<string>
    {
        public IMathSet<string> Set { get; }

        public SymbolsBelongSetTask(IList<string> answers, IList<string> variants, IMathSet<string> set) : base(answers, variants)
        {
            Set = set;
        }

        public SymbolsBelongSetTask(string answer, IList<string> variants, IMathSet<string> set) : base(answer, variants)
        {
            Set = set;
        }
    }
}