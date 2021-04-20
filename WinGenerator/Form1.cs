using System;
using System.Windows.Forms;
using TaskEngine.Comparers;
using TaskEngine.DocWriters;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Generators.SetGenerators.SetOperations;
using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Writers;
using TaskEngine.Writers.Tasks;

namespace WinGenerator
{
    public partial class Form1 : Form
    {
        private readonly ISetWriter _setWriter = new SetWriter(new ExpressionWriter(), 8);
        private readonly Random _random = new Random();

        private readonly TaskGenerators _taskGenerators;
        private readonly TaskWriters _taskWriters;

        private readonly DocWriter _docWriter = new DocWriter();

        public Form1()
        {
            _taskGenerators = new TaskGenerators(_random, new ExpressionSetGenerator(), new MathSetGenerator(),
                new SetVariantsGeneratorByCorrect(_random, new IntBorderedSetComparer()), new IntBorderSetGenerator());
            _taskWriters = new TaskWriters(_setWriter);
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var characteristicPropertyTask = _taskGenerators.CharacteristicPropertyTaskGenerator.Generate();
            var characteristicPropertyTextTask = _taskWriters.Write(characteristicPropertyTask);

            _docWriter.Write("Test", new ITextTask[] {characteristicPropertyTextTask});
        }
    }
}
