using System;
using System.Collections.Generic;
using System.Text;

namespace ListPractice
{
    interface IListSilvio<T>
    {
        void PrintAll();
        void AddFirst(T element);
        void AddLast(T element);
        void RemoveFirst();
        void RemoveLast();
        void Insert(int pos, T element);

    }
}
