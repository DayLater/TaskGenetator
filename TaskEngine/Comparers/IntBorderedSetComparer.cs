using TaskEngine.Sets;

namespace TaskEngine.Comparers
{
    public class IntBorderedSetComparer: ISetComparer<IntBorderedSet>
    {
        public bool IsEquals(IntBorderedSet first, IntBorderedSet second)
        {
            var firstStart = first.Start;
            var firstEnd = first.End;
            var secondStart = second.Start;
            var secondEnd = second.End;

            return firstStart.Value == secondStart.Value && firstStart.BorderType == secondStart.BorderType
                                                         && firstEnd.Value == secondEnd.Value
                                                         && firstEnd.BorderType == secondEnd.BorderType;
        }
    }
}