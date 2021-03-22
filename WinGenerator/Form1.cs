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
        private readonly ISetWriter _setWriter = new SetWriter(new ExpressionWriter(), 8);

        private readonly CharacteristicPropertyTaskGenerator _generator = new CharacteristicPropertyTaskGenerator();
        private readonly CharacteristicPropertyTaskWriter _writer = new CharacteristicPropertyTaskWriter();

        private readonly SubSetTaskGenerator _subSetTaskGenerator = new SubSetTaskGenerator();
        private readonly SubSetTaskWriter _subSetTaskWriter;

        public Form1()
        {
            _subSetTaskWriter = new SubSetTaskWriter(_setWriter);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _generator.Min = int.Parse(textBox1.Text);
            _generator.Max = int.Parse(textBox2.Text);
            _generator.VariantsCount = int.Parse(textBox3.Text);
            var task = _generator.Generate();

            var taskText = _writer.WriteTask(task);
            label1.Text = taskText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var variantsCount = int.Parse(textBox4.Text);
            _subSetTaskGenerator.VariantCount = variantsCount;

            var subSetTask = _subSetTaskGenerator.Generate();

            var taskText = _subSetTaskWriter.WriteTask(subSetTask);
            label2.Text = taskText;
        }
    }
}
