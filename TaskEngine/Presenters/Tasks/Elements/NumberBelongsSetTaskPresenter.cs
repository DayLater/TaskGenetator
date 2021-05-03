using TaskEngine.Generators.Tasks.Elements;
using TaskEngine.Views.TaskGenerators;

namespace TaskEngine.Presenters.Tasks.Elements
{
    public class NumberBelongsSetTaskPresenter: IPresenter
    {
        private readonly NumberBelongsSetTaskGenerator _taskGenerator;
        private readonly INumberBelongsSetGeneratorView _view;

        public NumberBelongsSetTaskPresenter(INumberBelongsSetGeneratorView view, NumberBelongsSetTaskGenerator taskGenerator)
        {
            _view = view;
            _taskGenerator = taskGenerator;
            
            var mathSetPresenter = new MathSetGeneratorPresenter(view.MathSetGeneratorView, taskGenerator.IntMathSetGenerator);

            view.VariantsCountChanged += variants => _taskGenerator.VariantCount = variants;
        }
    }
}