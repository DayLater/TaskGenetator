namespace TaskEngine.Sets
{
    public class IntBorderedSet: BorderedSet<int>
    {
        protected override void FillElements()
        {
            for (var i = Start.Value; i < End.Value; i++)
                _elements.Add(i);
        }

        public IntBorderedSet(string name, ISetBorder<int> start, ISetBorder<int> end) : base(name, start, end)
        {
        }
    }
}