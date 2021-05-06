using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;

namespace TaskEngine.Writers.TaskWriters
{
    public class IntTaskWriter: BaseTaskWriter<int>
    {
        protected override string GetAnswer(IList<int> answers)
        {
            return answers.Count == 1 ? answers[0].ToString() : answers.GetStringRepresentation();
        }

        protected override IEnumerable<string> GetVariants(IEnumerable<int> variants)
        {
            return variants.Select(v => v.ToString());
        }

        public IntTaskWriter(Random random) : base(random) { }
    }
}