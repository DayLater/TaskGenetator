using System.Collections.Generic;
using TaskEngine.Models.Sets;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.Elements
{
    public abstract class ElementBelongSetTaskGenerator : VariantsGenerator
    {
        protected string GetCondition<T>(ICollection<T> answers, IMathSet<T> set)
        {
            var elementString = answers.Count == 1 ? "элемент" : "все элементы";
            return $"Выберите {elementString}, принадлежащий множеству {WriteSet(set)}";
        }

        protected ElementBelongSetTaskGenerator(string id, int answerCount, ISetWriter setWriter) : base(id, answerCount, setWriter)
        {
        }
    }
}