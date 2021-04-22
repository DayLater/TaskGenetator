using System;

namespace TaskEngine.Views
{
    public interface IVariantsView
    {
        event Action<int> VariantsCountChanged;
        int VariantsCount { set; }
    }
}