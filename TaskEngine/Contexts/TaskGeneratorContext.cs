using System;
using TaskEngine.Comparers;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Generators.SetGenerators.SetOperations;
using TaskEngine.Generators.Tasks;

namespace TaskEngine.Contexts
{
    public class TaskGeneratorContext
    {
        public NumberBelongsSetTaskGenerator NumberBelongsSetTaskGenerator { get; }
        public CharacteristicPropertyTaskGenerator CharacteristicPropertyTaskGenerator { get; }
        public VariantsSubSetTaskGenerator VariantsSubSetTaskGenerator { get; }
        public SubSetTaskGenerator SubSetTaskGenerator { get; }
        public BorderSetOperationTaskGenerator BorderSetOperationTaskGenerator { get; }

        public TaskGeneratorContext(Random random)
        {
            NumberBelongsSetTaskGenerator = new NumberBelongsSetTaskGenerator();
            
            CharacteristicPropertyTaskGenerator = new CharacteristicPropertyTaskGenerator(new ExpressionSetGenerator(), random);
            VariantsSubSetTaskGenerator = new VariantsSubSetTaskGenerator(new MathSetGenerator(), random);
            SubSetTaskGenerator = new SubSetTaskGenerator(new MathSetGenerator());

            var variantsGeneratorByCorrect = new SetVariantsGeneratorByCorrect(random, new BorderedSetComparer());
            BorderSetOperationTaskGenerator = new BorderSetOperationTaskGenerator(variantsGeneratorByCorrect, new IntBorderSetGenerator(), random);
        }
    }
}