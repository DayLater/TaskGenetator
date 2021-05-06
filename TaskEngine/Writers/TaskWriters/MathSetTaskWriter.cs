using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Sets;

namespace TaskEngine.Writers.TaskWriters
{
    public class MathSetTaskWriter<T>: BaseTaskWriter<IMathSet<T>>
    {
        private readonly ISetWriter _setWriter;
        public MathSetTaskWriter(Random random, ISetWriter setWriter) : base(random)
        {
            _setWriter = setWriter;
        }

        protected override string GetAnswer(IList<IMathSet<T>> answers)
        {
            return answers.Count == 1 ? _setWriter.Write(answers[0])
                : answers.Select(a => _setWriter.Write(a)).GetStringRepresentation();
        }

        protected override IEnumerable<string> GetVariants(IEnumerable<IMathSet<T>> variants)
        {
            return variants.Select(v => _setWriter.Write(v));
        }
    }
}