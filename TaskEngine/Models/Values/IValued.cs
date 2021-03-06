﻿using System.Collections.Generic;

namespace TaskEngine.Models.Values
{
    public interface IValued: IEnumerable<IValue>
    {
        public TValue Get<TValue>(string id)
            where TValue : IValue;
    }
}