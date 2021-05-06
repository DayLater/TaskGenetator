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
        private readonly Random _random;

        public VariantTaskWriter(ISetWriter setWriter, Random random)
        {
            _setWriter = setWriter;
            _random = random;
        }


        private IEnumerable<string> GetVariants<T>(IList<T> variants, bool withName = true)
        {
            var element = variants[0];
            return element switch
            {
                List<int> _ => variants.Select(v => v as List<int>).Select(v => v.GetStringRepresentation()),
                IMathSet<string> _ => variants.Select(v => _setWriter.Write((IMathSet<string>) v, withName)),

                _ => throw new ArgumentOutOfRangeException($"Unknown type of T - {typeof(T)}")
            };
        }
    }
}