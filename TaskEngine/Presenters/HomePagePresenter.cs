using TaskEngine.Views;

namespace TaskEngine.Presenters
{
    public class HomePagePresenter: IPresenter
    {
        public HomePagePresenter(IHomePageView homePageView, IThemesController themesController)
        {
            homePageView.ChangeColorsButtonClicked += themesController.ChangeColors;
            homePageView.ChangeThemeButtonClicked += themesController.ChangeTheme;
        }
    }
}