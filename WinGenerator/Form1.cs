using System;
using System.Windows.Forms;
using TaskEngine;
using TaskEngine.Comparers;
using TaskEngine.Generators.SetGenerators.SetOperations;
using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;
using TaskEngine.Writers.Tasks;
using WinGenerator.DocWriters;

namespace WinGenerator
{
    public partial class Form1 : Form
    {
        private readonly ISetWriter _setWriter = new SetWriter(new ExpressionWriter(), 8);

        private readonly Random _random = new Random();
        private readonly CharacteristicPropertyTaskGenerator _generator = new CharacteristicPropertyTaskGenerator();
        private readonly CharacteristicPropertyTaskWriter _writer = new CharacteristicPropertyTaskWriter();

        private readonly IntBorderSetOperationTaskGenerator _testableSubSetTaskGenerator;
        private readonly BorderSetOperationTaskWriter _testableSubSetTaskWriter;

        private readonly DocWriter _docWriter = new DocWriter();

        public Form1()
        {
            _testableSubSetTaskGenerator =
                new IntBorderSetOperationTaskGenerator(
                    new SetVariantsGeneratorByCorrect(_random, new IntBorderedSetComparer()));
            _testableSubSetTaskWriter = new BorderSetOperationTaskWriter(_setWriter);
            _testableSubSetTaskGenerator.AddSetGenerator(SetOperation.Union, new UnionSetGenerator(_random));
            _testableSubSetTaskGenerator.AddSetGenerator(SetOperation.Except, new ExceptSetGenerator(_random));
            _testableSubSetTaskGenerator.AddSetGenerator(SetOperation.Intersect, new IntersectSetGenerator(_random));

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _generator.Min = int.Parse(textBox1.Text);
            _generator.Max = int.Parse(textBox2.Text);
            _generator.VariantsCount = int.Parse(textBox3.Text);
            var task = _generator.Generate();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var subSetTask = _testableSubSetTaskGenerator.Generate();

            var taskText = _testableSubSetTaskWriter.WriteTask(subSetTask);
            var answer = _testableSubSetTaskWriter.WriteAnswer(subSetTask);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var task1 = _generator.Generate();
            var taskText1 = _writer.WriteTask(task1);

            var subSetTask = _testableSubSetTaskGenerator.Generate();
            var taskText = (IVariantsTextTask)_testableSubSetTaskWriter.WriteTask(subSetTask);
            _docWriter.Write("test", new[] {taskText1, taskText});
        }
    }
}
