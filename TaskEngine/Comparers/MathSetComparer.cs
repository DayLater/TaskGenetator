using System.Linq;
using TaskEngine.Models.Sets;

namespace TaskEngine.Comparers
{
    public class MathSetComparer<T>: ISetComparer<T>
    {
        public bool IsEquals(IMathSet<T> first, IMathSet<T> second)
        {
            var firstElements = first.GetElements().ToArray();
            var secondElements = second.GetElements().ToArray();
            
            var firstExcept = firstElements.Except(secondElements);
            var secondExcept = secondElements.Except(firstElements);
            return !firstExcept.Any() && !secondExcept.Any();
        }
    }
}