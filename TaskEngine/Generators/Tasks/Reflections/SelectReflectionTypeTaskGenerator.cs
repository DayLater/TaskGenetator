using System;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Generators.Tasks.Reflections.ReflectionTypes;
using TaskEngine.Models;
using TaskEngine.Models.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.Reflections
{
    public class SelectReflectionTypeTaskGenerator<T1, T2>: VariantsGenerator
    {
        private readonly Random _random;

        private readonly VariantsSelectInjectionTaskGenerator<T1, T2> _injectionTaskGenerator;
        private readonly VariantsSelectSurjectiveTaskGenerator<T1, T2> _surjectiveTaskGenerator;
        private readonly VariantBijectiveTaskGenerator<T1, T2> _bijectiveTaskGenerator;
        
        public SelectReflectionTypeTaskGenerator(string id, ISetWriter setWriter, ISetGenerator<T1> firstSetGenerator, ISetGenerator<T2> secondSetGenerator, Random random) : base(id, 1, setWriter)
        {
            _random = random;
            
            _injectionTaskGenerator = new VariantsSelectInjectionTaskGenerator<T1, T2>("injective", setWriter, random, firstSetGenerator, secondSetGenerator);
            _surjectiveTaskGenerator =new VariantsSelectSurjectiveTaskGenerator<T1, T2>("surjective", setWriter, firstSetGenerator, secondSetGenerator, random);
            _bijectiveTaskGenerator = new VariantBijectiveTaskGenerator<T1, T2>("bijective", setWriter, firstSetGenerator, secondSetGenerator, random);
        }

        public override ITask Generate()
        {
            var type = GetRandomReflectionType();
            VariantsTask<Accordance<T1, T2>> task = type switch
            {
                ReflectionType.Injective => (VariantsTask<Accordance<T1, T2>>) _injectionTaskGenerator.Generate(),
                ReflectionType.Surjective => (VariantsTask<Accordance<T1, T2>>)_surjectiveTaskGenerator.Generate(),
                ReflectionType.Bijective => (VariantsTask<Accordance<T1, T2>>)_bijectiveTaskGenerator.Generate(),
                _ => throw new ArgumentOutOfRangeException()
            };

            return new VariantsTask<Accordance<T1, T2>>(task.Answers, GetCondition(type), task.Variants);
        }

        private string GetCondition(ReflectionType type)
        {
            var writtenType = type switch
            {
                ReflectionType.Injective => "инъекцию",
                ReflectionType.Surjective => "сюръекцию",
                ReflectionType.Bijective => "биекцию",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
            return $"Выберите {writtenType} из предложенных соответствий";
        }
        
        private ReflectionType GetRandomReflectionType()
        {
            Array types = Enum.GetValues(typeof(ReflectionType));
            return (ReflectionType) types.GetValue(_random.Next(0, types.Length));
        }
    }
}