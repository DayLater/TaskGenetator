using TaskEngine.Generators.Tasks;
using TaskEngine.Generators.Tasks.TextTasks;
using TaskEngine.Views;
using TaskEngine.Views.TaskGenerators;

namespace TaskEngine.Presenters.Tasks
{
    public class VariantsCharacteristicPropertyTaskPresenter: IPresenter
    {
        private readonly CharacteristicPropertyTaskGenerator _generator;
        private readonly CharacteristicPropertySetAnswerTextTaskGenerator _textTextTaskGenerator;

        public string Id => TaskIds.CharacteristicPropertyTask;
        public string ExampleTask { get; }

        public VariantsCharacteristicPropertyTaskPresenter(CharacteristicPropertyTaskGenerator generator, CharacteristicPropertySetAnswerTextTaskGenerator textTextTaskGenerator, IVariantsCharacteristicPropertyGeneratorView generatorView)
        {
            _generator = generator;
            _textTextTaskGenerator = textTextTaskGenerator;
            GeneratorView = generatorView;
            ExampleTask = _textTextTaskGenerator.Generate().Task;

            generatorView.MaxCoefficientValue = generator.MaxCoefficientValue;
            generatorView.MinCoefficientValue = generator.MinCoefficientValue;
            generatorView.VariantsCount = generator.VariantsCount;

            generatorView.VariantsCountChanged += variantsCount => _generator.VariantsCount = variantsCount;
            generatorView.MinCoefficientValueChanged += coefficient => _generator.MinCoefficientValue = coefficient;
            generatorView.MaxCoefficientValueChanged += coefficient => _generator.MaxCoefficientValue = coefficient;
        }

        public IView GeneratorView { get; }
    }
}