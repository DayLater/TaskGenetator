using System.Collections.Generic;
using TaskEngine.Sets;

namespace TaskEngine.Tasks.Elements
{
    public class SymbolBelongsSetTask: VariantsTask<string>
    {
        public IMathSet<string> Set { get; }

        public SymbolBelongsSetTask(IList<string> answers, IList<string> variants, IMathSet<string> set) : base(answers, variants)
        {
            Set = set;
        }

        public SymbolBelongsSetTask(string answer, IList<string> variants, IMathSet<string> set) : base(answer, variants)
        {
            Set = set;
        }
    }
}