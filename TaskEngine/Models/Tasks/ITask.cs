﻿using System.Collections.Generic;
using TaskEngine.Models.Sets;

namespace TaskEngine.Models.Tasks
{
    public interface ITask
    {
        string Condition { get; }
    }

    public interface IAnswerTask<T>: ITask
    {
        IList<T> Answers { get; }
    }

    public interface IVariantsTask<T>: IAnswerTask<T>
    {
        IList<T> Variants { get; }
    }
}