using System.Linq;
using TaskEngine.Sets;

namespace TaskEngine.Comparers
{
    public class IntMathSetComparer: ISetComparer<IMathSet<int>>
    {
        public bool IsEquals(IMathSet<int> first, IMathSet<int> second)
        {
            var firstElements = first.GetElements().ToArray();
            var secondElements = second.GetElements().ToArray();
            
            var firstExcept = firstElements.Except(secondElements);
            var secondExcept = secondElements.Except(firstElements);
            return !firstExcept.Any() && !secondExcept.Any();
        }
    }
}