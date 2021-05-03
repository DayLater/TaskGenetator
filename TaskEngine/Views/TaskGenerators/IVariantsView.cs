using System;

namespace TaskEngine.Views.TaskGenerators
{
    public interface IVariantsView: IView
    {
        event Action<int> VariantsCountChanged;
        int VariantsCount { set; }
    }
}