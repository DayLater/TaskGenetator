﻿using System;
using System.Collections.Generic;
using System.Linq;
using TaskEngine.Helpers;
using TaskEngine.Sets;
using TaskEngine.Tasks;
using TaskEngine.Tasks.Texts;

namespace TaskEngine.Writers.Tasks
{
    public class TestableSubSetSetAnswerTaskWriter: SetAnswerTaskWriter<VariantsSetAnswerSubSetTask>
    {
        private readonly ISetWriter _setWriter;

        public TestableSubSetSetAnswerTaskWriter(ISetWriter setWriter)
        {
            _setWriter = setWriter;
        }

        public override ITextTask WriteTask(VariantsSetAnswerSubSetTask task)
        {
            var set = _setWriter.Write(task.Set);
            var type = SubSetTypeHelper.GetNumbersType(task.Type);
            var textTask = $"Дано множество {set}." +
                         $"\nУкажите его подмножество, элементами которого являются все его {type} числа";
            var variants = task.Variants.Select(variant => _setWriter.Write(variant, false)).ToList();
            var answer = WriteAnswer(task);
            return new VariantsTextTask(textTask, answer, variants);
        }
    }
}