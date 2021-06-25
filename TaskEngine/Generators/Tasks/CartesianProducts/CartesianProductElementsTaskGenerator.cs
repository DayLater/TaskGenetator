using System;
using TaskEngine.Comparers;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.CartesianProducts
{
    public class CartesianProductElementsTaskGenerator<T>: TaskGenerator
    {
        private readonly ISetGenerator<T> _setGenerator;
        private readonly ISetComparer<T> _setComparer = new MathSetComparer<T>();
        private readonly Random _random;
        
        public CartesianProductElementsTaskGenerator(string id, ISetWriter setWriter, Random random, ISetGenerator<T> setGenerator) : base(id, setWriter)
        {
            _random = random;
            _setGenerator = setGenerator;
            Add(setGenerator);
        }

        public override ITask Generate()
        {
            var name = _random.GetRandomName();
            var set = _setGenerator.Generate(name);

            var secondName = _random.GetRandomName();
            IMathSet<T> secondSet;
            do
            {
                secondSet = _setGenerator.Generate(secondName);
            } while (_setComparer.IsEquals(set, secondSet));

            var product = new CartesianProduct<T>(set, secondSet);
            var condition = $"Перечислите все элементы декартова произведения множеств {WriteSet(set)} и {WriteSet(secondSet)}";
            return new AnswerTask<CartesianProduct<T>>(product, condition);
        }
    }
}