using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Extensions;
using TaskEngine.Sets;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers
{
    public class TaskWriter
    {
        private readonly ISetWriter _setWriter;
        private readonly VariantTaskWriter _variantTaskWriter;

        public TaskWriter(ISetWriter setWriter, Random random)
        {
            _variantTaskWriter = new VariantTaskWriter(setWriter, random);
            _setWriter = setWriter;
        }

        public string WriteAll(ITextTask textTask)
        {
            var result = textTask.Task;
            if (textTask is IVariantsTextTask variantsTextTask)
            {
                var variants = WriteVariants(variantsTextTask);
                foreach (var variant in variants)
                    result += $"\n{variant}";
            }
            result += $"\n{WriteAnswer(textTask)}";
            return result;
        }

        public string WriteAll(ITask task)
        {
            return WriteAll(WriteTextTask(task));
        }

        public IEnumerable<string> WriteVariants(IVariantsTextTask variantsTextTask)
        {
            int taskNumber = 1;
            foreach (var variant in variantsTextTask.Variants)
            {
                yield return $"{taskNumber}) {variant}";
                taskNumber++;
            }
        }

        public string WriteAnswer(ITextTask textTask)
        {
            return $"Ответ: {textTask.Answer}";
        }

        public ITextTask WriteTextTask(ITask task)
        {
            var condition = task.Condition;
            return task switch
            {
                IVariantsTask<int> intVariantTask =>_variantTaskWriter.Write(intVariantTask),
                IVariantsTask<string> strVariantsTask => _variantTaskWriter.Write(strVariantsTask),
                IVariantsTask<List<int>> strVariantsTask => _variantTaskWriter.Write(strVariantsTask),
                IVariantsTask<ExpressionSet> answerTask => _variantTaskWriter.Write(answerTask),
                IVariantsTask<IMathSet<int>> intSetVariantsTask =>_variantTaskWriter.Write(intSetVariantsTask),
                IVariantsTask<IMathSet<string>> strSetVariantsTask => _variantTaskWriter.Write(strSetVariantsTask),
                
                IAnswerTask<int> answerTask when answerTask.Answers.Count == 1 => new TextTask(condition, answerTask.Answers[0].ToString()),
                IAnswerTask<string> answerTask when answerTask.Answers.Count == 1 => new TextTask(condition, answerTask.Answers[0]),
                IAnswerTask<ExpressionSet> answerTask when answerTask.Answers.Count == 1 => new TextTask(condition, _setWriter.WriteCharacteristicProperty(answerTask.Answers[0])),
                IAnswerTask<IMathSet<int>> answerTask when answerTask.Answers.Count == 1 => new TextTask(condition, _setWriter.Write(answerTask.Answers[0])),
                IAnswerTask<IMathSet<string>> answerTask when answerTask.Answers.Count == 1 => new TextTask(condition, _setWriter.Write(answerTask.Answers[0])),
                
                IAnswerTask<int> answerTask => new TextTask(condition, answerTask.Answers.GetStringRepresentation()),
                IAnswerTask<string> answerTask => new TextTask(condition, answerTask.Answers.GetStringRepresentation()),
                IAnswerTask<ExpressionSet> answerTask => new TextTask(condition, answerTask.Answers.Select(a => _setWriter.WriteCharacteristicProperty(a)).GetStringRepresentation()),
                IAnswerTask<IMathSet<int>> answerTask => new TextTask(condition, answerTask.Answers.Select(a => _setWriter.Write(a)).GetStringRepresentation()),
                IAnswerTask<IMathSet<string>> answerTask => new TextTask(condition, answerTask.Answers.Select(a => _setWriter.Write(a)).GetStringRepresentation()),
                _ => throw new ArgumentOutOfRangeException("")
            };
        }
    }
}