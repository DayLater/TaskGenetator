using System;

namespace TaskEngine.Views.TaskGenerators
{
    public interface IVariantsView
    {
        event Action<int> VariantsCountChanged;
        int VariantsCount { set; }
    }
}