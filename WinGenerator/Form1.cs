using System;
using System.Windows.Forms;
using TaskEngine.Generators;
using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks;
using TaskEngine.Writers;
using TaskEngine.Writers.Tasks;

namespace WinGenerator
{
    public partial class Form1 : Form
    {
        private readonly CharacteristicPropertyTaskGenerator _generator = new CharacteristicPropertyTaskGenerator();
        private readonly CharacteristicPropertyTaskWriter _writer = new CharacteristicPropertyTaskWriter();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _generator.Min = int.Parse(textBox1.Text);
            _generator.Max = int.Parse(textBox2.Text);
            _generator.CountToGenerate = int.Parse(textBox3.Text);
            var task = _generator.Generate();

            var taskText = _writer.WriteTask(task);
            label1.Text = taskText;
        }
    }
}
