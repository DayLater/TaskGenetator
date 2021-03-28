using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Sets;
using TaskEngine.Tasks;

namespace TaskEngine.Generators.Tasks
{
    public class TestableSubSetTaskGenerator: ITaskGenerator<TestableSubSetTask>
    {
        public int VariantCount { get; set; } = 4;
        public int MinElementCountInVariant { get; set; } = 2;
        private readonly MathSetGenerator _generator = new MathSetGenerator();
        private readonly Random _random = new Random();
        
        public TestableSubSetTask Generate()
        {
            var set = _generator.Generate(1).First();
            var type = SubSetTypeHelper.GetRandomSubSetType();
            var createdSubSetFunc = SubSetTypeHelper.GetTypeFunc(type);
            
            var rightSubSet = set.GetElements().Where(e => createdSubSetFunc.Invoke(e)).ShuffleToList();
            var variants = new List<List<int>>() {rightSubSet};

            while (variants.Count < VariantCount)
            {
                var variant = GetVariant(set);
                if (!(new HashSet<int>(variant).SetEquals(rightSubSet)))
                    variants.Add(variant.ShuffleToList());
            }
            
            var setVariants = variants
                .Select((elements, i) => new MathSet<int>(Symbols.Names[i], elements))
                .ToList();
            
            var rightSet = setVariants[0];
            setVariants = setVariants.ShuffleToList();
            var rightIndex = setVariants.IndexOf(rightSet);
            var task = new TestableSubSetTask(set, type, setVariants, rightIndex);
            return task;
        }
        
        private List<int> GetVariant(IMathSet<int> set)
        {
            var result = new HashSet<int>();
            var elements = set.GetElements().ToList();
            var count = _random.Next(MinElementCountInVariant, elements.Count);
            
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

            return result.ShuffleToList();
        }
    }
}