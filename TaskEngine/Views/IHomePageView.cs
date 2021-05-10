using System;

namespace TaskEngine.Views
{
    public interface IHomePageView
    {
        event Action ChangeThemeButtonClicked;
        event Action ChangeColorsButtonClicked;
    }
}