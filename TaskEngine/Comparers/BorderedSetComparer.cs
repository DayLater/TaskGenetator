using TaskEngine.Sets;

namespace TaskEngine.Comparers
{
    public class BorderedSetComparer: ISetComparer<int>
    {
        public bool IsEquals(IMathSet<int> first, IMathSet<int> second)
        {
            var firstSet = (IntBorderedSet) first;
            var secondSet = (IntBorderedSet) second;
            var firstStart = firstSet.Start;
            var firstEnd = firstSet.End;
            var secondStart = secondSet.Start;
            var secondEnd = secondSet.End;

            return firstStart.Value == secondStart.Value && firstStart.BorderType == secondStart.BorderType
                                                         && firstEnd.Value == secondEnd.Value
                                                         && firstEnd.BorderType == secondEnd.BorderType;
        }
    }
}