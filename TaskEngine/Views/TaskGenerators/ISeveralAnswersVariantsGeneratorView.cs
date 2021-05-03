using System;

namespace TaskEngine.Views.TaskGenerators
{
    public interface ISeveralAnswersVariantsGeneratorView : IVariantsView
    {
        event Action<int> AnswerCountChanged;
        int AnswerCount { get; set; }
    }
}