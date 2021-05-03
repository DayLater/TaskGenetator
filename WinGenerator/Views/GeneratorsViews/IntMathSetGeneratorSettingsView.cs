using System;
using System.Windows.Forms;
using TaskEngine.Views;
using WinGenerator.CustomControls;

namespace WinGenerator.Views.GeneratorsViews
{
    public class IntMathSetGeneratorSettingsView: View, IIntMathSetGeneratorView
    {
        public override string Id => "Настройки генератора множеств";

        private readonly LabeledNumericControl _maxElementCountNumeric;
        private readonly LabeledNumericControl _minElementCountNumeric;
        
        private readonly LabeledNumericControl _maxElementValueNumeric;
        private readonly LabeledNumericControl _minElementValueNumeric;

        private readonly LabeledNumericControl _positiveElementsMinCountNumeric;
        private readonly LabeledNumericControl _negativeElementsMinCountNumeric;
        private readonly CheckBox _isZeroNecessaryCheckBox;

        public IntMathSetGeneratorSettingsView()
        {
            AddRow(50);
            AddRow(50);
            
            AddColumn(25);
            AddColumn(25);
            AddColumn(25);
            AddColumn(25);

            _maxElementCountNumeric = AddLabeledNumeric(0, 0, "Максимальное число элементов", 10);
            _minElementCountNumeric = AddLabeledNumeric(0, 1, "Минимальное число элементов", 6);

            _maxElementValueNumeric = AddLabeledNumeric(1, 0, "Максимальное значение элемента", 10);
            _minElementValueNumeric = AddLabeledNumeric(1, 1, "Минимальное значение элемента", -10);

            _positiveElementsMinCountNumeric = AddLabeledNumeric(2, 0, "Минимальное количество положительных чисел", 2);
            _negativeElementsMinCountNumeric = AddLabeledNumeric(2, 1, "Минимальное количество отрицательных чисел", 2);

            _isZeroNecessaryCheckBox = AddCheckBox(3, 0, "Ноль обязателен");
        }

        public override void Activate()
        {
            _maxElementCountNumeric.Numeric.ValueChanged += OnElementsMaxCountChanged;
            _minElementCountNumeric.Numeric.ValueChanged += OnElementsMinCountChanged;

            _maxElementValueNumeric.Numeric.ValueChanged += OnMaxElementValueChanged;
            _minElementValueNumeric.Numeric.ValueChanged += OnMinElementValueChanged;

            _positiveElementsMinCountNumeric.Numeric.ValueChanged += OnPositiveElementMinCountChanged;
            _negativeElementsMinCountNumeric.Numeric.ValueChanged += OnNegativeElementMinCountChanged;

            _isZeroNecessaryCheckBox.CheckedChanged += OnZeroNecessaryChanged;
        }

        public override void Deactivate()
        {
            _maxElementCountNumeric.Numeric.ValueChanged -= OnElementsMaxCountChanged;
            _minElementCountNumeric.Numeric.ValueChanged -= OnElementsMinCountChanged;

            _maxElementValueNumeric.Numeric.ValueChanged -= OnMaxElementValueChanged;
            _minElementValueNumeric.Numeric.ValueChanged -= OnMinElementValueChanged;
            
            _positiveElementsMinCountNumeric.Numeric.ValueChanged -= OnPositiveElementMinCountChanged;
            _negativeElementsMinCountNumeric.Numeric.ValueChanged -= OnNegativeElementMinCountChanged;
            
            _isZeroNecessaryCheckBox.CheckedChanged -= OnZeroNecessaryChanged;
        }

        private void OnElementsMaxCountChanged(object sender, EventArgs e)
        {
            int value = _maxElementCountNumeric.Value;
            ElementsMaxCountChanged(value);
        }

        private void OnElementsMinCountChanged(object sender, EventArgs e)
        {
            int value = _minElementCountNumeric.Value;
            ElementsMinCountChanged(value);
        }
        
        public event Action<int> ElementsMinCountChanged = i => { };
        public event Action<int> ElementsMaxCountChanged = i => { };
        
        public int ElementsMinCount
        {
            get => _minElementCountNumeric.Value;
            set => _minElementCountNumeric.Value = value;
        }
        
        public int ElementsMaxCount
        {
            get => _maxElementCountNumeric.Value;
            set => _maxElementCountNumeric.Value = value;
        }
        
        private void OnMinElementValueChanged(object sender, EventArgs e)
        {
            int value = _minElementValueNumeric.Value;
            ElementMinValueChanged(value);
        }

        private void OnMaxElementValueChanged(object sender, EventArgs e)
        {
            int value = _maxElementValueNumeric.Value;
            ElementMaxValueChanged(value);
        }

        public event Action<int> ElementMinValueChanged = i => { };
        public event Action<int> ElementMaxValueChanged = i => { };
        
        public int ElementMinValue
        {
            get => _minElementValueNumeric.Value;
            set => _minElementValueNumeric.Value = value;
        }
        
        public int ElementMaxValue
        {
            get => _maxElementValueNumeric.Value;
            set => _maxElementValueNumeric.Value = value;
        }

        private void OnZeroNecessaryChanged(object sender, EventArgs e)
        {
            bool value = _isZeroNecessaryCheckBox.Checked;
            ZeroNecessaryChanged(value);
        }
        
        public event Action<bool> ZeroNecessaryChanged = b => { }; 
        
        public bool IsZeroNecessary
        {
            get => _isZeroNecessaryCheckBox.Checked;
            set => _isZeroNecessaryCheckBox.Checked = value;
        }

        private void OnPositiveElementMinCountChanged(object sender, EventArgs e)
        {
            int value = _positiveElementsMinCountNumeric.Value;
            PositiveElementsMinCountChanged(value);
        }

        private void OnNegativeElementMinCountChanged(object sender, EventArgs e)
        {
            int value = _negativeElementsMinCountNumeric.Value;
            NegativeElementsMinCountChanged(value);
        }
        
        public event Action<int> PositiveElementsMinCountChanged = i => { };
        public event Action<int> NegativeElementsMinCountChanged = i => { }; 
        public int PositiveElementsMinCount
        {
            get => _positiveElementsMinCountNumeric.Value;
            set => _positiveElementsMinCountNumeric.Value = value;
        }
        
        public int NegativeElementsMinCount
        {
            get => _negativeElementsMinCountNumeric.Value;
            set => _negativeElementsMinCountNumeric.Value = value;
        }
    }
}