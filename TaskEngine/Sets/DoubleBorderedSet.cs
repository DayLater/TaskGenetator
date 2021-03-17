namespace TaskEngine.Sets
{
    public class DoubleBorderedSet: BorderedSet<double>
    {
        public DoubleBorderedSet(double start, BorderType startType, double end, BorderType endType)
            : base(start, startType, end, endType) { }

        protected override void FillElements()
        {
            for (var i = Start.Value; i < End.Value; i++)
                _elements.Add(i);
        }
    }
}