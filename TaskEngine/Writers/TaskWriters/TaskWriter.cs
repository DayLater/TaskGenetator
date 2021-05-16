using System;
using System.Collections.Generic;
using TaskEngine.Models;
using TaskEngine.Models.Sets;
using TaskEngine.Models.Tasks;
using TaskEngine.Models.Tasks.Texts;

namespace TaskEngine.Writers.TaskWriters
{
    public class TaskWriter
    {
        private readonly Dictionary<Type, ITaskWriter> _taskWriters = new Dictionary<Type, ITaskWriter>();

        public TaskWriter(ISetWriter setWriter, Random random)
        {
            Add(typeof(int), new IntTaskWriter(random));
            Add(typeof(string), new StringTaskWriter(random));
            Add(typeof(ExpressionSet), new ExpressionSetTaskWriter(random, setWriter));
            Add(typeof(IMathSet<int>), new MathSetTaskWriter<int>(random, setWriter));
            Add(typeof(IMathSet<string>), new MathSetTaskWriter<string>(random, setWriter));
            Add(typeof(List<int>), new ListTaskWriter<int>(random));
            Add(typeof(List<string>), new ListTaskWriter<string>(random));
            Add(typeof(CartesianProduct<int>), new CartesianProductTaskWriter<int>(random));
            Add(typeof(CartesianProduct<string>), new CartesianProductTaskWriter<string>(random));
            Add(typeof(Accordance<int, int>), new AccordanceTaskWriter<int, int>(random));
            Add(typeof(Accordance<string, string>), new AccordanceTaskWriter<string, string>(random));
            Add(typeof(Accordance<int, string>), new AccordanceTaskWriter<int, string>(random));
            Add(typeof(Accordance<string, int>), new AccordanceTaskWriter<string, int>(random));
            Add(typeof(Reflection), new ReflectionWriter(random));
        }

        private void Add(Type type, ITaskWriter taskWriter)
        {
            _taskWriters.Add(type, taskWriter);
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
            var genericType = task.GetType().GetInterfaces()[0].GetGenericArguments()[0];
            if (_taskWriters.TryGetValue(genericType, out var taskWriter))
                return taskWriter.Write(task);

            throw new ArgumentOutOfRangeException("Unknow type");
        }
    }
}