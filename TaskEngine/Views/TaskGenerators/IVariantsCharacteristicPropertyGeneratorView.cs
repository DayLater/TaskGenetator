using System;

namespace TaskEngine.Views.TaskGenerators
{
    public interface IVariantsCharacteristicPropertyGeneratorView: IView, IVariantsView
    {
        event Action<int> MinCoefficientValueChanged;
        event Action<int> MaxCoefficientValueChanged;
        int MinCoefficientValue { set; }
        int MaxCoefficientValue { set; }
    }
}