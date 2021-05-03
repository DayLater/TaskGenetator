using System;

namespace TaskEngine.Views
{
    public interface ISymbolMathSetGeneratorView: IView
    {
        event Action<int> MaxCountChanged;
        public int MaxCount { get; set; }

        event Action<int> MinCountChanged;
        public int MinCount { get; set; }
    }
}