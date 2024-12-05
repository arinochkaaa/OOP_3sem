using System;
using System.Collections.Generic;

namespace Lab7
{
    public interface IGenericCollection<T>
    {
        void Add(T item);
        bool Remove(T item);
        IEnumerable<T> View(Func<T, bool> predicate);
    }
}
