using System;
using TaskEngine.Views.TaskGenerators;
using WinGenerator.CustomControls;

namespace WinGenerator.Views.GeneratorsViews
{
    public abstract class VariantsGeneratorView: View, IVariantsView
    {
        protected readonly LabeledNumericControl _variantsNumeric;

        protected VariantsGeneratorView(int rowHeight, int columnWidth)
        {
            AddRow(rowHeight);
            AddColumn(columnWidth);

            _variantsNumeric = AddLabeledNumeric(0, 0, "Количество вариантов", 4);
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