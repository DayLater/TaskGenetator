using System.Windows.Forms;

namespace WinGenerator
{
    public class PercentTableLayoutPanel: TableLayoutPanel
    {
        public PercentTableLayoutPanel()
        {
            Dock = DockStyle.Fill;
        }
        
        public void AddRow(int height) => RowStyles.Add(new RowStyle(SizeType.Percent, height));
        public void AddColumn(int width) => ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width));
        public void AddControl(Control control, int column, int row) => Controls.Add(control, column, row);
        public void AddEmptyControl(int column, int row) => AddControl(new Panel(), column, row);

        public PercentTableLayoutPanel AddTable(int column, int row)
        {
            var table = new PercentTableLayoutPanel();
            AddControl(table, column, row);
            return table;
        }
    }
}