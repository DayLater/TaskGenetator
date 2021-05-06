using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;

namespace TaskEngine.Writers.TaskWriters
{
    public class ListTaskWriter<T>: BaseTaskWriter<List<T>>
    {
        public ListTaskWriter(Random random) : base(random)
        {
        }

        protected override string GetAnswer(IList<List<T>> answers)
        {
            return answers.Count == 1 ? answers[0].ToString() : answers.GetStringRepresentation();
        }

        protected override IEnumerable<string> GetVariants(IEnumerable<List<T>> variants)
        {
            return variants.Select(v => v.GetStringRepresentation());
        }
    }
}