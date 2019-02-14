using System;
using System.Collections.Generic;
using System.Text;

namespace ListPractice
{
    interface IList
    {
        void PrintAll();
        void AddFirst(Object T);
        void AddLast(object T);
        void RemoveFirst();
        void RemoveLast();


    }
}
