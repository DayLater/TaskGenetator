using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks.Texts;
using TaskEngine.Views;
using TaskEngine.Writers.Tasks;

namespace TaskEngine.Presenters
{
    public class VariantsCharacteristicPropertyTaskPresenter: ITaskPresenter
    {
        private readonly CharacteristicPropertyTaskGenerator _generator;
        private readonly CharacteristicPropertyTaskWriter _writer;

        public string Id => TaskIds.CharacteristicPropertyTask;

        public VariantsCharacteristicPropertyTaskPresenter(CharacteristicPropertyTaskGenerator generator, CharacteristicPropertyTaskWriter writer, IVariantsCharacteristicPropertyGeneratorView generatorView)
        {
            _generator = generator;
            _writer = writer;
            GeneratorView = generatorView;

            generatorView.MaxCoefficientValue = generator.MaxCoefficientValue;
            generatorView.MinCoefficientValue = generator.MinCoefficientValue;
            generatorView.VariantsCount = generator.VariantsCount;

            generatorView.VariantsCountChanged += variantsCount => _generator.VariantsCount = variantsCount;
            generatorView.MinCoefficientValueChanged += coefficient => _generator.MinCoefficientValue = coefficient;
            generatorView.MaxCoefficientValueChanged += coefficient => _generator.MaxCoefficientValue = coefficient;
        }

        public ITextTask Generate()
        {
            var task = _generator.Generate();
            return _writer.WriteTask(task);
        }

        public IView GeneratorView { get; }
    }
}