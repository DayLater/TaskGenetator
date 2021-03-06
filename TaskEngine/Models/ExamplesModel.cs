﻿using System.Collections.Generic;

namespace TaskEngine.Models
{
    public class ExamplesModel
    {
        private readonly Dictionary<string, string> _idAndExamples = new Dictionary<string, string>();

        public void Add(string id, string example) => _idAndExamples.Add(id, example);

        public string GetExample(string id) => _idAndExamples[id];
    }
}