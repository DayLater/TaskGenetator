using System;
using TaskEngine.Views.TaskGenerators;
using WinGenerator.CustomControls;

namespace WinGenerator.Views.GeneratorsViews
{
    public abstract class VariantsGeneratorView: View, IVariantsView
    {
        protected readonly LabeledNumericControl _variantsNumeric;
        protected readonly PercentTableLayoutPanel _variantsView;

        protected VariantsGeneratorView(int width, int height = 100)
        {
            AddColumn(width);
            AddColumn(100 - width);
            
            _variantsView = AddTable(0, 0);
            _variantsView.AddRow(height);
            _variantsNumeric = _variantsView.AddLabeledNumeric(0, 0,"Количество вариантов");
        }

        protected void OnVariantCountChanged(object sender, EventArgs e)
        {
            int value = _variantsNumeric.Value;
            VariantsCountChanged(value);
        }

        public event Action<int> VariantsCountChanged = i => { }; 
        
        public int VariantsCount
        {
            get => _variantsNumeric.Value;
            set => _variantsNumeric.Value = value;
        }
    }
}