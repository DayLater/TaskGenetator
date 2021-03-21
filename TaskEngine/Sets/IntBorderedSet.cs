namespace TaskEngine.Sets
{
    public class IntBorderedSet: BorderedSet<int>
    {
        public IntBorderedSet(string name, int start, BorderType startType, int end, BorderType endType)
            : base(name, start, startType, end, endType) { }

        protected override void FillElements()
        {
            for (var i = Start.Value; i < End.Value; i++)
                _elements.Add(i);
        }
    }
}