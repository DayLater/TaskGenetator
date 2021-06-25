using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Helpers;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Tasks;
using TaskEngine.Models.Values;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.SubSets
{
    public class VariantsSubSetTaskGenerator: VariantsGenerator
    {
        private readonly IntMathSetGenerator _setGenerator;
        private readonly Random _random;

        public VariantsSubSetTaskGenerator(IntMathSetGenerator setGenerator, Random random, ISetWriter setWriter) 
            : base(TaskIds.VariantsSelectSubsetByCharacterTask, 1, setWriter)
        {
            _setGenerator = setGenerator;
            _random = random;
            
            Add(new IntValue(ValuesIds.MinCountElementsInVariant) {Value = 2});
            Add(_setGenerator);
        }

        public override ITask Generate()
        {
            var set = _setGenerator.Generate();
            var type = SubSetTypeHelper.GetRandomSubSetType();
            var createdSubSetFunc = SubSetTypeHelper.GetTypeFunc(type);
            
            var elements = set.GetElements().Where(e => createdSubSetFunc.Invoke(e)).ToList();
            elements.Shuffle(_random);
            var variants = new List<List<int>> {elements};

            while (variants.Count < VariantsCount)
            {
                var variant = GetVariant(set);
                if (!new HashSet<int>(variant).SetEquals(elements))
                {
                    variant.Shuffle(_random);
                    variants.Add(variant);
                }
            }
            
            var setVariants = variants.Select((e, i) => new MathSet<int>(Symbols.Names[i], e))
                .Cast<IMathSet<int>>().ToList();
            
            var answer = setVariants[0];
            var condition = GetCondition(set, type);
            return new VariantsTask<IMathSet<int>>(answer, condition, setVariants);
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
            
            return result.ToList();
        }

        private string GetCondition<T>(IMathSet<T> set, SubSetType setType)
        {
            var writeSet = WriteSet(set);
            var type = SubSetTypeHelper.GetNumbersType(setType);
            return $"Дано множество {writeSet}.\nВыберите из списка вариантов его подмножество, элементами которого являются все его {type} числа множества {set.Name}";
        }
    }
}