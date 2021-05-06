using System;
using System.Collections.Generic;
using TaskEngine.Extensions;

namespace TaskEngine.Writers.TaskWriters
{
    public class StringTaskWriter: BaseTaskWriter<string>
    {
        public StringTaskWriter(Random random) : base(random)
        {
        }
        
        protected override string GetAnswer(IList<string> answers)
        {
            return answers.Count == 1 ? answers[0]: answers.GetStringRepresentation();
        }

        protected override IEnumerable<string> GetVariants(IEnumerable<string> variants)
        {
            return variants;
        }
    }
}