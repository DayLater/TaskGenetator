using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using TaskEngine.Views;
using WinGenerator.CustomControls;

namespace WinGenerator.Views.Tabs
{
    public class HomeTabPage: IdentifiedTabPage, IHomePageView
    {
        public HomeTabPage() : base(ViewIds.Main)
        {
            var pageTable = new PercentTableLayoutPanel();
            Controls.Add(pageTable);
            pageTable.AddColumn(100);
            pageTable.AddRow(15);
            pageTable.AddRow(80);

            var headerCard = pageTable.AddCard(0, 0);
            var headerLabel =  new MaterialLabel {FontType = MaterialSkinManager.fontType.H5, Text = "Главная", Dock = DockStyle.Fill, HighEmphasis = true, TextAlign = ContentAlignment.TopLeft};
            headerCard.Controls.Add(headerLabel);

            var mainTable = pageTable.AddTable(0, 1);
            mainTable.AddRow(100);
            mainTable.AddColumn(60);
            mainTable.AddColumn(40);
            
            var aboutProgramCard = mainTable.AddCard(0, 0);
            var aboutProgramTable = new PercentTableLayoutPanel();
            aboutProgramCard.Controls.Add(aboutProgramTable);
            
            aboutProgramTable.AddColumn(100);
            aboutProgramTable.AddRow(15);
            aboutProgramTable.AddRow(35);
            aboutProgramTable.AddRow(40);
            aboutProgramTable.AddRow(10);

            var aboutLabel = aboutProgramTable.AddLabel(0, 0, MaterialSkinManager.fontType.H6, "О программе");
            aboutLabel.HighEmphasis = true;
            aboutLabel.TextAlign = ContentAlignment.TopLeft;
            var infoLabel = aboutProgramTable.AddLabel(0, 1, MaterialSkinManager.fontType.Subtitle1, 
                "Добро пожаловать в генератор индивидуальных заданий по теории множеств и отображений!" +
                "\nЗдесь Вы можете выбрать любые интересующие Вас задания, и настроить их так, как этого хотите Вы!" +
                " Для этого у каждого задания есть гибкая настройка параметров." +
                "\nПрограмма создает файлы в формате docx, который тоже можно настраивать так, как Вам нужно." +
                "\nПриятного использования!");
            infoLabel.TextAlign = ContentAlignment.TopLeft;
            aboutProgramTable.AddControl(new Panel(), 0, 2);
            var byLabel = aboutProgramTable.AddLabel(0, 3, MaterialSkinManager.fontType.Caption, "By DayLater");
            byLabel.TextAlign = ContentAlignment.BottomRight;
            
            var themeConfigCard = mainTable.AddCard(1, 0);
            var themeConfigTable = new PercentTableLayoutPanel();
            themeConfigCard.Controls.Add(themeConfigTable);
            themeConfigTable.AddColumn(100);
            themeConfigTable.AddRow(10);
            themeConfigTable.AddRow(20);
            themeConfigTable.AddRow(20);
            themeConfigTable.AddRow(50);

            var changeThemeLabel = themeConfigTable.AddLabel(0, 0, MaterialSkinManager.fontType.H6, "Настройка темы приложения");
            changeThemeLabel.HighEmphasis = true;
            changeThemeLabel.TextAlign = ContentAlignment.TopLeft;
            
            var changeThemeButton = themeConfigTable.AddButton(0, 1, "Изменить тему");
            changeThemeButton.Click += (sender, args) => ChangeThemeButtonClicked();

            var changeColorsButton = themeConfigTable.AddButton(0, 2, "Изменить цвета");
            changeColorsButton.Click += (sender, args) => ChangeColorsButtonClicked();
            themeConfigTable.AddControl(new Panel(), 0, 3);
        }

        public event Action ChangeThemeButtonClicked = () => { };
        public event Action ChangeColorsButtonClicked = () => { };
    }
}