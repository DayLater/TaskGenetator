namespace TaskEngine.Sets
{
    public class IntBorderedSet: BorderedSet<int>
    {
        public IntBorderedSet(int start, BorderType startType, int end, BorderType endType)
            : base(start, startType, end, endType) { }

        protected override void FillElements()
        {
            for (var i = Start.Value; i < End.Value; i++)
                _elements.Add(i);
        }
    }
}