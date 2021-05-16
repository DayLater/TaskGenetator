using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Models;

namespace TaskEngine.Writers.TaskWriters
{
    public class ReflectionTaskWriter: BaseTaskWriter<Reflection>
    {
        private readonly ReflectionWriter _reflectionWriter = new ReflectionWriter();
        
        public ReflectionTaskWriter(Random random) : base(random)
        {
        }

        protected override string GetAnswer(IList<Reflection> answers)
        {
            return answers.Select(a => _reflectionWriter.CreateReflectionString(a)).GetStringRepresentation();
        }

        protected override IEnumerable<string> GetVariants(IEnumerable<Reflection> variants)
        {
            return variants.Select(a => _reflectionWriter.CreateReflectionString(a));
        }
    }
}