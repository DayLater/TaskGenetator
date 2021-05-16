using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using TaskEngine.Extensions;
using TaskEngine.Models;

namespace TaskEngine.Writers.TaskWriters
{
    public class AccordanceTaskWriter<T1, T2>: BaseTaskWriter<Accordance<T1, T2>>
    {
        public AccordanceTaskWriter(Random random) : base(random)
        {
        }

        protected override string GetAnswer(IList<Accordance<T1, T2>> answers)
        {
            return answers.Select(GetStringAccordance).GetStringRepresentation();
        }

        protected override IEnumerable<string> GetVariants(IEnumerable<Accordance<T1, T2>> variants)
        {
            return variants.Select(GetStringAccordance);

        }

        private string GetStringAccordance(Accordance<T1, T2> accordance)
        {
            return $"{accordance.Name} = {{{GetElements(accordance)}}}";
        }

        private string GetElements(Accordance<T1, T2> accordance)
        {
            var elements = accordance.Elements.Aggregate("", (s, tuple) => s + $"({tuple.Item1}; {tuple.Item2}), ");
            return elements.Remove(elements.Length - 2, 2);
        }
    }
}