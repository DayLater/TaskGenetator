using System;

namespace TaskEngine.Views
{
    public interface IVariantsCharacteristicPropertyGeneratorView: IView, IVariantsView
    {
        event Action<int> MinCoefficientValueChanged;
        event Action<int> MaxCoefficientValueChanged;
        int MinCoefficientValue { set; }
        int MaxCoefficientValue { set; }
    }
}