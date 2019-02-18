using System;
using System.Collections.Generic;
using System.Text;

namespace ListPractice
{
    interface IListSilvio
    {
        void PrintAll();
        void AddFirst(Object T);
        void AddLast(object T);
        void RemoveFirst();
        void RemoveLast();
        void Insert(int pos, object T);

    }
}
