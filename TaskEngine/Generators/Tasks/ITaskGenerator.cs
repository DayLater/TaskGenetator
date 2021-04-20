﻿using TaskEngine.Tasks;

namespace TaskEngine.Generators.Tasks
{
    public interface ITaskGenerator<out TTask>
        where TTask: ITask<int>
    {
        TTask Generate();
    }
}