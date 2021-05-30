using System.Drawing;
using System.Windows.Forms;
using WindowsGenerator.CustomControls;
using MaterialSkin;
using MaterialSkin.Controls;

namespace WindowsGenerator.Views
{
    public partial class GeneratorConfigForm : MaterialForm
    {
        public GeneratorConfigForm(MaterialSkinManager skinManager, View generatorView)
        {
            Size = new Size(400, 800);
            skinManager.AddFormToManage(this);
            Text = "Настройка генератора";

            var mainTable = new PercentTableLayoutPanel {Dock = DockStyle.None, Size = new Size(400, 740), Location = new Point(0, 60)};
            mainTable.AddRow(100);
            mainTable.AddColumn(100);
            var titleCard = mainTable.AddCard(0, 0);
            var contentTable = new PercentTableLayoutPanel();
            contentTable.AddRow(12);
            contentTable.AddRow(88);
            contentTable.AddColumn(100);
            titleCard.Controls.Add(contentTable);

            contentTable.AddLabel(0, 0, MaterialSkinManager.fontType.Subtitle1, generatorView.Id, true);

            contentTable.AddControl(generatorView, 0, 1);
            
            Controls.Add(mainTable);
        }
    }
}