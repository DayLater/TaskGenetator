using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using TaskEngine.Extensions;
using TaskEngine.Models;

namespace TaskEngine.Writers.TaskWriters
{
    public class AccordanceTaskWriter<T>: BaseTaskWriter<Accordance<T>>
    {
        public AccordanceTaskWriter(Random random) : base(random)
        {
        }

        protected override string GetAnswer(IList<Accordance<T>> answers)
        {
            return answers.Select(GetStringAccordance).GetStringRepresentation();
        }

        private string GetStringAccordance(Accordance<T> accordance)
        {
            return $"{accordance.Name} = {{{GetElements(accordance)}}}";
        }

        private string GetElements(Accordance<T> accordance)
        {
            var elements = accordance.Elements.Aggregate("", (s, tuple) => s + $"({tuple.Item1}; {tuple.Item2}), ");
            return elements.Remove(elements.Length - 2, 2);
        }

        protected override IEnumerable<string> GetVariants(IEnumerable<Accordance<T>> variants)
        {
            return variants.Select(GetStringAccordance);
        }
    }
}