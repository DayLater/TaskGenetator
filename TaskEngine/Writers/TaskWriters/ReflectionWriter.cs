using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Models;

namespace TaskEngine.Writers.TaskWriters
{
    public class ReflectionWriter: BaseTaskWriter<Reflection>
    {
        public ReflectionWriter(Random random) : base(random)
        {
        }

        protected override string GetAnswer(IList<Reflection> answers)
        {
            return answers.Select(CreateReflectionString).GetStringRepresentation();
        }

        private string CreateReflectionString(Reflection reflection)
        {
            var result = $"f(x) = {reflection.Coefficient}x";
            if (reflection.IsFreeCoefficient)
            {
                var operation = reflection.FreeCoefficient < 0 ? "-" : "+";
                return result + $" {operation} {Math.Abs(reflection.FreeCoefficient)}";
            }

            return result;
        }

        protected override IEnumerable<string> GetVariants(IEnumerable<Reflection> variants)
        {
            return variants.Select(CreateReflectionString);
        }
    }
}