﻿using TaskEngine.Models.Sets;
using TaskEngine.Models.Tasks;
using TaskEngine.Models.Values;
using TaskEngine.Writers;

namespace TaskEngine.Generators.Tasks
{
    public abstract class TaskGenerator: Valued, ITaskGenerator
    {
        private readonly ISetWriter _setWriter;
        
        protected TaskGenerator(string id, ISetWriter setWriter)
        {
            Id = id;
            _setWriter = setWriter;
        }

        public string Id { get; }
        public abstract ITask Generate();
        protected string WriteSet<T>(IMathSet<T> set) => _setWriter.Write(set);
        protected string WriteProperty<T>(IMathSet<T> set) => _setWriter.WriteCharacteristicProperty(set);
    }
}