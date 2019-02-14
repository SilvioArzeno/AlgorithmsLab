using System;
using System.Collections.Generic;

namespace LinkedListPractice
{
    class Program
    {
        static void Main(string[] args)
        {/*
            LinkedList<Object> StringList = new LinkedList<Object>();
            StringList.AddFirst("Hello");
            StringList.AddLast("World");
            LinkedListNode<Object> node = new LinkedListNode<object>("Sub 2 PewDiePie");
            StringList.AddAfter(StringList.First, node);
            foreach(Object a in StringList)
            {
                Console.WriteLine(a);
            }

            Console.ReadKey();
            */
            LinkedListSilvio practice = new LinkedListSilvio();

            practice.AddFirst("Hello world!");
            practice.AddLast("Always remember");
            practice.AddLast("Sub 2 PewDiePie ");
            practice.AddFirst("T series is gay");
            practice.AddFirst(85000000);
            practice.AddLast("Sub 2 T-series");
            practice.RemoveFirst();
            practice.RemoveLast();

            practice.PrintAll();
            Console.ReadKey();
        }
    }
}
