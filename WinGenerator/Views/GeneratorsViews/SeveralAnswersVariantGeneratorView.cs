using System;
using TaskEngine.Views.TaskGenerators;
using WinGenerator.CustomControls;

namespace WinGenerator.Views.GeneratorsViews
{
    public abstract class SeveralAnswersVariantGeneratorView: VariantsGeneratorView, ISeveralAnswersVariantsGeneratorView
    {
        protected readonly LabeledNumericControl _answerCountNumeric;
        
        protected SeveralAnswersVariantGeneratorView(int width) : base(width, 50)
        {
            _variantsView.AddRow(50);
            _answerCountNumeric = _variantsView.AddLabeledNumeric(0, 1, "Количество ответов", 2);
        }

        public event Action<int> AnswerCountChanged = i => { }; 
        
        public int AnswerCount
        {
            get => _answerCountNumeric.Value;
            set => _answerCountNumeric.Value = value;
        }
        
        protected void OnAnswerCountChanged(object sender, EventArgs e)
        {
            int value = _answerCountNumeric.Value;
            AnswerCountChanged(value);
        }
    }
}