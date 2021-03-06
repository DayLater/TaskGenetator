﻿using System;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Tasks;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.CharacteristicProperty
{
    public class VariantsCharacteristicPropertyTaskGenerator: VariantsGenerator
    {
        private readonly ExpressionSetGenerator _expressionSetGenerator;
        private readonly Random _random;

        public VariantsCharacteristicPropertyTaskGenerator(ExpressionSetGenerator expressionSetGenerator, Random random, ISetWriter setWriter)
            : base(TaskIds.VariantsCharacteristicPropertyTask, 1, setWriter)
        {
            _expressionSetGenerator = expressionSetGenerator;
            _random = random;
            Add(_expressionSetGenerator);
        }

        public override ITask Generate()
        {
            var variants = _expressionSetGenerator.Generate(VariantsCount);
            var rightAnswerIndex = _random.Next(0, variants.Count);
            var answer = variants[rightAnswerIndex];
            var condition = $"Дано множество {WriteSet(answer)}.\nВыберите из списка вариантов его запись через характеристическое свойство.";
            return new VariantsTask<ExpressionSet>(answer,  condition, variants); 
        }
    }
}