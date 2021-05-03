using TaskEngine.Generators.Tasks.Elements;
using TaskEngine.Views.TaskGenerators;

namespace TaskEngine.Presenters.Tasks.Elements
{
    public class NumbersBelongSetTaskPresenter: IPresenter
    {
        public NumbersBelongSetTaskPresenter(INumbersBelongSetGeneratorView view, NumbersBelongSetTaskGenerator taskGenerator)
        {
            var mathGeneratorPresenter = new MathSetGeneratorPresenter(view.IntMathSetGeneratorView, taskGenerator.IntMathSetGenerator);
            view.AnswerCountChanged += answerCount => taskGenerator.AnswerCount = answerCount;
            view.VariantsCountChanged += variantCount => taskGenerator.VariantsCount = variantCount;

            view.AnswerCount = 2;
            view.VariantsCount = 6;
        }
    }
}