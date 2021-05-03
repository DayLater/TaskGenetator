using System;

namespace TaskEngine.Views.TaskGenerators
{
    public interface INumbersBelongSetGeneratorView: ISeveralAnswersVariantsGeneratorView
    {
        IIntMathSetGeneratorView IntMathSetGeneratorView { get; }
    }
}