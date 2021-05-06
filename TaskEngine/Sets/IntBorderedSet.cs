namespace TaskEngine.Sets
{
    public class IntBorderedSet: BorderedSet<int>
    {
        protected override void FillElements()
        {
            var start = Start.BorderType == BorderType.Close ? Start.Value : Start.Value + 1;
            var end = End.BorderType == BorderType.Close ? End.Value + 1 : End.Value;
            
            for (var i = start; i < end; i++)
                _elements.Add(i);
        }

        public IntBorderedSet(string name, ISetBorder<int> start, ISetBorder<int> end) : base(name, start, end)
        {
        }
    }
}