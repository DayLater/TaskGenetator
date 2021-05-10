using System.Collections.Generic;
using TaskEngine.Models.Sets;

namespace TaskEngine.Models
{
    public class CartesianProduct<T>
    {
        public CartesianProduct(IMathSet<T> first, IMathSet<T> second)
        {
            First = first;
            Second = second;
        }

        public IMathSet<T> First { get; }
        public IMathSet<T> Second { get; }

        public IEnumerable<(T, T)> GetElements()
        {
            foreach (var firstElement in First.GetElements())
            {
                foreach (var secondElement in Second.GetElements())
                {
                    yield return (firstElement, secondElement);
                }
            }
        }
    }
}