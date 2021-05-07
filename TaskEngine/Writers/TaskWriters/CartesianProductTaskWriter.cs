using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;

namespace TaskEngine.Writers.TaskWriters
{
    public class CartesianProductTaskWriter<T>: BaseTaskWriter<CartesianProduct<T>>
    {
        public CartesianProductTaskWriter(Random random) : base(random)
        {
        }

        protected override string GetAnswer(IList<CartesianProduct<T>> answers)
        {
            return answers.Count == 1 ? CreateCartesianProductString(answers[0]) : answers.Select(CreateCartesianProductString).GetStringRepresentation();
        }

        protected override IEnumerable<string> GetVariants(IEnumerable<CartesianProduct<T>> variants)
        {
            return variants.Select(GetCartesianElementsString);
        }

        private string CreateCartesianProductString(CartesianProduct<T> cartesianProduct)
        {
            var elements = GetCartesianElementsString(cartesianProduct);
            return $"{cartesianProduct.First.Name} {Symbols.Multiply} {cartesianProduct.Second.Name} = {{{elements}}}";
        }

        private string GetCartesianElementsString(CartesianProduct<T> cartesianProduct)
        {
            var elements = cartesianProduct.GetElements();
            var stringElements = elements.Aggregate("", (s, tuple) => s + $"({tuple.Item1.ToString()};{tuple.Item2.ToString()}), ");
            return stringElements.Remove(stringElements.Length - 2, 2);
        }
    }
}