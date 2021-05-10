using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Models.Sets;

namespace TaskEngine.Writers.TaskWriters
{
    public class ExpressionSetTaskWriter: BaseTaskWriter<ExpressionSet>
    {
        private readonly ISetWriter _setWriter;
        public ExpressionSetTaskWriter(Random random, ISetWriter setWriter) : base(random)
        {
            _setWriter = setWriter;
        }
        
        protected override string GetAnswer(IList<ExpressionSet> answers)
        {
           return answers.Count == 1? _setWriter.WriteCharacteristicProperty(answers[0])
               : answers.Select(a => _setWriter.WriteCharacteristicProperty(a)).GetStringRepresentation();
        }

        protected override IEnumerable<string> GetVariants(IEnumerable<ExpressionSet> variants)
        {
            return variants.Select(v => _setWriter.WriteCharacteristicProperty(v));
        }
    }
}