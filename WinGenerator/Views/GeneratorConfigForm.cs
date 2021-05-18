using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using WinGenerator.CustomControls;

namespace WinGenerator.Views
{
    public partial class GeneratorConfigForm : MaterialForm
    {
        public GeneratorConfigForm(MaterialSkinManager skinManager, View generatorView)
        {
            Size = new Size(400, 800);
            skinManager.AddFormToManage(this);
            Text = "Настройка генератора";

            var mainTable = new PercentTableLayoutPanel {Dock = DockStyle.None, Size = new Size(400, 740), Location = new Point(0, 60)};
            mainTable.AddRow(10);
            mainTable.AddRow(90);
            mainTable.AddColumn(100);
            var text = mainTable.AddLabel(0, 0, MaterialSkinManager.fontType.H5, generatorView.Id);
            text.HighEmphasis = true;
            
            mainTable.AddControl(generatorView, 0, 1);
            
            Controls.Add(mainTable);
        }
    }
}