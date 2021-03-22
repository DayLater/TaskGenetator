using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Sets;
using TaskEngine.Tasks;

namespace TaskEngine.Generators.Tasks
{
    public class SubSetTaskGenerator
    {
        public int VariantCount { get; set; } = 4;
        private readonly MathSetGenerator _generator = new MathSetGenerator();
        private readonly Random _random = new Random();
        
        public SubSetTask Generate()
        {
            var set = _generator.Generate(1).First();
            var type = GetRandomSubSetType();
            var createdSubSetFunc = GetTypeFunc(type);

            var variants = new List<List<int>>();
            
            var rightSubSet = set.GetElements()
                .Where(e => createdSubSetFunc.Invoke(e)).ToList();
            rightSubSet.Shuffle();
            variants.Add(rightSubSet);

            while (variants.Count < VariantCount)
            {
                var variant = GetVariant(set);
                if (new HashSet<int>(variant).SetEquals(rightSubSet))
                    continue;
                
                variants.Add(variant.Shuffle());
            }

            var setVariants = variants.Select((elements, i) =>
            {
                var name = Symbols.Names[i];
                return new MathSet<int>(name, elements);
            }).ToList();
            var rightSet = setVariants[0];

            var rightIndex = setVariants.Shuffle().IndexOf(rightSet);
            var task = new SubSetTask(set, type, setVariants, rightIndex);
            return task;
        }

        private List<int> GetVariant(IMathSet<int> set)
        {
            var result = new List<int>();
            var elements = set.GetElements().ToList();
            var count = _random.Next(2, elements.Count);
            
            for (var i = 0; i < count; i++)
            {
                int element;
                do
                {
                    var index = _random.Next(0, elements.Count);
                    element = elements[index];
                } while (result.Contains(element));

                result.Add(element);
            }

            return result;
        }

        private SubSetType GetRandomSubSetType()
        {
            return (SubSetType) _random.Next(0, (int) SubSetType.MaxCount);
        }

        private Func<int, bool> GetTypeFunc(SubSetType type)
        {
            return type switch
            {
                SubSetType.Positive => i => i > 0,
                SubSetType.NonPositive => i => i <= 0,
                SubSetType.Negative => i => i < 0,
                SubSetType.NonNegative => i => i >= 0,
                SubSetType.Even => i => i % 2 == 0,
                SubSetType.Odd => i => i % 2 == 1,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}