using System;

namespace TaskEngine.Views
{
    public interface IMathSetGeneratorView: IView
    {
        event Action<int> ElementsMinCountChanged;
        event Action<int> ElementsMaxCountChanged;
        int ElementsMinCount { get; set; }
        int ElementsMaxCount { get; set; }
        
        event Action<int> ElementMinValueChanged;
        event Action<int> ElementMaxValueChanged;
        int ElementMinValue { get; set; }
        int ElementMaxValue { get; set; }

        event Action<bool> ZeroNecessaryChanged;
        bool IsZeroNecessary { get; set; }

        event Action<int> PositiveElementsMinCountChanged;
        event Action<int> NegativeElementsMinCountChanged;
        int PositiveElementsMinCount { get; set; }
        int NegativeElementsMinCount { get; set; }
    }
}