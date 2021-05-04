using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Helpers;
using TaskEngine.Sets;
using TaskEngine.Tasks;
using TaskEngine.Values;

namespace TaskEngine.Generators.Tasks
{
    public class VariantsSubSetTaskGenerator: VariantsGenerator<VariantsSetAnswerSubSetTask>
    {
        private readonly IntMathSetGenerator _setGenerator;
        private readonly Random _random;

        public VariantsSubSetTaskGenerator(IntMathSetGenerator setGenerator, Random random) : base(TaskIds.VariantsSubSetTask)
        {
            Add(new IntValue(ValuesIds.MinCountElementsInVariant) {Value = 2});
            _setGenerator = setGenerator;
            _random = random;
            Add(_setGenerator);
        }

        public override VariantsSetAnswerSubSetTask Generate()
        {
            var set = _setGenerator.Generate(1).First();
            var type = SubSetTypeHelper.GetRandomSubSetType();
            var createdSubSetFunc = SubSetTypeHelper.GetTypeFunc(type);
            
            var rightSubSet = set.GetElements().Where(e => createdSubSetFunc.Invoke(e)).ShuffleToList();
            var variants = new List<List<int>> {rightSubSet};

            while (variants.Count < VariantsCount)
            {
                var variant = GetVariant(set);
                if (!(new HashSet<int>(variant).SetEquals(rightSubSet)))
                    variants.Add(variant.ShuffleToList());
            }
            
            var setVariants = variants
                .Select((elements, i) => new MathSet<int>(Symbols.Names[i], elements)).Cast<IMathSet<int>>()
                .ToList();
            
            var rightSet = setVariants[0];
            var task = new VariantsSetAnswerSubSetTask(rightSet, setVariants.ShuffleToList(), type, set);
            return task;
        }
        
        private List<int> GetVariant(IMathSet<int> set)
        {
            var result = new HashSet<int>();
            var elements = set.GetElements().ToList();
            
            var minElementCountInVariant = Get<IntValue>(ValuesIds.MinCountElementsInVariant).Value;
            var count = _random.Next(minElementCountInVariant, elements.Count);
            
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