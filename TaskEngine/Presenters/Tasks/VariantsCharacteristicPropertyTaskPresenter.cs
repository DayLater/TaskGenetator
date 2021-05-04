using TaskEngine.Generators.Tasks;
using TaskEngine.Tasks;
using TaskEngine.Views;

namespace TaskEngine.Presenters.Tasks
{
    public class VariantsCharacteristicPropertyTaskPresenter: IPresenter
    {
        private readonly ITaskGenerator<CharacteristicPropertySetAnswerTask> _generator;

        public VariantsCharacteristicPropertyTaskPresenter()
        {
        }
    }
}