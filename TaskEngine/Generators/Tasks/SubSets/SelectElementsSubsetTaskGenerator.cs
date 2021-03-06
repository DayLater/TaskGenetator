﻿using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Generators.SetGenerators;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Tasks;
using TaskEngine.Models.Values;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks.SubSets
{
    public abstract class SelectElementsSubsetTaskGenerator<T>: VariantsGenerator
    {
        private readonly IntValue _minCountInSubSet = new IntValue(ValuesIds.MinCountInSubSet) {Value = 3, MinValue = 1};
        private readonly ISetGenerator<T> _setGenerator;
        private readonly Random _random;
        
        protected SelectElementsSubsetTaskGenerator(string id, int answerCount, ISetWriter setWriter, ISetGenerator<T> setGenerator, Random random) 
            : base(id, answerCount, setWriter)
        {
            _setGenerator = setGenerator;
            _random = random;
            Add(_minCountInSubSet);
            Add(_setGenerator);
        }

        public  override ITask Generate()
        {
            var name = _random.GetRandomName();
            var set = _setGenerator.Generate(name);
            var elements = set.GetElements().ToList();
            var count = GetElementCountInSubset(_random, elements);
            var answers = CreateAnswers(elements, count, _random);

            var variants = new List<List<T>>(answers);
            while (variants.Count < VariantsCount)
            {
                var variant = new List<T>();
                while (variant.Count < count)
                {
                    var element = GetElement(elements);
                    variant.TryAdd(element);
                }
                
                if (!variants.IsContain(variant))
                    variants.Add(variant);
            }

            var mathSetVariants = CreateSets(variants);
            var answerIndexes = answers.Select(a => variants.IndexOf(a)).ToList();
            var setAnswers = answerIndexes.Select(index => mathSetVariants[index]).ToList();

            var condition = GetCondition(set, setAnswers);
            return new VariantsTask<IMathSet<T>>(setAnswers, condition, mathSetVariants);
        }

        protected abstract T GetElement(IList<T> elements);
        
        private int MinCountInSubSet => _minCountInSubSet.Value;

        private string GetCondition(IMathSet<T> set, IReadOnlyCollection<IMathSet<T>> answers)
        {
            var subSet = answers.Count == 1 ? "подмножество" : "подмножества";
            return $"Дано множество {WriteSet(set)}. Выберите его {subSet} из списка вариантов.";
        }

        private List<List<T>> CreateAnswers(IList<T> elements, int count, Random random)
        {
            var answers = new List<List<T>>();
            while (answers.Count < AnswersCount)
            {
                var answer = elements.GetListWithRandomElements(count, random);
                if (!answers.IsContain(answer))
                    answers.Add(answer);
            }

            return answers;
        }

        private List<IMathSet<T>> CreateSets(IEnumerable<IList<T>> lists)
        {
            var result = new List<IMathSet<T>>();
            foreach (var item in lists)
            {
                var name = _random.GetRandomName();
                result.Add(new MathSet<T>(name, item));
            }

            return result;
        }

        private int GetElementCountInSubset(Random random, ICollection<T> elements)
        {
            return random.Next(MinCountInSubSet, elements.Count - AnswersCount);
        }
    }
}