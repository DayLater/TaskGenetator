using System;
using System.Windows.Forms;
using MaterialSkin;
using TaskEngine.Views;

namespace WinGenerator.Views
{
    public class ThemesController: IThemesController
    {
        public event Action UpdatedColors = () => { };
        private readonly MaterialSkinManager _materialSkinManager;
        private readonly Control _control;
        
        public void ChangeTheme()
        {
            _materialSkinManager.Theme = _materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
            UpdateColor();
        }

        public void ChangeColors()
        {
            _colorSchemeIndex++;
            if (_colorSchemeIndex > 2)
                _colorSchemeIndex = 0;
            UpdateColor();
        }
        
        private int _colorSchemeIndex;

        public ThemesController(MaterialSkinManager materialSkinManager, Control control)
        {
            _materialSkinManager = materialSkinManager;
            _control = control;
        }

        private void UpdateColor()
        {
            switch (_colorSchemeIndex)
            {
                case 0:
                    _materialSkinManager.ColorScheme = new ColorScheme(
                        _materialSkinManager.Theme == MaterialSkinManager.Themes.DARK
                            ? Primary.Teal500
                            : Primary.Indigo500,
                        _materialSkinManager.Theme == MaterialSkinManager.Themes.DARK
                            ? Primary.Teal700
                            : Primary.Indigo700,
                        _materialSkinManager.Theme == MaterialSkinManager.Themes.DARK
                            ? Primary.Teal200
                            : Primary.Indigo100,
                        Accent.Pink200,
                        TextShade.WHITE);
                    break;

                case 1:
                    _materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.Green600,
                        Primary.Green700,
                        Primary.Green200,
                        Accent.Red100,
                        TextShade.WHITE);
                    break;

                case 2:
                    _materialSkinManager.ColorScheme = new ColorScheme(
                        _materialSkinManager.Theme == MaterialSkinManager.Themes.DARK? Primary.Brown400 :Primary.BlueGrey800,
                        _materialSkinManager.Theme == MaterialSkinManager.Themes.DARK? Primary.Brown500 :Primary.BlueGrey900,
                        _materialSkinManager.Theme == MaterialSkinManager.Themes.DARK? Primary.Brown100 :Primary.BlueGrey500,
                        Accent.LightBlue200,
                        TextShade.WHITE);
                    break;
            }
            _control.Invalidate();
            UpdatedColors();
        }
    }
}