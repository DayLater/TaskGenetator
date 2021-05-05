using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Sets;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers
{
    public class VariantTaskWriter
    {
        private readonly ISetWriter _setWriter;

        public VariantTaskWriter(ISetWriter setWriter)
        {
            _setWriter = setWriter;
        }

        public VariantsTextTask Write<T>(IVariantsTask<T> variantsTask, string condition)
        {
            variantsTask.Variants.Shuffle();
            string answer = variantsTask.Answers.Select(a => variantsTask.Variants.IndexOf(a) + 1).GetStringRepresentation();
            var variants = GetVariants(variantsTask.Variants);
            return new VariantsTextTask(condition, answer, variants);
        }

        private IEnumerable<string> GetVariants<T>(IList<T> variants, bool withName = true)
        {
            var element = variants[0];
            return element switch
            {
                int _ => variants.Select(v => v.ToString()),
                string _ => variants.Select(v => v.ToString()),
                ExpressionSet _ => variants.Select(v => _setWriter.WriteCharacteristicProperty((ExpressionSet) (object) v)),
                IMathSet<int> _ => variants.Select(v => _setWriter.Write((IMathSet<int>) v, withName)),
                IMathSet<string> _ => variants.Select(v => _setWriter.Write((IMathSet<string>) v, withName)),
                _ => throw new ArgumentOutOfRangeException($"Unknown type of T - {typeof(T)}")
            };
        }
    }
}