using TaskEngine.Generators.Tasks;
using TaskEngine.Views;
using TaskEngine.Views.TaskGenerators;

namespace TaskEngine.Presenters.Tasks
{
    public class VariantsCharacteristicPropertyTaskPresenter: IPresenter
    {
        private readonly CharacteristicPropertyTaskGenerator _generator;

        public VariantsCharacteristicPropertyTaskPresenter(CharacteristicPropertyTaskGenerator generator, IVariantsCharacteristicPropertyGeneratorView generatorView)
        {
            _generator = generator;

            generatorView.MaxCoefficientValue = generator.MaxCoefficientValue;
            generatorView.MinCoefficientValue = generator.MinCoefficientValue;
            generatorView.VariantsCount = generator.VariantsCount;

            generatorView.VariantsCountChanged += variantsCount => _generator.VariantsCount = variantsCount;
            generatorView.MinCoefficientValueChanged += coefficient => _generator.MinCoefficientValue = coefficient;
            generatorView.MaxCoefficientValueChanged += coefficient => _generator.MaxCoefficientValue = coefficient;
        }
    }
}