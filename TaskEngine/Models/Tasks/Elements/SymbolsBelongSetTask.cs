using System.Collections.Generic;
using TaskEngine.Models.Sets;

namespace TaskEngine.Models.Tasks.Elements
{
    public class SymbolsBelongSetTask: VariantsTask<string>, ISetContained<string>
    {
        public IMathSet<string> Set { get; }

        public SymbolsBelongSetTask(IList<string> answers, string condition, IList<string> variants, IMathSet<string> set) : base(answers, condition, variants)
        {
            Set = set;
        }

        public SymbolsBelongSetTask(string answer, string condition, IList<string> variants, IMathSet<string> set) : base(answer, condition, variants)
        {
            Set = set;
        }
    }
}